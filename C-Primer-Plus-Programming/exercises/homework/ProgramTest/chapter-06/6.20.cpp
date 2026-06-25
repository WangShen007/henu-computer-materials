#include <iostream>
#include <algorithm>
using namespace std;

//1 1 2 2 1.5 1.5
//1 1 2 2 3 3
//1 1 2 2 1 1.5
//1 1 2 2 1 -1
bool leftOnTheLine(double x0,double y0,double x1,double y1,double x2,double y2)
{
    double delta = (x1 - x0) * (y2 - y0) - (x2 - x0) * (y1 - y0);
    if(delta > 0)
        return true;
    return false;
}

bool onTheSameLine(double x0,double y0,double x1,double y1,double x2,double y2)
{
    double delta = (x1 - x0) * (y2 - y0) - (x2 - x0) * (y1 - y0);
    if(delta == 0)
        return true;
    return false;
}

bool onTheLineSegment(double x0,double y0,double x1,double y1,double x2,double y2)
{
    double delta = (x1 - x0) * (y2 - y0) - (x2 - x0) * (y1 - y0);
    if(delta == 0 && x2 >= min(x0,x1) && x2 <= max(x0,x1) && y2 >= min(y0,y1) && y2 <= max(y0,y1))
        return true;
    return false;
}

int main()
{
    cout << "Enter three points for p0, p1, and p2: " ;
    double x0,y0,x1,y1,x2,y2;
    cin>>x0>>y0>>x1>>y1>>x2>>y2;
    if(onTheLineSegment(x0,y0,x1,y1,x2,y2))
    {
        cout<<"("<<x2<<", "<<y2<<") is on the line segment from ("<<x0<<", "<<y0<<") to ("<<x1<<", "<<y1<<")"<<endl;
    }
    else if(leftOnTheLine(x0,y0,x1,y1,x2,y2))
    {
        cout<<"("<<x2<<", "<<y2<<") is left on the line from ("<<x0<<", "<<y0<<") to ("<<x1<<", "<<y1<<")"<<endl;
    }
    else if(onTheSameLine(x0,y0,x1,y1,x2,y2))
    {
        cout<<"("<<x2<<", "<<y2<<") is on the same line from ("<<x0<<", "<<y0<<") to ("<<x1<<", "<<y1<<")"<<endl;
    }
    else
    {
        cout<<"("<<x2<<", "<<y2<<") is right on the line from ("<<x0<<", "<<y0<<") to ("<<x1<<", "<<y1<<")"<<endl;
    }
}


/*
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

*/
