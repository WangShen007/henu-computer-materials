using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAWpfApp.A10
{
    public class A1002Data : IDataErrorInfo
    {
        public int Min { get; set; }
        public int Average { get; set; }
        public int Max { get; set; }

        //获取指示对象在何处出错的错误信息（IDataErrorInfo要求实现的接口）
        public string Error
        {
            get { return null; }
        }

        //获取具有给定名称的属性的错误信息（IDataErrorInfo要求实现的接口）
        public string this[string columnName]
        {
            get
            {
                string result = "";
                // 检查是否通过验证
                switch (columnName)
                {
                    case "Min": result = GetResult(Min); break;
                    case "Average": result = GetResult(Average); break;
                    case "Max": result = GetResult(Max); break;
                }
                return result;
            }
        }

        private string GetResult(int number)
        {
            string s = "";
            if ((number < 0) || (number > 255))
            {
                s = "该值不在 0 到 255 之间";
            }
            return s;
        }
    }
}
