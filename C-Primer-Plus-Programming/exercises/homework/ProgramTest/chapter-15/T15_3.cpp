#include <iostream>
#include <cmath>

using namespace std;

class MyPoint
{
private:
    double x;
    double y;
public:
    MyPoint()
    {
        x = 0;
        y = 0;
    }
    MyPoint(double x, double y)
    {
        this->x = x;
        this->y = y;
    }
    double getX() const
    {
        return x;
    }
    double getY() const
    {
        return y;
    }
    double distance(MyPoint p)
    {
        return sqrt(pow(x - p.getX(), 2) + pow(y - p.getY(), 2));
    }
};

class ThreeDPoint : public MyPoint
{
private:
    double z;
public:
    ThreeDPoint()
    {
        MyPoint();
        z = 0;
    }
    ThreeDPoint(double x, double y, double z)
    {
        MyPoint(x, y);
        this->z = z;
    }
    double getZ() const
    {
        return z;
    }
    double distance(ThreeDPoint p)
    {
        return sqrt(pow(getX() - p.getX(), 2) + pow(getY() - p.getY(), 2) + pow(z - p.getZ(), 2));
    }
    double distance(const MyPoint &p) const
    {
        return sqrt(pow(getX() - p.getX(), 2) + pow(getY() - p.getY(), 2) + pow(z, 2));
    }
};

int main()
{
    ThreeDPoint p1;
    ThreeDPoint p2(10, 30, 25.5);
    cout << "The distance between p1 and p2 is " << p1.distance(p2) << endl;
}