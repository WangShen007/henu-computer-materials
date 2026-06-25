#include <iostream>

using namespace std;

class Rectangle2D
{
public:
    double x;
    double y;
    double width;
    double height;
    void setX(double x)
    {
        this->x = x;
    }
    double getX() const
    {
        return x;
    }
    void setY(double y)
    {
        this->y = y;
    }
    double getY() const
    {
        return y;
    }
    void setWidth(double width)
    {
        this->width = width;
    }
    double getWidth() const
    {
        return width;
    }
    void setHeight(double height)
    {
        this->height = height;
    }
    double getHeight() const
    {
        return height;
    }
    Rectangle2D()
    {
        x = 0;
        y = 0;
        width = 1;
        height = 1;
    }
    Rectangle2D(double x, double y, double width, double height)
    {
        this->x = x;
        this->y = y;
        this->width = width;
        this->height = height;
    }
    double getArea() const
    {
        return width * height;
    }
    double getPerimeter() const
    {
        return 2 * (width + height);
    }
    bool contains(double x, double y) const
    {
        return (x > this->x - width / 2 && x < this->x + width / 2 && y > this->y - height / 2 && y < this->y + height / 2);
    }
    bool contains(const Rectangle2D& rectangle) const
    {
        return (x - width / 2 < rectangle.x - rectangle.width / 2 && x + width / 2 > rectangle.x + rectangle.width / 2 && y - height / 2 < rectangle.y - rectangle.height / 2 && y + height / 2 > rectangle.y + rectangle.height / 2);
    }
    bool overlaps(const Rectangle2D& rectangle) const
    {
        return (x - width / 2 < rectangle.x + rectangle.width / 2 && x + width / 2 > rectangle.x - rectangle.width / 2 && y - height / 2 < rectangle.y + rectangle.height / 2 && y + height / 2 > rectangle.y - rectangle.height / 2);
    }
};

int main()
{
    Rectangle2D r1(2, 2, 5.5, 4.9);
    Rectangle2D r2(4, 5, 10.5, 3.2);
    Rectangle2D r3(3, 5, 2.3, 5.4);
    cout << "Area of r1: " << r1.getArea() << endl;
    cout << "Perimeter of r1: " << r1.getPerimeter() << endl;
    cout << "r1 contains the point (3, 3): " << r1.contains(3, 3) << endl;
    cout << "r1 contains the rectangle centered at (4, 5) with width 10.5 and height 3.2: " << r1.contains(r2) << endl;
    cout << "r1 overlaps the rectangle centered at (3, 5) with width 2.3 and height 5.4: " << r1.overlaps(r3) << endl;
    return 0;
}