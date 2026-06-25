#include <iostream>
#include <cmath>
using namespace std;
bool isValid(double side1, double side2, double side3)
{
    if(side1 + side2 > side3 && side3 + side2 >side1 && side1 + side3 > side2)
        return true;
    return false;
}

double area(double side1, double side2, double side3)
{
    double s = (side1 + side2 + side3) / 2.0;
    double area = sqrt(s * (s - side1) * (s - side2) * (s - side3));
    return area;
}

int main()
{
    cout<<"Enter three sides: ";
    double s1, s2, s3;
    cin>>s1>>s2>>s3;
    if(isValid(s1, s2, s3))
    {
        cout<<"The area is "<<area(s1,s2,s3)<<endl;
    }
    else
    {
        cout<<"Invalid input";
    }
}


/*
#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout<<"Enter three points for a triangle: ";
    double x1,y1,x2,y2,x3,y3;
    cin>>x1>>y1>>x2>>y2>>x3>>y3;
    double side1 = sqrt(pow((x1 - x2),2)+pow((y1 - y2),2));
    double side2 = sqrt(pow((x1 - x3),2)+pow((y1 - y3),2));
    double side3 = sqrt(pow((x3 - x2),2)+pow((y3 - y2),2));
    double s = (side1 + side2 + side3) / 2.0;
    double area = sqrt(s * (s - side1) * (s - side2) * (s - side3));
    cout<<"The area of the triangle is "<<area<<endl;
}

*/
