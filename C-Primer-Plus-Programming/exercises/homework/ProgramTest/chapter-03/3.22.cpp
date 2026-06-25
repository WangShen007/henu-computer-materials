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
