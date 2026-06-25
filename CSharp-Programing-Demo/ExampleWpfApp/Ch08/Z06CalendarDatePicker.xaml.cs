using System;
using System.Windows.Controls;

namespace ExampleWpfApp.Ch08
{
    public partial class Z06CalendarDatePicker : Page
    {
        public Z06CalendarDatePicker()
        {
            InitializeComponent();
            datePicker1.SelectedDateChanged += (s, e) =>
            {
                DateTime? dt = datePicker1.SelectedDate;
                Wpfz.MessageBoxz.ShowInfo(dt.ToString());
            };
        }
    }
}
