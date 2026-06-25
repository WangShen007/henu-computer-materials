#include <iostream>
#include <cmath>
using namespace std;

class RegularPolygon
{
    private:
        int n;
        double side;
        double x;
        double y;

        public:
        RegularPolygon()
        {
            n = 3;
            side = 1;
            x = 0;
            y = 0;
        }
        RegularPolygon(int n, double side)
        {
            this->n = n;
            this->side = side;
            x = 0;
            y = 0;
        }
        RegularPolygon(int n, double side, double x, double y)
        {
            this->n = n;
            this->side = side;
            this->x = x;
            this->y = y;
        }

        int getN()
        {
            return n;
        }

        double getSide()
        {
            return side;
        }

        double getX()
        {
            return x;
        }

        double getY()
        {
            return y;
        }

        void setN(int n)
        {
            this->n = n;
        }

        void setSide(double side)
        {
            this->side = side;
        }

        void setX(double x)
        {
            this->x = x;
        }

        void setY(double y)
        {
            this->y = y;
        }

        double getPerimeter() const
        {
            return n * side;
        }

        double getArea() const
        {
            return (n * pow(side, 2)) / (4 * tan(M_PI / n));
        }
};

int main()
{
    RegularPolygon polygon1;
    RegularPolygon polygon2(6, 4);
    RegularPolygon polygon3(10, 4, 5.6, 7.8);

    cout << "Polygon 1's perimeter is: " << polygon1.getPerimeter() << endl;
    cout << "Polygon 1's area is: " << polygon1.getArea() << endl;

    cout << "Polygon 2's perimeter is: " << polygon2.getPerimeter() << endl;
    cout << "Polygon 2's area is: " << polygon2.getArea() << endl;

    cout << "Polygon 3's perimeter is: " << polygon3.getPerimeter() << endl;
    cout << "Polygon 3's area is: " << polygon3.getArea() << endl;
}