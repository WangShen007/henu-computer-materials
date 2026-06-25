using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuLuAWinForms
{
    public partial class LX10Form : Form
    {
        public LX10Form()
        {
            InitializeComponent();

            this.Load += LX10Form_Load;
        }

        private void LX10Form_Load(object? sender, EventArgs e)
        {
            //（4）
            B b = new C();
            label1.Text = b.Result;
        }
    }

    //（1）
    public class A
    {
        public string Result { get; protected set; } = "";
        public A()
        {
            Result += "A\n";
        }
    }

    //（2）
    public class B : A
    {
        public B()
        {
            Result += "B\n";
        }
    }

    //（3）
    public class C : B
    {
        public C()
        {
            Result += "C\n";
        }
    }
}
