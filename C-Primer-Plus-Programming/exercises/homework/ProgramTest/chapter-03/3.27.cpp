#include <iostream>
#include <ctime>

using namespace std;

int main()
{
    int totalSeconds = time(0);
    int currentSecond = totalSeconds % 60;
    int totalMinutes = totalSeconds / 60;
    int currentMinute = totalMinutes % 60;
    int totalHours = totalMinutes / 60;
    int hour;
    string time;
    cout<<"Enter the time zone offset to GMT: ";
    int t;
    cin>>t;
    int currentHour = (totalHours + t) % 24;
    if(currentHour > 12)
    {
        hour = currentHour - 12;
        time = "PM";
    }
    else
        {
            hour = currentHour;
            time = "AM";
        }
    cout<<"Current time is "<<hour<<":"<<currentMinute<<":"<<currentSecond<<" "<<time<<endl;
    return 0;
}
