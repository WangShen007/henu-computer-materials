#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    int totalnumber = 312032486;
    double birthtime = 1.0 / 7;
    double deadtime = 1.0 / 13;
    double immigrant = 1.0 / 45;
    double year;
    cout<<"Enter the number of years: ";
    cin>>year;
    double x = totalnumber + (birthtime + immigrant - deadtime) * 365.0 * year * (60.0 * 60.0 * 24.0);
    cout<<"The population in "<<fixed<<setprecision(0)<<year<<" years is "<<x;
}
