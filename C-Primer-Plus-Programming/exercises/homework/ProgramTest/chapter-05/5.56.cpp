#include <iostream>
#include <cmath>
#define PI acos(-1)
using namespace std;

int main()
{
    cout<<"Enter the number of the sides: ";
    int numberOfSides;
    cin>>numberOfSides;

    cout<<"Enter the radius of the bounding circle: ";
    int radius;
    cin>>radius;

    cout<<"The coordinates of the points on the polygon are"<<endl;
    double perDegree = 360.0 / numberOfSides * PI / 180.0;
    for(int i = 0;i < numberOfSides;i++)
    {
        double degree = i * perDegree ;
        cout<<"("<<cos(degree) * radius<<", "<<sin(degree) * radius<<")"<<endl;
    }
}
