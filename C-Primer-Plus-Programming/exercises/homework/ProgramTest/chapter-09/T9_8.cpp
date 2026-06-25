#include <iostream>
#include <ctime>

using namespace std;

void caculateYear(int &year, int &passedDays)
{
    while (passedDays >= 365)
    {
        if(year % 4 == 0 && year % 100!= 0 || year % 400 == 0)
            {
                passedDays -= 366;
                year++;
            }
            else
            {
                passedDays -= 365;
                year++;
            }
    }
}


int caculateMonthTime(int year,int month)
{
    if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
    {
        return 31;
    }
    else if(month == 4 || month == 6 || month == 9 || month == 11)
    {
        return 30;
    }
    else if(month == 2)
    {
        if(year % 4 == 0 && year % 100!= 0 || year % 400 == 0)
        {
            return 29;
        }
        else
        {
            return 28;
        }
    }
    return 0;
}

int caculateDayTime(int &year,int &month,int &day,int &passedDays)
{
    while(passedDays != 0)
    {
        int d = caculateMonthTime(year,month);
        if(passedDays >= d)
        {
            passedDays -= d;
            month++;
        }
        else
        {
            day += passedDays;
            passedDays = 0;
        }
    }
    return 0;
}

class Date
{
public:
    int year;
    int month;
    int day;
    Date()//一个无参构造函数，为当前日期创建一个Date对象
    {
        /*int t = time(0);
        int passeddays = t / (60 * 60 * 24);
        year += 1970;
        caculateYear(year, passeddays);
        caculateDayTime(year, month, day, passeddays);*/
        year = 1970;
        month = 1;
        day = 1;
    }

    Date(int passeddays)
    {
        year = 1970;
        month = 1;
        day = 1;
        passeddays = passeddays / (60 * 60 * 24);
        caculateYear(year, passeddays);
        caculateDayTime(year, month, day, passeddays);
    }

    Date(int y, int m, int d)
    {
        year = y;
        month = m;
        day = d;
    }

    int getYear()
    {
        return year;
    }

    int getMonth()
    {
        return month;
    }

    int getDay()
    {
        return day;
    }

    void setDate(int elapseTime)
    {
        caculateYear(year, elapseTime);
        caculateDayTime(year, month, day, elapseTime);
    }
};

int main()
{
    Date d1;
    cout << "year:" << d1.getYear() << " month:" << d1.getMonth() << " day:" << d1.getDay() << endl;
    Date d2(555550);
    cout << "year:" << d2.getYear() << " month:" << d2.getMonth() << " day:" << d2.getDay() << endl;
    Date d3(561555550);
    cout << "year:" << d3.getYear() << " month:" << d3.getMonth() << " day:" << d3.getDay() << endl;
}





/*
void caculateTime(int &year, int &month, int &day,int &passeddays)
{
        while (passeddays >= 365)
        {
            if(year % 4 == 0 && year % 100!= 0 || year % 400 == 0)
            {
                passeddays -= 366;
                year++;
            }
            else
            {
                passeddays -= 365;
                year++;
            }
        }
        month = 1;
        day = 1;
        if(passeddays >= 31)
        {
            month = 2;
            passeddays -= 31;

            if(year % 4 == 0 && year % 100!= 0 || year % 400 == 0)
            {
                if(passeddays >= 29)
                {
                    month = 3;
                    day = 29;
                    passeddays -= 29;
                }
                else
                {
                    day = passeddays;
                    passeddays = 0;
                }
            }
            else
            {
                if(passeddays >= 28)
                {
                    month = 3;
                    passeddays -= 28;
                }
                else
                {
                    day = passeddays;
                    passeddays = 0;
                }
            }

            if(passeddays >= 31)
            {
                month = 4;
                passeddays -= 31;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 30)
            {
                month = 5;
                passeddays -= 30;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 31)
            {
                month = 6;
                passeddays -= 31;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 30)
            {
                month = 7;
                passeddays -= 30;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 31)
            {
                month = 8;
                passeddays -= 31;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 31)
            {
                month = 9;
                passeddays -= 31;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 30)
            {
                month = 10;
                passeddays -= 30;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 31)
            {
                month = 11;
                passeddays -= 31;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

            if(passeddays >= 30)
            {
                month = 12;
                passeddays -= 30;
            }
            else
            {
                day = passeddays;
                passeddays = 0;
            }

        }
        else
        {
            month = 1;
            day = passeddays;
            passeddays = 0;
        }
        year += 1970;


}

class Date
{
public:
    int year;
    int month;
    int day;
    Date()//一个无参构造函数，为当前日期创建一个Date对象
    {
        int t = time(0);
        int passeddays = t / (60 * 60 * 24);
        caculateTime(year, month, day, passeddays);
    }

    Date(int x)
    {
        x = x / (60 * 60 * 24);
        caculateTime(year, month, day, x);
    }

    Date(int y, int m, int d)
    {
        year = y;
        month = m;
        day = d;
    }

    int getYear()
    {
        return year;
    }

    int getMonth()
    {
        return month;
    }

    int getDay()
    {
        return day;
    }

    void setDate(int elapseTime)
    {
        caculateTime(year, month, day, elapseTime);
    }
};

int main()
{
    Date d1;
    cout << "year:" << d1.getYear() << " month:" << d1.getMonth() << " day:" << d1.getDay() << endl;
    Date d2(555550);
    cout << "year:" << d2.getYear() << " month:" << d2.getMonth() << " day:" << d2.getDay() << endl;
}
*/

/*
        time_t t = time(0);
        tm* now = localtime(&t);
        year = now->tm_year + 1900;
        month = now->tm_mon + 1;
        day = now->tm_mday;

这段C++代码是获取当前系统时间并格式化的代码:

time_t t = time(0);

使用time()函数获取当前系统时间,返回一个time_t类型的时间戳
tm* now = localtime(&t);

使用localtime()把时间戳转换为本地时间的tm结构体
year = now->tm_year + 1900;

tm结构体中的年份是相对于1900的,所以加上1900得到完整的年份
month = now->tm_mon + 1;

tm结构体中的月份范围是0-11,所以加1得到正确的月份
day = now->tm_mday;

直接获取tm结构体中的日期字段
所以这段代码的作用就是获取当前的年、月、日信息。
*/