#include <iostream>
#include <cmath>
#define PI acos(-1)
using namespace std;

int main()
{
    cout << "Enter the side: " ;
    double side;
    cin>>side;
    double Area = 6 * side * side / (4 * tan(PI / 6));
    cout<<"The area of the hexagon is "<<Area;
}
