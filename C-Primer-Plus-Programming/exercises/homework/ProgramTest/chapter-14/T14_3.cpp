#include <iostream>

using namespace std;

class Circle
{
public:
  Circle();
  Circle(double);
  double getArea() const;
  double getRadius() const;
  void setRadius(double);
  static int getNumberOfObjects();
  bool operator<(const Circle& c) const
  {
    return radius < c.radius;
  }
    bool operator<=(const Circle& c) const
    {
        return radius <= c.radius;
    }
    bool operator==(const Circle& c) const
    {
        return radius == c.radius;
    }
    bool operator!=(const Circle& c) const
    {
        return radius != c.radius;
    }
    bool operator>(const Circle& c) const
    {
        return radius > c.radius;
    }
    bool operator>=(const Circle& c) const
    {
        return radius >= c.radius;
    }

private:
  double radius;
  static int numberOfObjects;
};

int Circle::numberOfObjects = 0;

// Construct a circle object
Circle::Circle()
{
  radius = 1;
  numberOfObjects++;
}

// Construct a circle object
Circle::Circle(double newRadius)
{
  radius = newRadius;
  numberOfObjects++;
}

// Return the area of this circle
double Circle::getArea() const
{
  return radius * radius * 3.14159;
}

// Return the radius of this circle
double Circle::getRadius() const
{
  return radius;
}

// Set a new radius
void Circle::setRadius(double newRadius)
{
  radius = (newRadius >= 0) ? newRadius : 0;
}

// Return the number of circle objects
int Circle::getNumberOfObjects()
{
  return numberOfObjects;
}
