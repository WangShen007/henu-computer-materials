#include <iostream>
#include <ctime>
using namespace std;
void returntime()
{
    int totaltimes = time(0);

    //int days = totaltimes / (24 * 60 * 60);
    int lefttimes = totaltimes % (24 * 60 * 60);

    int hours = lefttimes  / (60 * 60);
    lefttimes = lefttimes % (60 * 60);

    int minutes = lefttimes / 60;
    lefttimes = lefttimes % 60;

    cout<<hours<<":"<<minutes<<":"<<lefttimes<<endl;
}
void returnyear()
{
    int totaltimes = time(0);
    int days = totaltimes / (24 * 60 * 60);
    int leftdays = days;

    int year = 1970;
    while(leftdays > 366)
    {
        if((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            leftdays -= 366;
        }
        else
        {
            leftdays -= 365;
        }
        year++;
    }

    int month = 1;
    if(leftdays > 31)//1->2
    {
        leftdays -= 31;
        month++;//month==2
    }

    if((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            if(leftdays > 29)
            {
                leftdays -= 29;
                month++;//3
            }
        }
    else
        {
            if(leftdays > 28)
            {
                leftdays -= 28;
                month++;//3
            }
        }

    if(leftdays > 31)//3month
    {
        leftdays -= 31;//4
        month++;
    }

    if(leftdays > 30)
    {
        leftdays -= 30;
        month++;//5
    }

    if(leftdays > 31)//5month
    {
        leftdays -= 31;//6
        month++;
    }

    if(leftdays > 30)//6
    {
        leftdays -= 30;
        month++;//7
    }

    if(leftdays > 31)//7month
    {
        leftdays -= 31;//8
        month++;
    }

    if(leftdays > 31)//8month
    {
        leftdays -= 31;//9
        month++;
    }

    if(leftdays > 30)//9
    {
        leftdays -= 30;
        month++;//10
    }

    if(leftdays > 31)//10month
    {
        leftdays -= 31;//11
        month++;
    }

    if(leftdays > 30)//11
    {
        leftdays -= 30;
        month++;//12
    }

    cout<<month<<" "<<leftdays + 1<<", "<<year<<" ";
}

int main()
{
    cout<<"Current date and time(GMT +0) is ";
    returnyear();
    returntime();
}
