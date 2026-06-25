using System.Data;
using ClientWinFormsExamples.ch05.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ClientWinFormsExamples.ch05
{
    public partial class E0506 : Form
    {
        public E0506()
        {
            InitializeComponent();

            InitEvents();

            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            using var c = new MyDb1Context();
            var q = from t in c.JBXX select t;
            jBXXBindingSource.DataSource = q.ToList();
            dataGridView1.Refresh();
        }

        private void InitEvents()
        {
            dataGridView1.SelectionChanged += (s, e) =>
            {
                JBXX jbxx = (JBXX)jBXXBindingSource.Current;
                textBoxId.Text = jbxx.XueHao;
                textBoxName.Text = jbxx.XingMing;
                textBoxGender.Text = jbxx.XingBie;
                dateTimePicker1.Value = jbxx.ChuShengRiQi;
                byte[]? bytes = jbxx.ZhaoPian;
                if (bytes == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Image = new Bitmap(new MemoryStream(bytes));
                }
            };
            btnAdd.Click += (s, e) =>
            {
                using var c = new MyDb1Context();
                JBXX jbxx = new()
                {
                    XueHao = textBoxId.Text,
                    XingMing = textBoxName.Text,
                    XingBie = textBoxGender.Text,
                    ChuShengRiQi = dateTimePicker1.Value
                };
                c.JBXX.Add(jbxx);
                try
                {
                    c.SaveChanges();
                }
                catch (Exception ex)
                {
                    string errMsg = $"{ex.Message}\n内部异常：\n{ex.InnerException?.Message}";
                    MessageBox.Show(errMsg, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                using var c1 = new MyDb1Context();
                var q = from t in c1.JBXX select t;
                jBXXBindingSource.DataSource = q.ToList();
                dataGridView1.Refresh();
            };
            btnDelete.Click += (s, e) =>
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请先选择要删除的行，然后再单击删除按钮。", "警告");
                    return;
                }
                using var c = new MyDb1Context();
                JBXX jbxx = (JBXX)jBXXBindingSource.Current;
                c.JBXX.Remove(jbxx);
                c.SaveChanges();
                using var c1 = new MyDb1Context();
                var q = from t in c1.JBXX select t;
                jBXXBindingSource.DataSource = q.ToList();
                dataGridView1.Refresh();
            };
            btnModify.Click += (s, e) =>
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请先选择要修改的行，然后再单击修改按钮。", "警告");
                    return;
                }
                using var c = new MyDb1Context();
                JBXX jbxx = (JBXX)jBXXBindingSource.Current;
                jbxx.XueHao = textBoxId.Text;
                jbxx.XingMing = textBoxName.Text;
                jbxx.XingBie = textBoxGender.Text;
                jbxx.ChuShengRiQi = dateTimePicker1.Value;
                c.SaveChanges();
                dataGridView1.Refresh();
            };
            btnImportPhoto.Click += (s, e) =>
            {
                using var c = new MyDb1Context();
                string s1 = Application.StartupPath;
                s1 = string.Concat(s1.AsSpan(0, s1.IndexOf("bin")), "images");
                OpenFileDialog d = new()
                {
                    InitialDirectory = s1,
                };
                if (d.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(d.FileName);
                    JBXX jbxx = (JBXX)jBXXBindingSource.Current;
                    jbxx.ZhaoPian = bytes;
                    c.SaveChanges();
                    pictureBox1.Image = new Bitmap(d.OpenFile());
                    dataGridView1.Refresh();
                }
            };
            btnRemovePhoto.Click += (s, e) =>
            {
                using var c = new MyDb1Context();
                JBXX jbxx = (JBXX)jBXXBindingSource.Current;
                jbxx.ZhaoPian = null;
                c.SaveChanges();
                pictureBox1.Image = null;
                dataGridView1.Refresh();
            };
        }
    }
}
