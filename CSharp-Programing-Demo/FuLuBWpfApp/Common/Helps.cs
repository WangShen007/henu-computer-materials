using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FuLuBWpfApp.Common
{
    class Helps
    {
        //初始化测试数据，演示用（确保演示数据可预测）
        public static void InitTestData()
        {
            using (var c = new BankEntities())
            {
                //清空表数据
                var v = c.Database;
                v.ExecuteSqlCommand("delete from AccountInfo");
                v.ExecuteSqlCommand("delete from EmployeeInfo");
                v.ExecuteSqlCommand("delete from LoginInfo");
                v.ExecuteSqlCommand("delete from MoneyInfo");
                v.ExecuteSqlCommand("delete from RateInfo");
                //初始化表数据
                InitAccountInfo(c);
                InitEmployeeInfo(c);
                InitLoginInfo(c);
                InitMoneyInfo(c);
                InitRateInfo(c);
                //更新数据库
                if (!SaveChanges(c, out string errMsg))
                {
                    MessageBox.Show($"初始化数据库失败。异常：{errMsg}\n");
                }
            }
        }

        //************ 存款用户账户信息 *********************//
        // accountNo：账号，【nahar(6)，主键】
        // IdCard：身份证号，【nchar(18)】
        // accountName：姓名，【nvarchar(20)】
        // accountPass：密码，【nvarchar(20)】
        // accountType：账户类型，【nvarchar(8)】
        //*****************************************//
        private static void InitAccountInfo(BankEntities c)
        {
            List<AccountInfo> list = new List<AccountInfo>
                    {
                        new AccountInfo { accountNo = "001001", IdCard = "123456789012345001", accountName = "张三",
                            accountPass = "123456", accountType = "活期"
                        },
                        new AccountInfo { accountNo = "001002", IdCard = "123456789012345001", accountName = "张三",
                            accountPass = "123456", accountType = "一年定期"
                        },
                        new AccountInfo { accountNo = "001003", IdCard = "123456789012345001", accountName = "张三",
                            accountPass = "123456", accountType = "三年定期"
                        },
                    };
            c.AccountInfo.AddRange(list);
        }

        //************ 银行职员信息 *********************//
        // EmployeeNo：工号，【nchar(5)，主键】
        // EmployeeName：姓名，【nvarchar(20)】
        // sex：性别，【nchar(1)】
        // workDate：参加工作日期，【datetime】
        // telphone：手机号，【nvarchar(11)】
        // idCard：身份证号，【nchar(18)】
        // photo：照片，【varbinary(MAX)】
        //*****************************************//
        private static void InitEmployeeInfo(BankEntities c)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>
                    {
                        new EmployeeInfo {
                            EmployeeNo = "00001", idCard = "123456789012345001", EmployeeName = "张三", sex = "男",
                            workDate= DateTime.Parse("2011-01-01"), telphone="12345678901",
                        },
                        new EmployeeInfo {
                            EmployeeNo = "00002", idCard = "123456789012345002", EmployeeName = "李四", sex = "男",
                            workDate= DateTime.Parse("2011-01-02"), telphone="12345678902",
                        },
                        new EmployeeInfo {
                            EmployeeNo = "00003", idCard = "123456789012345003", EmployeeName = "王五", sex = "男",
                            workDate= DateTime.Parse("2011-01-03"), telphone="12345678903"
                        },
                    };
            c.EmployeeInfo.AddRange(list);
        }

        //************ 银行操作员登录信息 *********************//
        // Bno：用户名，【nchar(5)，主键】
        // Password：密码，【nvarchar(20)】
        //*****************************************//
        private static void InitLoginInfo(BankEntities c)
        {
            List<LoginInfo> list = new List<LoginInfo>
                    {
                        new LoginInfo { Bno = "00001", Password="123456" },
                        new LoginInfo { Bno = "00002", Password="123456" },
                        new LoginInfo { Bno = "00003", Password="123456" },
                    };
            c.LoginInfo.AddRange(list);
        }

        //************ 用户存取款信息（由银行操作员录入） *********************
        // Id：序号，【int，主键，自动增量】
        // accountNo：账号，【nchar(6)】
        // dealDate：日期，【datetime】
        // dealType：存款类型，【nvarchar(8)】
        // dealMoney：存取款金额，【float】
        // balance：利率，【float】
        //********************************************
        private static void InitMoneyInfo(BankEntities c)
        {
            List<MoneyInfo> list = new List<MoneyInfo>
                    {
                        new MoneyInfo { accountNo = "123456", dealDate = DateTime.Parse("2018-01-01"),
                            dealType = "活期", dealMoney = 1000, balance = 0.001,
                        },
                    };
            c.MoneyInfo.AddRange(list);
        }

        //************ 存款利率信息 *********************//
        // rationType：存款类型，【nvarchar(20)，主键】
        // rationValue：利率，【float】
        //********************************************//
        private static void InitRateInfo(BankEntities c)
        {
            List<RateInfo> list = new List<RateInfo>
                    {
                        new RateInfo { rationType = "活期", rationValue = 0.001 },
                        new RateInfo { rationType = "零存整取", rationValue = 0.002 },
                        new RateInfo { rationType = "一年定期", rationValue = 0.003 },
                        new RateInfo { rationType = "三年定期", rationValue = 0.004 },
                    };
            c.RateInfo.AddRange(list);
        }

        public static bool SaveChanges(BankEntities c, out string errorMsg)
        {
            bool isSuccess = false;
            errorMsg = null;
            try
            {
                c.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
                errorMsg = $"{ex.Message}\n";
                var exceptionType = ex.GetType();
                if (ex is System.Data.Entity.Validation.DbEntityValidationException ex1)
                {
                    errorMsg += "\n【EntityValidationErrors属性】的信息如下：\n";
                    var q = from t in ex1.EntityValidationErrors select t;
                    foreach (var v in q)
                    {
                        foreach (var v1 in v.ValidationErrors)
                        {
                            errorMsg += $"{v1.ErrorMessage}\n";
                        }
                    }
                }
                if (ex is System.Data.Entity.Infrastructure.DbUpdateException ex2)
                {
                    errorMsg += "\n【内部异常】信息如下：\n";
                    var inner = ex2.InnerException;
                    if (inner != null)
                    {
                        if (inner.InnerException != null)
                        {
                            errorMsg += inner.InnerException.Message;
                        }
                        else
                        {
                            errorMsg += inner.Message;
                        }
                    }
                }
            }
            return isSuccess;
        }
    }
}
