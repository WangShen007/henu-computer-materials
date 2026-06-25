#include <iostream>
#include <cmath>
using namespace std;
// x1 + width1 / 2.0    y1 + height1 / 2.0
// x2 + width2 / 2.0   y2 - height2 / 2.0
int main()
{
    cout<<"Enter r1's center x-, y-coordinates, width, and height: ";
    double x1,y1,width1,height1;
    cin>>x1>>y1>>width1>>height1;
    cout<<"Enter r2's center x-, y-coordinates, width, and height: ";
    double x2,y2,width2,height2;
    cin>>x2>>y2>>width2>>height2;
    double deltax = abs(x2 - x1),deltay = abs(y2 - y1);
    if(x1 + width1 / 2.0 >= x2 + width2 / 2.0 && x1 - width1 / 2.0 <= x2 - width2 / 2.0 &&
       y1 + height1 / 2.0 >= y2 + height2 / 2.0 && y1 - height1 / 2.0 <= y2 - height2 / 2.0)
        cout<<"r2 is inside r1";
    else if(x1 + width1 / 2.0 <= x2 + width2 / 2.0 && x1 - width1 / 2.0 >= x2 - width2 / 2.0 &&
       y1 + height1 / 2.0 <= y2 + height2 / 2.0 && y1 - height1 / 2.0 >= y2 - height2 / 2.0)
        cout<<"r1 is inside r2";
    else if (  ((x2 + width2 / 2.0 <= x1 + width1 / 2.0 && x2 + width2 / 2.0 >= x1 - width1 / 2.0 && y2 + height2 / 2.0 <= y1 + height1 / 2.0 && y2 + height2 / 2.0 >= y1 - height1 / 2.0)  || //срио╫г
                (x2 + width2 / 2.0 <= x1 + width1 / 2.0 && x2 + width2 / 2.0 >= x1 - width1 / 2.0 && y2 - height2 / 2.0 <= y1 + height1 / 2.0 && y2 - height2 / 2.0 >= y1 - height1 / 2.0)  || //сроб╫г
                (x2 - width2 / 2.0 <= x1 + width1 / 2.0 && x2 - width2 / 2.0 >= x1 - width1 / 2.0 && y2 + height2 / 2.0 <= y1 + height1 / 2.0 && y2 + height2 / 2.0 >= y1 - height1 / 2.0)  || //вСио╫г
                (x2 - width2 / 2.0 <= x1 + width1 / 2.0 && x2 - width2 / 2.0 >= x1 - width1 / 2.0 && y2 - height2 / 2.0 <= y1 + height1 / 2.0 && y2 - height2 / 2.0 >= y1 - height1 / 2.0)) && //вСоб╫г
                (!( (x1 + width1 / 2.0 >= x2 + width2 / 2.0 && x1 - width1 / 2.0 <= x2 - width2 / 2.0 && y1 + height1 / 2.0 >= y2 + height2 / 2.0 && y1 - height1 / 2.0 <= y2 - height2 / 2.0) ||
                    x1 + width1 / 2.0 >= x2 + width2 / 2.0 && x1 - width1 / 2.0 <= x2 - width2 / 2.0 && y1 + height1 / 2.0 >= y2 + height2 / 2.0 && y1 - height1 / 2.0 <= y2 - height2 / 2.0)))
        cout<<"r2 overlaps r1";
    else
        cout<<"r2 does not overlap r1";
}

//2.5 4 2.5 43
//1.5 5 0.5 3

//1 2 3 5.5
//3 4 4.5 5

//1 2 3 3
//40 45 3 2
