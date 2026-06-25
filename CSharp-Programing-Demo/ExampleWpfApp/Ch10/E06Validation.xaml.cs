using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch10
{
    public partial class E06Validation : Page
    {
        public E06Validation()
        {
            InitializeComponent();
            dataGrid1.SelectionMode = DataGridSelectionMode.Single;
            Loaded += delegate {
                using (var c = new MyDb1Entities())
                {
                    var q = (from t in c.Student select t).ToList();
                    dataGrid1.ItemsSource = q;
                    dataGrid1.SelectedIndex = q.Count() > 0 ? 0 : -1;
                }
            };
            btnSave.Click += (s, e) =>
            {
                using (var c = new MyDb1Entities())
                {
                    var success = Ch07.LinqToEntities.MyDb1Helps.SaveChanges(c, out string errorMsg);
                    if (success)
                    {
                        var q = from t in c.Student select t;
                        dataGrid1.ItemsSource = q.ToList();
                        Wpfz.MessageBoxz.ShowSuccess("保存成功！");
                    }
                    else
                    {
                        Wpfz.MessageBoxz.ShowError(errorMsg);
                    }
                }
            };
        }
    }
    public class StudentValidation : ValidationRule
    {
        public bool IsXueHaoValidation { get; set; } = false;
        public bool IsXingMingValidation { get; set; } = false;
        public bool IsXingBieValidation { get; set; } = false;
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (IsXueHaoValidation)
            {
                string str = (string)value;
                if (string.IsNullOrEmpty(str))
                {
                    return new ValidationResult(false, "不能为空");
                }
                if (!Regex.IsMatch(str, "[0-9]{8,8}"))
                {
                    return new ValidationResult(false, "必须是8位数字");
                }
            }
            if (IsXingMingValidation)
            {
                string str = (string)value;
                if (string.IsNullOrEmpty(str))
                {
                    return new ValidationResult(false, "不能为空");
                }
                if(str.Length<2)
                {
                    return new ValidationResult(false, "至少需要2个字");
                }
                if (!Regex.IsMatch(str, "^[\u4e00-\u9fa5]{2,}$"))
                {
                    return new ValidationResult(false, "必须全部由汉字组成");
                }
            }
            if (IsXingBieValidation)
            {
                string str = (string)value;
                if (string.IsNullOrEmpty(str))
                {
                    return new ValidationResult(false, "不能为空");
                }
                if (!(str == "男" || str == "女"))
                {
                    return new ValidationResult(false, "必须是男或女");
                }
            }
            return new ValidationResult(true, null);
        }
    }
}
