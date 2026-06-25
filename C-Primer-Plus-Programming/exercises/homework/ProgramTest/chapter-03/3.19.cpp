#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    double x,y;
    cout<<"Enter a point with two coordinates: ";
    cin>>x>>y;
    double distance = sqrt(x * x + y * y);
    if(distance <= 10)
        cout<<"Point ("<<x<<", "<<y<<") is in the circle";
    else
        cout<<"Point ("<<x<<", "<<y<<") is not in the circle";
}
