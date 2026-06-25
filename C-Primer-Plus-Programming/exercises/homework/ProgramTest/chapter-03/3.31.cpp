#include <iostream>
#include <algorithm>
//1 1 2.5 2.5 1.5 1.5
//1 1 2 2 3.5 3.5
using namespace std;
int main()
{
    cout << "Enter three points for p0, p1, and p2: " ;
    double x0,y0,x1,y1,x2,y2;
    cin>>x0>>y0>>x1>>y1>>x2>>y2;
    double delta = (x1 - x0) * (y2 - y0) - (x2 - x0) * (y1 - y0);
    if(delta == 0 && x2 >= min(x0,x1) && x2 <= max(x0,x1) && y2 >= min(y0,y1) && y2 <= max(y0,y1))
        cout<<"("<<x2<<", "<<y2<<") is on the line segment from ("<<x0<<", "<<y0<<") to ("<<x1<<", "<<y1<<")";
    else
        cout<<"("<<x2<<", "<<y2<<") is not on the line segment from ("<<x0<<", "<<y0<<") to ("<<x1<<", "<<y1<<")";
}
