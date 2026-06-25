using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ExampleWpfApp.Ch07.OtherDemos.LinqToXML
{
    /// <summary>
    /// Ex02DemoPage.xaml 的交互逻辑
    /// </summary>
    public partial class DemoPage : Page
    {
        public DemoPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (sender as Button).Tag.ToString();
            if (s == "1")  //创建并保存XML
            {
                XElement xe1 = new XElement("Score",
                    new XElement("体育", 85),
                    new XElement("语文", 86)
                );
                XElement xe2 = new XElement("数据结构", 85);
                XElement xTree = new XElement("root",
                    new XElement("姓名", "张三"),
                    new XElement("Score",
                        from x in xe1.Elements() select x,
                        new XComment("英语包括四级和六级"),
                        new XElement("英语",
                            new XElement("Course1", 87, new XAttribute("Level", 4)),
                            new XElement("Course2", 77, new XAttribute("Level", 6))
                        ),
                        xe2,
                        new XElement("数学", 80)
                    )
                );
                textBlock1.Text = xTree.ToString();
                xTree.Save("test.xml");
            }
            else  //加载并查询XML
            {
                StringBuilder sb = new StringBuilder();
                XElement root = null;
                try
                {
                    root = XElement.Load("test.xml");
                }
                catch
                {
                    MessageBox.Show("请先执行【创建并保存XML文件】");
                    return;
                }
                sb.AppendLine("【查询示例1】的结果：");
                var q1 = from t in root.Elements()
                             //where (string)t.Attribute("Name")=="张三"
                         select t;
                foreach (var v in q1)
                {
                    sb.AppendLine(v.ToString());
                }
                sb.AppendLine();
                sb.AppendLine("【查询示例2】的结果：");
                var q2 = from t in root.Elements("姓名")
                         select t;
                foreach (var v in q2)
                {
                    sb.AppendLine(v.Name + ":" + v.Value);
                }
                sb.AppendLine();
                sb.AppendLine("【查询示例3】的结果：");
                var q3 = from t in root.Elements("Score")
                         select t;
                foreach (var v in q3)
                {
                    //遍历其子代
                    foreach (var v1 in v.Descendants())
                    {
                        if (v1.HasElements == false)
                        {
                            if (v1.HasAttributes == true)
                            {
                                sb.AppendFormat("{0}--{1}(英语{2}级)",
                                    v1.Name, v1.Value, v1.Attribute("Level").Value);
                                sb.AppendLine();
                            }
                            else
                            {
                                sb.AppendLine(v1.Name + "--" + v1.Value);
                            }
                        }
                    }
                }
                textBlock1.Text = sb.ToString();
            }
        }
    }
}
