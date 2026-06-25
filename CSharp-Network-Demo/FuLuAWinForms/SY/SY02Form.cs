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
    public partial class SY02Form : Form
    {
        public SY02Form()
        {
            InitializeComponent();

            textBoxPwd.PasswordChar = '*';
            textBoxPwd.TextChanged += (s, e) =>
            {
                textBox2.Text = textBoxPwd.Text;
            };
        }
    }
}
