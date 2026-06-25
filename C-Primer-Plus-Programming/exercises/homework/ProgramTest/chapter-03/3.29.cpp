#include <iostream>

using namespace std;
//4.4 2 6.5 9.5 -5 4
//1 1 5 5 2 2
//3.4 2 6.5 9.5 5 2.5
int main()
{
    cout << "Enter three points for p0, p1, and p2: " ;
    double x0,y0,x1,y1,x2,y2;
    cin>>x0>>y0>>x1>>y1>>x2>>y2;
    double delta = (x1 - x0) * (y2 - y0) - (x2 - x0) * (y1 - y0);
    cout<<"p2 is on the ";
    if(delta == 0)
    {
        cout<<"same line";
    }
    else if(delta < 0)
        cout<<"right side of the line";
    else
        cout<<"left side of the line";
}
