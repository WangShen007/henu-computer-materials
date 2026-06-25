#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    cout<<left<<setw(6)<<"a"<<setw(6)<<"b"<<setw(6)<<"pow(a,b)"<<endl;
    int a = 1,b = 2;
    for(int i = 0;i < 5;i++)
    {
        cout<<left<<setw(6)<<a<<setw(6)<<b<<setw(6)<<pow(a,b)<<endl;
        a++;
        b++;
    }
}
