#include <iostream>
#include <cmath>
using namespace std;
void solveQuadraticEquation
(double a, double b, double c,
double& discriminant, double& r1,double& r2)
{
    if(discriminant > 0)
    {
        r1 = (-b + sqrt(discriminant)) / (2 * a);
        r2 = (-b - sqrt(discriminant)) / (2 * a);
        cout<<"r1 = "<<r1<<endl
            <<"r2 = "<<r2<<endl;
    }
    else if(discriminant == 0)
    {
        r1 = -b / (2 * a);
        cout<<"r1 = r2 = "<<r1<<endl;
    }
    else
    {
        cout<<"The equation has no solution";
    }
}
int main()
{
    cout<<"Enter a, b, c: ";
    double a, b, c;
    cin>>a>>b>>c;
    double delta = b * b - 4 * a * c;
    double r1, r2;
    solveQuadraticEquation(a,b,c,delta,r1,r2);
}
