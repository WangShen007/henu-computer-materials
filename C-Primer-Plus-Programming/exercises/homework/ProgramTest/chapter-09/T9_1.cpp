#include <iostream>
using namespace std;

#ifndef RECTANGLE_H
#define RECTANGLE_H

class Rectangle
{
public:
    double width;
    double height;
    Rectangle();
    Rectangle(double wide, double high);
    double getWidth();
    double getHeight();
    void setWidth(double wide);
    void setHeight(double high);
    double getArea();
    double getPerimeter();
};

#endif // RECTANGLE_H

Rectangle::Rectangle()
{
    width = 1;
    height = 1;
}

Rectangle::Rectangle(double wide, double high)
{
    width = wide;
    height = high;
}

double Rectangle::getWidth()
{
    return width;
}

double Rectangle::getHeight()
{
    return height;
}

void Rectangle::setWidth(double wide)
{
    width = wide;
}

void Rectangle::setHeight(double high)
{
    height = high;
}

double Rectangle::getArea()
{
    return height * width;
}

double Rectangle::getPerimeter()
{
    return 2 * (width * height);
}


int main()
{
    Rectangle rectangle1;
    Rectangle rectangle2(3.5, 35.9);

    cout<<"Rectangle rectangle1;"<<endl;
    cout<<"Rectangle rectangle2(3.5, 35.9);"<<endl;
    cout<<endl;
    cout<<"Rectangle1 width and height: "<<rectangle1.getWidth()<<" "<<rectangle1.getHeight()<<endl;
    cout<<"Rectangle2 width and height: "<<rectangle2.getWidth()<<" "<<rectangle2.getHeight()<<endl;
    cout<<"-------------------------------------------------------"<<endl;
    cout<<endl;

    rectangle1.setWidth(4);
    rectangle1.setHeight(40);
    cout<<"rectangle1.setWidth(4);"<<endl;
    cout<<"rectangle1.setHeight(40);"<<endl;
    cout<<"-------------------------------------------------------"<<endl;
    cout<<endl;

    cout<<"Rectangle1 Area: "<<rectangle1.getArea()<<"  Perimeter: "<<rectangle1.getPerimeter()<<endl;
    cout<<"Rectangle2 Area: "<<rectangle2.getArea()<<"  Perimeter: "<<rectangle2.getPerimeter()<<endl;

    return 0;
}
