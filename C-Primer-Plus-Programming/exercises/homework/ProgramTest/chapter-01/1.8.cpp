#include <iostream>
#include <cmath>
#define PI acos(-1)

using namespace std;

int main()
{
    double r = 5.5;
    double c = 2 * PI * r;
    double s = PI * pow(r,2);
    cout<<"周长 = "<<c<<endl;
    cout<<"面积 = "<<s<<endl;
}
