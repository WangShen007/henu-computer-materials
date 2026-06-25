#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    cout <<left;
    int a;
    cout<<setw(6)<<"a"<<setw(6)<<"a^2"<<setw(3)<<"a^3"<<endl;
    a = 1;
    cout<<setw(6)<<a<<setw(6)<<a*a<<setw(3)<<pow(a,3)<<endl;
    a = 2;
    cout<<setw(6)<<a<<setw(6)<<a*a<<setw(3)<<pow(a,3)<<endl;
    a = 3;
    cout<<setw(6)<<a<<setw(6)<<a*a<<setw(3)<<pow(a,3)<<endl;
    a = 4;
    cout<<setw(6)<<a<<setw(6)<<a*a<<setw(3)<<pow(a,3)<<endl;
    return 0;
}
