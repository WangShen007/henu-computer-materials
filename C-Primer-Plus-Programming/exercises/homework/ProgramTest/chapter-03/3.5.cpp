#include <iostream>

using namespace std;

int main()
{
    cout<< "Enter today's day: ";
    int day,time;
    cin>>day;
    cout<<"Enter the number of days elapsed since today: ";
    cin>>time;
    int dayday = (day + time) % 7;
    string dayname,daydayname;
    switch(day)
    {
    case 0 :
        dayname = "Sunday";
        break;
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
    }
     switch(dayday)
    {
    case 0 :
        daydayname = "Sunday";
        break;
    case 1 :
        daydayname = "Monday";
        break;
    case 2 :
        daydayname = "Tuesday";
        break;
    case 3 :
        daydayname = "Wednesday";
        break;
    case 4 :
        daydayname = "Thursday";
        break;
    case 5 :
        daydayname = "Friday";
        break;
    case 6 :
        daydayname = "Saturday";
        break;
    }
    cout<<"Today is "<<dayname<<" and the future day is "<<daydayname;
}
