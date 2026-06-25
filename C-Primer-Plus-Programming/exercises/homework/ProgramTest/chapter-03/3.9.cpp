#include <iostream>

using namespace std;

int main()
{
    cout<<"请输入年份和月份: ";
    int year,month,monthtime;
    cin>>year>>month;
    switch(month)
    {
    case 1 :
        monthtime = 31;
        break;
    case 2 :
        if(year % 4 == 0 && year % 400 != 0 || year % 400 == 0)
            monthtime = 29;
        else
            monthtime = 28;
        break;
    case 3 :
        monthtime = 31;
        break;
    case 4 :
        monthtime = 30;
        break;
    case 5 :
        monthtime = 31;
        break;
    case 6 :
        monthtime = 30;
        break;
    case 7 :
        monthtime = 31;
        break;
    case 8 :
        monthtime = 31;
        break;
    case 9 :
        monthtime = 30;
        break;
    case 10 :
        monthtime = 31;
        break;
    case 11 :
        monthtime = 30;
        break;
    case 12 :
        monthtime = 31;
        break;
    }
    cout<<monthtime;
}

/*
int GetDaysInMonth(int y,int m)
{
    int d;
    int day[]= {31,28,31,30,31,30,31,31,30,31,30,31};
    if (2==m)
    {
        d=(((0==y%4)&&(0!=y%100)||(0==y%400))?29:28);
    }
    else
    {
        d=day[m-1];

    }
    return d;
}
*/
