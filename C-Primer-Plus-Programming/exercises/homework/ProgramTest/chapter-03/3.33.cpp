#include <iostream>

using namespace std;

int main()
{
    cout << "Enter year: (e.g., 2012): ";
    int year;
    cin>>year;

    cout<<"Enter month: 1-12:";
    int month;
    cin>>month;
    if(month == 1)
        {
            month = 13;
            year -= 1;
        }
    if(month == 2)
        {
            month = 14;
            year -= 1;
        }

    cout<<"Enter the day of the month: 1-31: ";
    int day;
    cin>>day;

    int j = year / 100;
    int k = year % 100;
    int q = day;
    int m = month;
    int h;
    h = (q + 26 * (m + 1) / 10 + k + k / 4 +  j / 4 + 5 * j) % 7;
    if (h < 0)
    {
        h += 7;
    }

    //int h;
    //double m = (day + 26.0 * (month + 1) / 10.0+ year % 100 + year % 100 / 4 + year / 100 / 4 + 5 * year / 100) % 7;
    //h = static_cast<int>(m);
    string name;
    switch(h)
    {
    case 0 :
        name = "Saturday";
        break;
    case 1 :
        name = "Sunday";
        break;
    case 2 :
        name = "Monday";
        break;
    case 3 :
        name = "Tuesday";
        break;
    case 4 :
        name = "Wednesday";
        break;
    case 5 :
        name = "Thursday";
        break;
    case 6 :
        name = "Friday";
        break;
    }
    cout<<"Day of the week is "<<name;
}
