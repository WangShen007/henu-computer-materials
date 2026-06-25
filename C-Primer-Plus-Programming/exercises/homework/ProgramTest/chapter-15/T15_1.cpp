#include <string>
#include <iostream>
#include <cmath>
using namespace std;

class GeometricObject
{
public:
  GeometricObject();
  GeometricObject(const string& color, bool filled);
  string getColor() const;
  void setColor(const string& color);
  bool isFilled() const;
  void setFilled(bool filled);
  string toString() const; 

private:
  string color;
  bool filled;
}; // Must place semicolon here

GeometricObject::GeometricObject()
{
  color = "white";
  filled = false;
}

GeometricObject::GeometricObject(const string& color, bool filled)
{
  this->color = color;
  this->filled = filled;
}

string GeometricObject::getColor() const
{
  return color;
}

void GeometricObject::setColor(const string& color)
{
  this->color = color;
}

bool GeometricObject::isFilled() const
{
  return filled;
}

void GeometricObject::setFilled(bool filled)
{
  this->filled = filled;
}

string GeometricObject::toString() const
{
  return "Geometric Object";
}


class Triangle : public GeometricObject
{
private:
    double side1;
    double side2;
    double side3;
public:
    Triangle();
    Triangle(double side1, double side2, double side3);
    double getSide1() const;
    double getSide2() const;
    double getSide3() const;
    double getArea() const;
    double getPerimeter() const;
};

Triangle::Triangle()
{
    side1 = 1.0;
    side2 = 1.0;
    side3 = 1.0;
}

Triangle::Triangle(double side1, double side2, double side3)
{
    this->side1 = side1;
    this->side2 = side2;
    this->side3 = side3;
}

double Triangle::getSide1() const
{
    return side1;
}

double Triangle::getSide2() const
{
    return side2;
}

double Triangle::getSide3() const
{
    return side3;
}

double Triangle::getArea() const
{
    double s = (side1 + side2 + side3) / 2;
    return sqrt(s * (s - side1) * (s - side2) * (s - side3));
}

double Triangle::getPerimeter() const
{
    return side1 + side2 + side3;
}

int main()
{
    cout<<"Enter the sides of the triangle: ";
    double side1, side2, side3;
    cin>>side1>>side2>>side3;
    cout<<"Enter the color of the triangle: ";
    string color;
    cin>>color;
    cout<<"Is the triangle filled (1/0): ";
    bool filled;
    cin>>filled;
    Triangle t(side1, side2, side3);
    t.setColor(color);
    t.setFilled(filled);
    cout<<"Area: "<<t.getArea()<<endl;
    cout<<"Perimeter: "<<t.getPerimeter()<<endl;
    cout<<"Color: "<<t.getColor()<<endl;
    cout<<"Filled: "<<t.isFilled()<<endl;
    return 0;
}