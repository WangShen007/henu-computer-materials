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
    cout<<"Enter the time zone offset to GMT: ";
    int t;
    cin>>t;
    int currentHour = (totalHours + t) % 24 ;
    cout<<"Current time is "<<currentHour<<":"<<currentMinute<<":"<<currentSecond<<endl;

    return 0;
}
