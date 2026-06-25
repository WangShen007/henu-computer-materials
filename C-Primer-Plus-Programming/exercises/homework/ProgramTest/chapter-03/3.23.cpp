#include <iostream>

using namespace std;

int main()
{
    cout << "Enter a point's x- and y-coordinates: " ;
    double x,y;
    cin>>x>>y;
    //y=-0.5x+100
    if(x >= 0 && x <= 200 && y >= 0 && y <= 100 && 0.5 * x + y - 100 <= 0)
        cout<<"The point is in the triangle";
    else
        cout<<"The point is not in the triangle";
}
