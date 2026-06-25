#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout << "Enter x1 and y1: " ;
    double x1,y1,x2,y2;
    cin>>x1>>y1;
    cout << "Enter x2 and y2: " ;
    cin>>x2>>y2;
    cout<<"The distance between the two points is "<<pow(pow((x1 - x2),2)+pow((y1 - y2),2),1.0 / 2);
}
