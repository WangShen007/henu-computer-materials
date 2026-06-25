#include <iostream>
#include <iomanip>
#include <cmath>
#define PI acos(-1)
using namespace std;

int main()
{
    cout << "Enter the length from the center to a vertex: ";
    double length;
    cin>>length;
    double s = 2.0 * length * sin(PI / 5.0);
    double Area = 5 * pow(s,2) / (4.0 * tan(PI / 5.0));
    cout<<"The area of the pentagon is "<<fixed<<setprecision(2)<<Area;
    return 0;
}
