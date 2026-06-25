#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    int totalnumber = 312032486;
    double birthtime = 1.0 / 7;
    double deadtime = 1.0 / 13;
    double immigrant = 1.0 / 45;
    double x = totalnumber + (birthtime + immigrant - deadtime) * 365.0 * 5.0 * 60.0 * 60.0 * 24.0;
    cout<<fixed<<setprecision(0)<<x;
}
