#include <iostream>
#include <cmath>

using namespace std;

#define PI acos(-1)

class Circle2D
{
public:
    double x;
    double y;
    double getX() const
    {
        return x;
    }
    double getY() const
    {
        return y;
    }
    double radius;
    double getRadius() const
    {
        return radius;
    }
    Circle2D()
    {
        x = 0;
        y = 0;
        radius = 1;
    }
    Circle2D(double x, double y, double radius)
    {
        this->x = x;
        this->y = y;
        this->radius = radius;
    }
    double getArea() const
    {
        return PI * radius * radius;
    }
    double getPerimeter() const
    {
        return 2 * PI * radius;
    }
    bool contains(double x, double y) const
    {
        return (sqrt(x * x - this->x * this->x + y * y - this->y * this->y) < radius);
    }
    bool contains(const Circle2D& circle) const
    {
        return (sqrt((circle.x - x) * (circle.x - x) + (circle.y - y) * (circle.y - y)) < radius - circle.radius);
    }
    bool overlaps(const Circle2D& circle) const
    {
        return (sqrt((circle.x - x) * (circle.x - x) + (circle.y - y) * (circle.y - y)) < radius + circle.radius);
    }
};

int main()
{
    Circle2D c1(2, 2, 5.5);
    Circle2D c2(2, 2, 5.5);
    Circle2D c3(4, 5, 10.5);
    cout << "Area of c1: " << c1.getArea() << endl;
    cout << "Perimeter of c1: " << c1.getPerimeter() << endl;

    cout << "c1 contains (3, 3): " << c1.contains(3, 3) << endl;
    cout << "c1 contains c2: " << c1.contains(c2) << endl;
    cout << "c1 overlaps c3: " << c1.overlaps(c3) << endl;
}