#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout << "Enter the temperature in Fahrenheit: ";
    double ta;
    cin>>ta;
    if(ta <= -58 || ta >= 41)
        return 0;
    cout<<"Enter the wind speed in miles per hour: ";
    double v;
    cin>> v;
    double twc = 35.74 + 0.6215 * ta - 35.75 * pow(v,0.16) + 0.4275 * ta * pow(v,0.16);
    cout<<"The wind chill index is "<<twc;
    return 0;
}
