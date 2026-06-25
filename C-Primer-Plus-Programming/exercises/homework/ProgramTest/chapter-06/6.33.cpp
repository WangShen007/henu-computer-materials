#include <iostream>

using namespace std;
void solveEquation
(double a, double b, double c, double d, double e,
 double f, double& x, double& y, bool& isSolvable)
 {
     double delta = a * d - b * c;
     if(delta == 0)
    {
        cout<<"The equation has no solution";
        isSolvable = false;
    }
    else
    {
         x = (e * d - b * f) / delta;
         y = (a * f - e * c) / delta;
         isSolvable = true;
    }
 }
int main()
{
    cout << "Enter a, b, c, d, e, f: ";
    double a,b,c,d,e,f;
    cin>>a>>b>>c>>d>>e>>f;
    double x,y;
    bool isSolvable;
    solveEquation(a,b,c,d,e,f,x,y,isSolvable);
    if(isSolvable)
    {
        cout<<"x is "<<x<<" and y is "<<y;
    }
}


/*
#include <iostream>

using namespace std;
void solveQuadraticEquation
(double a, double b, double c,
double& discriminant, double& r1,double& r2)
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

*/
