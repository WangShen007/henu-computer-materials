#include <iostream>
#include <cmath>
#include <algorithm>
using namespace std;

const int SIZE = 2;

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

Rectangle2D getRectangle(const double points[5][SIZE])
{
    double max_x = points[0][0];
    for(int i = 0;i < 5;i++)
    {
        max_x = max(max_x, points[i][0]);
    }
    double min_x = points[0][0];
    for(int i = 0;i < 5;i++)
    {
        min_x = min(min_x, points[i][0]);
    }
    double max_y = points[0][1];
    for(int i = 0;i < 5;i++)
    {
        max_y = max(max_y, points[i][1]);
    }
    double min_y = points[0][1];
    for(int i = 0;i < 5;i++)
    {
        min_y = min(min_y, points[i][1]);
    }
    return Rectangle2D((max_x + min_x) / 2, (max_y + min_y) / 2, max_x - min_x, max_y - min_y);
}

int main()
{
    double points[5][SIZE] = {{1.0,2.5},{3,4},{5,6},{7,8},{9,10}};
    Rectangle2D r = getRectangle(points);
    cout<<"The bounding rectangle's center ("<<r.getX()<<", "<<r.getY()<<"), width "<<r.getWidth()<<", height "<<r.getHeight()<<endl;
    return 0;
}