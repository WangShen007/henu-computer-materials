#include <iostream>
#include <cmath>

using namespace std;
/*
2.0 2.0 0 0
0 2.0 2.0 0

2.0 2.0 0 0
3 3 1 1

*/
void intersectPoint(double x1, double y1, double x2, double y2, double x3, double y3,
                    double x4, double y4, double& x, double& y, bool& isintersecting)
{
    const double Epison = 1e-16;
    double a = y1 - y2,b = x2 - x1,e = (y1 - y2) * x1 - (x1 - x2) * y1,
           c = y3 - y4,d = x4 - x3,f = (y3 - y4) * x3 - (x3 - x4) * y3;
    double delta = a * d - b * c;
    if(abs(delta) <= Epison)
        //cout<<"The two lines are parallel"<<endl;
        {
            isintersecting = false;
        }
    else
    {
        x = (e * d - b * f) / delta;
        y = (a * f - e * c) / delta;
        //cout<<"The interesting point is at ("<<x<<", "<<y<<")"<<endl;
        isintersecting = true;
    }
}


int main()
{
    cout<<"Enter the endpoints of the first line segment: ";
    double x1, x2, x3, x4, y1, y2, y3, y4;
    cin>>x1>>y1>>x2>>y2;

    cout<<"Enter the endpoints of the second line segment: ";
    cin>>x3>>y3>>x4>>y4;

    double x, y;
    bool isintersecting;

    intersectPoint(x1, y1, x2, y2, x3, y3, x4, y4, x, y, isintersecting);

    if(isintersecting)
    {
        cout<<"The intersecting point is: ";
        cout<<"("<<x<<", "<<y<<")"<<endl;
    }
    else
    {
        cout<<"The two lines do not cross"<<endl;
    }

    return 0;
}


/*
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
//2 2 7 6.0 4.0 2.0 -1.0 -2.
*/
