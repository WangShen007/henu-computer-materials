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

/*
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/x86_64-w64-mingw32
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include/c++/backward
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/include-fixed
C:/Users/27341/AppData/Local/Programs/Microsoft VS Code/mingw64/bin/../lib/gcc/x86_64-w64-mingw32/8.1.0/../../../../x86_64-w64-mingw32/include
*/