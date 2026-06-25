#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout<<"Enter circle1's center x-, y-coordinates, and radius: ";
    double x1,x2,y1,y2,r1,r2;
    cin>>x1>>y1>>r1;

    cout<<"Enter circle2's center x-, y-coordinates, and radius: ";
    cin>>x2>>y2>>r2;

    double distance = sqrt(pow(x1 - x2,2) + pow(y1 - y2,2));

    if(distance <= abs(r1 - r2))
    {
        if(r1 > r2)
            cout<<"circle2 is inside circle1";
        else
            cout<<"circle1 is inside circle2";
    }
    else if(distance <= r1 + r2)
        cout<<"circle1 overlaps circle2";
    else
        cout<<"circle1 is away from circle2";

}
//0.5 5.1 13
//1 1.7 4.5

//3.4 5.5 1
//6.7 3.5 3

//3.4 5.5 1
//5.5 7.2 1
