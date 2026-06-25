#include <iostream>
#include <cmath>

using namespace std;

class LinearEquation {
private:
    double a, b, c, d, e, f;
public:
    LinearEquation(double a, double b, double c, double d, double e, double f) 
    {
        this->a = a;
        this->b = b;
        this->c = c;
        this->d = d;
        this->e = e;
        this->f = f;
    }
    double getX()
    {
        return (e * d - b * f) / (a * d - b * c);
    }
    double getY()
    {
        return (a * f - e * c) / (a * d - b * c);
    }

    bool isSolvable()
    {
        return (a * d - b * c != 0);
    }

    double getA()
    {
        return a;
    }

    double getB()
    {
        return b;
    }

    double getC()
    {
        return c;
    }

    double getD()
    {
        return d;
    }

    double getE()
    {
        return e;
    }

    double getF()
    {
        return f;
    }

};

int main()
{
    cout<<"Enter the coefficients of the equation: ";
    double a, b, c, d, e, f;
    cin>>a>>b>>c>>d>>e>>f;
    LinearEquation eq(a, b, c, d, e, f);
    cout<<"a = "<<eq.getA()<<", b = "<<eq.getB()<<", c = "<<eq.getC()<<", d = "<<eq.getD()<<", e = "<<eq.getE()<<", f = "<<eq.getF()<<endl;
    if(eq.isSolvable())
    {
        cout<<"x = "<<eq.getX()<<", y = "<<eq.getY()<<endl;
    }
    else
    {
        cout<<"The equation has no solution."<<endl;
    }
}