#include <iostream>

using namespace std;

int main()
{
    cout<<"Enter the year and day: ";
    int year;
    int day[12];
    cin>>year>>day[0];

    day[1] = (day[0] + 31) % 7;

    if((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
    {
        day[2] = ( day[1] + 29 ) % 7;
    }
    else
    {
        day[2] = ( day[1] + 28 ) % 7;
    }

    int daycount = 30;
    for(int i = 3;i < 12;i++)//4yuekaishi
    {
        if( i == 3 || i == 5 || i == 7 || i == 8 || i == 10)
        {
            daycount = 31;
        }
        day[i] = (day[i - 1] + daycount) % 7;
        daycount = 30;
    }

    for(int i = 0;i < 12;i++)
    {
        string monthname;
        switch(i)
        {
            //一月January,二月February,三月March,四月April,五月May,六月June,
            //七月July,八月August,九月September,十月October,十一月November,十二月December
        case 0 :
            monthname = "January";
            break;
        case 1 :
            monthname = "February";
            break;
        case 2 :
            monthname = "March";
            break;
        case 3 :
            monthname = "April";
            break;
        case 4 :
            monthname = "May";
            break;
        case 5 :
            monthname = "June";
            break;
        case 6 :
            monthname = "July";
            break;
        case 7 :
            monthname = "August";
            break;
        case 8 :
            monthname = "September";
            break;
        case 9 :
            monthname = "October";
            break;
        case 10 :
            monthname = "November";
            break;
        case 11 :
            monthname = "December";
            break;
        default :
            monthname = "null";
        }

        string dayname;
        switch(day[i])
        {
        case 1 :
            dayname = "Monday";
            break;
        case 2 :
            dayname = "Tuesday";
            break;
        case 3 :
            dayname = "Wednesday";
            break;
        case 4 :
            dayname = "Thursday";
            break;
        case 5 :
            dayname = "Friday";
            break;
        case 6 :
            dayname = "Saturday";
            break;
        case 0 :
            dayname = "Sunday";
            break;
        default :
            dayname = "null";
        }

        cout<<monthname<<" 1, "<<year<<" is "<<dayname<<endl;
    }
}
