using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FuLuAWpfApp.A11
{
    public abstract class MyShape
    {
        protected Border parentElement;
        public MyShape(Border parent)
        {
            this.parentElement = parent;
        }

        public abstract void Draw();

        public abstract double GetArea();
    }
}
