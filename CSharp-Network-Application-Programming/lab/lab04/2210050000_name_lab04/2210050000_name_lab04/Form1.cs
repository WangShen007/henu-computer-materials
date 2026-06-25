using _2210050000_name_lab04.Models;

namespace _2210050000_name_lab04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new StudentDbContext())
            {
                DataStudent.DataSource = db.Student.ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (var db = new StudentDbContext())
                {
                    db.Student.Add(new Student
                    {
                        Name = txtName.Text,
                        Age = int.Parse(txtAge.Text),
                        Grade = double.Parse(txtGrade.Text)
                    });
                    db.SaveChanges();
                }
                ClearInputs();
                LoadData();
            }
            /*在这里遇到了报错,需删除StudentDbContext.cs里的
             //entity.Property(e => e.Id).ValueGeneratedNever();这一行
             */
            catch (Exception ex)
            {
                string errorMessage = $"添加失败: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n详细信息: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMessage);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要修改的学生");
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var selectedStudent = (Student)DataStudent.SelectedRows[0].DataBoundItem;

                using (var db = new StudentDbContext())
                {
                    var student = db.Student.Find(selectedStudent.Id);
                    if (student != null)
                    {
                        student.Name = txtName.Text.Trim();
                        student.Age = int.Parse(txtAge.Text);
                        student.Grade = double.Parse(txtGrade.Text);
                        db.SaveChanges();
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新失败: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DataStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的学生");
                return;
            }

            if (MessageBox.Show("确定要删除该学生吗？", "确认删除",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                var selectedStudent = (Student)DataStudent.SelectedRows[0].DataBoundItem;

                using (var db = new StudentDbContext())
                {
                    var student = db.Student.Find(selectedStudent.Id);
                    if (student != null)
                    {
                        db.Student.Remove(student);
                        db.SaveChanges();
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败: {ex.Message}");
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("姓名不能为空");
                return false;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 150)
            {
                MessageBox.Show("请输入有效的年龄（1-150）");//其实可以在Student类里设置,get 和 set
                return false;
            }

            if (!double.TryParse(txtGrade.Text, out double grade) || grade < 0 || grade > 100)
            {
                MessageBox.Show("请输入有效的成绩（0-100）");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtAge.Clear();
            txtGrade.Clear();
        }

        private void DataStudent_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DataStudent.SelectedRows.Count > 0)
                {
                    var student = (Student)DataStudent.SelectedRows[0].DataBoundItem;
                    txtName.Text = student.Name;
                    txtAge.Text = student.Age.ToString();
                    txtGrade.Text = student.Grade.ToString("F1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"选择错误: {ex.Message}");
            }
        }
    }
}
