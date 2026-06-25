using FuLuAWinForms.SY.Models;
using System.Windows.Forms;

namespace FuLuAWinForms
{
    public partial class SY07Form : Form
    {
        private readonly MyDb07Context c = new();
        public SY07Form()
        {
            InitializeComponent();

            buttonDelete.Click += ButtonDelete_Click;
            buttonSave.Click += ButtonSave_Click;

            studentBindingSource.AddingNew += StudentBindingSource_AddingNew;

            InitStudentData();
            LoadStudentData();
        }

        private void StudentBindingSource_AddingNew(object? sender, System.ComponentModel.AddingNewEventArgs e)
        {
            var newStudent = new SY07Student();
            c.SY07Student.Add(newStudent);
            e.NewObject = newStudent;
        }

        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            studentBindingSource.EndEdit();
            c.SaveChanges();
            MessageBox.Show("保存成功");
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            // 删除选定行
            studentBindingSource.RemoveCurrent();
            studentBindingSource.EndEdit();
            c.SaveChanges();
        }

        /// <summary>
        /// 添加初始数据，方便测试
        /// </summary>
        private void InitStudentData()
        {
            var n = c.SY07Student.Count();
            if (n == 0)
            {
                c.SY07Student.Add(new SY07Student { Name = "张三", Age = 20, Score = 90 });
                c.SY07Student.Add(new SY07Student { Name = "李四", Age = 22, Score = 70 });
                c.SY07Student.Add(new SY07Student { Name = "王五", Age = 21, Score = 80 });
                c.SY07Student.Add(new SY07Student { Name = "赵六", Age = 25, Score = 75 });
                c.SaveChanges();
            }
        }
        private void LoadStudentData()
        {
            var students = c.SY07Student.ToList();
            studentBindingSource.DataSource = students;
        }
    }
}
