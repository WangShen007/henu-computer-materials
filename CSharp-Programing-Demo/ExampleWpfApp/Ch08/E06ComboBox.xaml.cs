using System.Windows.Controls;
namespace ExampleWpfApp.Ch08
{
    public partial class E06ComboBox : Page
    {
        public E06ComboBox()
        {
            InitializeComponent();
            InitComboBox1();
            InitComboBox2();
        }
        private void InitComboBox1()
        {
            comboBox1.SelectionChanged += (s, e) =>
            {
                ComboBoxItem item = (s as ComboBox).SelectedItem as ComboBoxItem;
                if (item.Content != null)
                {
                    txtStatus1.Text = $"当前选择项：{item.Content}";
                }
            };
        }
        private void InitComboBox2()
        {
            btnAddItems.Click += delegate
            {
                //添加初始项（多项）
                string[] items = { "数据结构", "C#程序设计", "Java程序设计", "Python程序设计" };
                comboBox2.Items.Clear();
                foreach (var v in items)
                {
                    comboBox2.Items.Add(v);
                }
                comboBox2.SelectedIndex = 0;
            };
            btnDelete.Click += delegate {
                comboBox2.Items.Remove(comboBox2.SelectedItem);
                status.Text = "已删除所选项";
            };
            btnClear.Click += delegate {
                comboBox2.Items.Clear();
                status.Text = "已清除所有项";
            };
            btnAddItem.Click += delegate {
                string s = textBox1.Text.Trim();
                if (s.Length == 0)
                {
                    status.Text = "请先在文本框中输入要添加的项！";
                    return;
                }
                //如果是新课程，则自动将其添加到列表框中
                if (comboBox2.Items.Contains(s))
                {
                    status.Text = $"课程【{s}】已存在，添加失败！";
                }
                else
                {
                    comboBox2.Items.Add(s);
                    status.Text = "添加成功。";
                }
            };
        }
    }
}
