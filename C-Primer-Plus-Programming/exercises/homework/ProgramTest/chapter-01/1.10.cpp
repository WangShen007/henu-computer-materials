#include <iostream>

using namespace std;

int main()
{
    double s = 30.0;
    double minu = 45.0;
    double time = s / 60.0 / 60.0 + minu / 60.0;
    double v1 = 14 / time;
    double v2 = v1 / 1.6;
    cout<<v2<<endl;
}
