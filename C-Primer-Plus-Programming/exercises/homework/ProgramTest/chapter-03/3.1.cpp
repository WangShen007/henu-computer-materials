#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout << "Enter a, b, c: " ;
    double a,b,c;
    cin>>a>>b>>c;
    double delta = sqrt(b * b - 4 * a * c);
    double panbie = b * b - 4 * a * c;
    if(panbie < 0)
    {
        cout<<"The equation has no real roots";
    }
    else if(panbie == 0)
    {
        double x = -b / (2 * a);
        cout<<"The root is "<<x;
    }
    else
    {
        double x1 = (-b + delta) / (2 * a),x2 = (-b - delta) / (2 * a);
        cout<<"The roots are "<<x1<<" and "<<x2;
    }
}
