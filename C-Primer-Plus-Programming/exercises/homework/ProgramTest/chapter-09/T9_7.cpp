#include <iostream>
#include <ctime>
#include <cstdlib>
#include <algorithm>

using namespace std;

class StopWatch
{
    private:
        time_t startTime;
        time_t endTime;

    public:
        StopWatch()
        {
            startTime = time(0);
        }

        void stop()
        {
            endTime = time(0);
        }

        double getElapsedTime()
        {
            return difftime(endTime, startTime);
        }
};

int main()
{
    StopWatch sw;
    srand(time(0));
    int a[100000];
    for (int i = 0; i < 100000; i++)
    {
        a[i] = rand() % 100000;
// do something
    }
    sort(a, a + 100000);
    sw.stop();
    cout << "Elapsed time: " << sw.getElapsedTime() << endl;
}


/*
        time_t startTime;
        time_t endTime;

这段C++代码定义了两个time_t类型的变量startTime和endTime。

time_t是C++中表示时间的类型,它通常表示从Epoch时间(1970年1月1日00:00:00 UTC)到现在的秒数。

所以这段代码定义了两个变量startTime和endTime来表示程序的开始时间和结束时间。通过计算两个时间变量的差值,可以得到程序的执行时间。

startTime表示程序开始执行的时间点,endTime表示程序结束执行的时间点。获取这两个时间点的值后,就可以计算出程序的总执行时间了。*/