#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;
double caculate(int sum)
{
    double m = 0;
    for(int i = 1;i <= sum;i++)
    {
        m += pow(-1,i + 1) / ( 2 * i - 1.0);
    }
    m *= 4;
    return m;
}
int main()
{

    int sum;
    sum = 901;
    cout<<left<<setw(10)<<"i"<<"m(i)"<<endl;
    for(int i = 1;i <= sum;i += 100)
    {
        cout<<left<<setw(10)<<fixed<<setprecision(0)<<i<<fixed<<setprecision(4)<<caculate(i)<<endl;
    }
}











/*
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

*/
