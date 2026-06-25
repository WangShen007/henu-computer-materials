#include <iostream>

using namespace std;

int main()
{
    cout << "Enter a, b, c, d, e, f: ";
    double a,b,c,d,e,f;
    cin>>a>>b>>c>>d>>e>>f;
    double delta = a * d - b * c;
    if(delta == 0)
    {
        cout<<"The equation has no solution";
    }
    else
    {
        double x = (e * d - b * f) / delta;
        double y = (a * f - e * c) / delta;
        cout<<"x is "<<x<<" and y is "<<y;
    }
}
