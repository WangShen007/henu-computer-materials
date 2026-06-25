#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    double x,y;
    cout<<"Enter a point with two coordinates: ";
    cin>>x>>y;
    double deltax = abs(x),deltay = abs(y);
    if(deltax <= 10.0 / 2 && deltay <= 5.0 / 2)
        cout<<"Point ("<<x<<", "<<y<<") is in the rectangle";
    else
        cout<<"Point ("<<x<<", "<<y<<") is not in the rectangle";
}
