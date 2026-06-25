#include <iostream>
#include <cmath>
#define PI acos(-1)
using namespace std;

int main()
{
    cout << "Enter the number of sides: ";
    int n;
    cin>>n;
    cout<<"Enter the sides: ";
    double s;
    cin>>s;
    double Area = n * s * s / (4 * tan(PI / n));
    cout<<"The area of the polygon is "<<Area;
}
