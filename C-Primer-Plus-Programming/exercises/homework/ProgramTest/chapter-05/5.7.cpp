#include <iostream>
#include <cmath>
#include <iomanip>
#define PI acos(-1)
using namespace std;

int main()
{
    cout <<left<<setw(12)<<"Degree"<<setw(12)<<"Sin"<<setw(12)<<"Cos"<<endl;

    int degree = 0;
    for(int i = 0; i < 37;i++)
    {
        degree =  i * 10;
        cout<<setw(12)<<degree<<setw(12)<<fixed<<setprecision(4)<</*sin(degree * PI / 180.0)*/(abs(sin(degree * PI / 180.0)) < 1e-10 ? 0.0 : sin(degree * PI / 180.0))<<setw(12)<<cos(degree * PI / 180.0)<<endl;
    }
}
//最后一行的sin值为-0.0000而不是0.0000，如何去掉负号
