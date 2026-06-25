#include <iostream>
//1 1 0 0
//4.5 -5.5 6.6 -6.5
using namespace std;

int main()
{
    cout << "Enter the coordinates for two points: " ;
    double x1,x2,y1,y2;
    cin>>x1>>y1>>x2>>y2;
    double m,b;
    m = (y2 - y1) / (x2 - x1);
    b = y1 - m * x1;
    cout<<"The line equation for two points ("<<x1<<", "<<y1<<") and ("<<x2<<", "<<y2<<") is y = ";
    if(m == 1)
        cout<<"x ";
    else
        cout<<m<<"x ";
    if(b !=0)
        cout<<b;
}
