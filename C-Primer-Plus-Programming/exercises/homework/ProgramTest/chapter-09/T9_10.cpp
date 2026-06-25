#include <iostream>

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
    const double Epison = 1e-16;
    double x1,x2,x3,x4,y1,y2,y3,y4,x,y;
    cout << "Enter x1, y1, x2, y2,x3, y3, x4, y4: ";
    cin>>x1>>y1>>x2>>y2>>x3>>y3>>x4>>y4;
    double a = y1 - y2,b = x2 - x1,e = (y1 - y2) * x1 - (x1 - x2) * y1,
           c = y3 - y4,d = x4 - x3,f = (y3 - y4) * x3 - (x3 - x4) * y3;
    LinearEquation l(a,b,e,c,d,f);
    if(l.isSolvable())
    {
        x = l.getX();
        y = l.getY();
        cout<<"The interesting point is at ("<<x<<", "<<y<<")"<<endl;
    }
    else
        cout<<"The two lines are parallel"<<endl;
        
}


/*
#Program Test 3.22

#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    const double Epison = 1e-16;
    double x1,x2,x3,x4,y1,y2,y3,y4,x,y;
    cout << "Enter x1, y1, x2, y2,x3, y3, x4, y4: ";
    cin>>x1>>y1>>x2>>y2>>x3>>y3>>x4>>y4;
    double a = y1 - y2,b = x2 - x1,e = (y1 - y2) * x1 - (x1 - x2) * y1,
           c = y3 - y4,d = x4 - x3,f = (y3 - y4) * x3 - (x3 - x4) * y3;
    double delta = a * d - b * c;
    if(abs(delta) <= Epison)
        cout<<"The two lines are parallel"<<endl;
    else
    {
        x = (e * d - b * f) / delta;
        y = (a * f - e * c) / delta;
        cout<<"The interesting point is at ("<<x<<", "<<y<<")"<<endl;
    }
}
//2 2 7 6.0 4.0 2.0 -1.0 -2.0

*/