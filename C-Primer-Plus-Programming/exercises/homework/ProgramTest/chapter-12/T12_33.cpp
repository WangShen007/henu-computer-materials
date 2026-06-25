#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

class Point
{
    private:
        double x;
        double y;
    public:
        Point(double x = 0, double y = 0)
        {
            this->x = x;
            this->y = y;
        }
        double getX()
        {
            return x;
        }
        double getY()
        {
            return y;
        }
        double distance(Point p)
        {
            return sqrt(pow(x - p.x, 2) + pow(y - p.y, 2));
        }
};

double calculateTriangleArea(Point p1, Point p2, Point p3)
{
    double a = p1.distance(p2);
    double b = p2.distance(p3);
    double c = p3.distance(p1);
    double s = (a + b + c) / 2;
    return sqrt(s * (s - a) * (s - b) * (s - c));
}

int main()
{
    cout<<"Enter the number og the points: ";
    int n;
    cin>>n;
    vector<Point> v(n);
    cout<<"Enter the coordinates of the points "<<": ";
    for(int i = 0;i < v.size();i++)
    {
        double x, y;
        cin>>x>>y;
        v[i] = Point(x, y);
    }
    double sum = 0;
    for(int i = 1;i < v.size() - 1;i++)
    {
        sum += calculateTriangleArea(v[0], v[i], v[i + 1]);
    }
    cout<<"The total area is "<<sum<<endl;
    return 0;
}