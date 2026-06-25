using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ExampleWpfApp.Ch08
{
    public partial class Z10TreeView : Page
    {
        public Z10TreeView()
        {
            InitializeComponent();
            btnBind.Click += BtnBind_Click;
        }
        private void BtnBind_Click(object sender, RoutedEventArgs e)
        {
            List<NodeX> ns = new List<NodeX>();
            string[] gs = new string[] { "基本信息", "及时通讯", "地理轨迹", "邮件", "网页痕迹", "网络购物" };
            string[] ps = new string[] { "QQ", "通讯录", "短信", "QQ邮箱", "QQ企业版", "WIFI-蓝牙信息" };
            string[] ios = new string[] {
                "\ue201", "\ue197", "\ue008", "\ue143", "\ue141", "\ue142"
            };
            var ioslen = ios.Length - 1;
            Random r = new Random();
            for (int i = 0; i < 30; i++)
            {
                var n1 = new NodeX
                {
                    NodeName = gs[r.Next(0, gs.Length - 1)],
                    Iconz = ios[r.Next(0, ioslen)]
                };
                ns.Add(n1);
                int len = r.Next(6, 30);
                n1.Nodes = new List<NodeX>();
                for (int j = 0; j < 100; j++)
                {
                    var n2 = new NodeX
                    {
                        NodeName = ps[r.Next(0, 5)],
                        Iconz = ios[r.Next(0, ioslen)],
                        Nodes = new List<NodeX>()
                    };
                    n1.Nodes.Add(n2);
                    for (int a = 0; a < 30; a++)
                    {
                        var n3 = new NodeX
                        {
                            NodeName = ps[r.Next(0, 5)],
                            Iconz = ios[r.Next(0, ioslen)]
                        };
                        n2.Nodes.Add(n3);
                    }
                }
            }
            this.tree1.ItemsSource = ns;
        }
    }

    public class NodeX
    {
        public NodeX()
        {
        }

        /// <summary>显示的文本值</summary>
        public string NodeName { get; set; } = string.Empty;

        /// <summary>是否选中</summary>
        public bool? Checked { get; set; } = false;

        /// <summary>是否展开</summary>
        public bool IsExpand { get; set; }

        /// <summary>节点图标</summary>
        public string Iconz { get; set; } = string.Empty;

        /// <summary>子节点</summary>
        public IList<NodeX> Nodes { get; set; }

        /// <summary>节点数据源</summary>
        public virtual IList<string> ItemSource { get; set; }

        /// <summary>视图控件，只有当ViewType=UserControl时才有效</summary>
        public string ViewControl { get; set; }

    }
}
