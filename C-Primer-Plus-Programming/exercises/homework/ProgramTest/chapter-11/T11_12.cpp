//difficult

#include <iostream>
#include <ctime>

using namespace std;

void caculateYear(int &year, long &passedDays)
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



int caculateDayTime(int &year,int &month,int &day,long &passedDays)
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

class MyDate//: public Time
{
    public:
    int year;
    int month;//month is from 0 to 11
    int day;
    MyDate()
    {
        year = 0;
        month = 0;
        day = 0;
    }
    MyDate(long time)
    {
        year = 1970;
        month = 1;
        day = 1;
        long passedDays = time / (60 * 60 * 24);
        caculateYear(year, passedDays);
        caculateDayTime(year, month, day, passedDays);
    }
    MyDate(int year, int month, int day)
    {
        this->year = year;
        this->month = month;
        this->day = day;
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
    void setYear(int year)
    {
        this->year = year;
    }
    void setMonth(int month)
    {
        this->month = month;
    }
    void setDay(int day)
    {
        this->day = day;
    }
    void setDate(long elapseTime)
    {
        caculateYear(year, elapseTime);
        caculateDayTime(year, month, day, elapseTime);
    }

};

int main()
{
    MyDate d1;
    cout << "year:" << d1.getYear() << " month:" << d1.getMonth() << " day:" << d1.getDay() << endl;
    MyDate d2(3435555513);
    cout << "year:" << d2.getYear() << " month:" << d2.getMonth() - 1 << " day:" << d2.getDay() << endl;
    MyDate d3(561555550);
    cout << "year:" << d3.getYear() << " month:" << d3.getMonth() - 1 << " day:" << d3.getDay() << endl;
}



/*
#include <iostream>
#include <ctime>

using namespace std;

void caculateYear(int &year, long long &passedDays)
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

int caculateDayTime(int &year,int &month,int &day,long long &passedDays)
{
    while(passedDays != 0)
    {
        int d = caculateMonthTime(year,month);
        if(passedDays >= d)
        {
            passedDays -= d;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }
        else
        {
            day += passedDays;
            passedDays = 0;
        }
    }
    return 0;
}

class MyDate
{
    public:
    int year;
    int month;
    int day;
    MyDate()
    {
        year = 0;
        month = 0;
        day = 0;
    }
    MyDate(long long time)
    {
        year = 1970;
        month = 1;
        day = 1;
        long long passedDays = time / (60LL * 60LL * 24LL);
        caculateYear(year, passedDays);
        caculateDayTime(year, month, day, passedDays);
    }
    MyDate(int year, int month, int day)
    {
        this->year = year;
        this->month = month;
        this->day = day;
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
    void setYear(int year)
    {
        this->year = year;
    }
    void setMonth(int month)
    {
        this->month = month;
    }
    void setDay(int day)
    {
        this->day = day;
    }
    void setDate(long long elapseTime)
    {
        caculateYear(year, elapseTime);
        caculateDayTime(year, month, day, elapseTime);
    }

};

int main()
{
    MyDate d1;
    cout << "year:" << d1.getYear() << " month:" << d1.getMonth() << " day:" << d1.getDay() << endl;
    MyDate d2(3435555513LL);
    cout << "year:" << d2.getYear() << " month:" << d2.getMonth() - 1 << " day:" << d2.getDay() << endl;
    MyDate d3(561555550LL);
    cout << "year:" << d3.getYear() << " month:" << d3.getMonth() - 1 << " day:" << d3.getDay() << endl;
}

*/



/*

#include <iostream>
#include <ctime>

class MyDate {
private:
    int year;
    int month;
    int day;

    bool isLeapYear(int year) {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    int daysInMonth(int year, int month) {
        if (month == 2) {
            return isLeapYear(year) ? 29 : 28;
        } else if (month == 4 || month == 6 || month == 9 || month == 11) {
            return 30;
        } else {
            return 31;
        }
    }

public:
    MyDate() : year(0), month(0), day(0) {}

    MyDate(int timeInSeconds) {
        const int secondsPerDay = 60 * 60 * 24;
        const int startYear = 1970;
        const int startMonth = 1;
        const int startDay = 1;

        year = startYear;
        month = startMonth;
        day = startDay;

        long passedDays = timeInSeconds / secondsPerDay;

        while (passedDays >= 365) {
            passedDays -= isLeapYear(year) ? 366 : 365;
            year++;
        }

        while (passedDays > 0) {
            int daysInCurrentMonth = daysInMonth(year, month);
            if (passedDays >= daysInCurrentMonth) {
                passedDays -= daysInCurrentMonth;
                month++;
                if (month > 12) {
                    month = 1;
                    year++;
                }
            } else {
                day += passedDays;
                passedDays = 0;
            }
        }
    }

    int getYear() const {
        return year;
    }

    int getMonth() const {
        return month;
    }

    int getDay() const {
        return day;
    }
};

int main() {
    MyDate d1;
    std::cout << "Date 1: Year: " << d1.getYear() << " Month: " << d1.getMonth() << " Day: " << d1.getDay() << std::endl;

    MyDate d2(3435555513);
    std::cout << "Date 2: Year: " << d2.getYear() << " Month: " << d2.getMonth() << " Day: " << d2.getDay() << std::endl;

    MyDate d3(561555550);
    std::cout << "Date 3: Year: " << d3.getYear() << " Month: " << d3.getMonth() << " Day: " << d3.getDay() << std::endl;

    return 0;
}

*/













/*
#Program Test T9_5

#include <iostream>
#include <ctime>

using namespace std;

class Time
{
public:
    int hour;
    int minute;
    int second;
    Time()
    {
        hour = 0;
        minute = 0;
        second = 0;
    }
    Time(int t)
    {
        //t = time(0);
        hour = t / 3600;
        hour %= 24;
        minute = (t / 60) % 60;
        second = t % 60;
    }
    Time(int h, int m, int s)
    {
        hour = h;
        minute = m;
        second = s;
    }
    
    int getHour()
    {
        return hour;
    }

    int getMinute()
    {
        return minute;
    }

    int getSecond()
    {
        return second;
    }

    void setTime(int elpseTime)
    {
        hour = elpseTime / 3600;
        hour %= 24;
        minute = (elpseTime / 60) % 60;
        second = elpseTime % 60;
    }
    
};

int main()
{
    Time t1;
    Time t2(555550);
    cout << "t1: " << t1.getHour() << ":" << t1.getMinute() << ":" << t1.getSecond() << endl;
    cout << "t2: " << t2.getHour() << ":" << t2.getMinute() << ":" << t2.getSecond() << endl;
}

C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/x86_64-w64-mingw32
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/backward
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include-fixed
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/../../../../x86_64-w64-mingw32/include
*/


/*
#Program Test T9_8

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
        caculateDayTime(year, month, day, passeddays);*//*
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

*/