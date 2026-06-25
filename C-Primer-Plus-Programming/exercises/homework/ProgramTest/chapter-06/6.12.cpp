#include <iostream>
#include <iomanip>
using namespace std;
double caculate(int sum)
{
    double m = 0;
    for(int i = 1;i <= sum;i++)
    {
        m += i / (i + 1.0);
    }
    return m;
}
int main()
{

    cout<<"Enter sum: ";
    int sum;
    cin>>sum;
    cout<<left<<setw(10)<<"i"<<"m(i)"<<endl;
    for(int i = 1;i <= sum;i++)
    {
        cout<<left<<setw(10)<<fixed<<setprecision(0)<<i<<fixed<<setprecision(4)<<caculate(i)<<endl;
    }
}
