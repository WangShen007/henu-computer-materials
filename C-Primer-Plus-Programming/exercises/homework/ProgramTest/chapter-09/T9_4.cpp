#include <iostream>
#include <cmath>

using namespace std;

class MyPoint
{
    public:
    double x;
    double y;
    MyPoint()
    {
        x = 0;
        y = 0;
    }
    MyPoint(double a, double b)
    {
        x = a;
        y = b;
    }
    double getx()
    {
        return x;
    }
    double gety()
    {
        return y;
    }
    double distance(MyPoint p)
    {
        return sqrt((x - p.x)*(x - p.x) + (y - p.y)*(y - p.y));
    }
};

int main()
{
    MyPoint p1(0, 0);
    MyPoint p2(10, 30.5);
    cout<<"Distance between p1 and p2 is: "<<p1.distance(p2)<<endl;
}