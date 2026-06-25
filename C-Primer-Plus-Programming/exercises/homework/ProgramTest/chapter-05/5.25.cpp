#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

int main()
{
    int n = 50000;
    double sum1 = 0;
    for(int i = 1;i <= n;i++)
    {
        sum1 += 1.0 / i;
    }

    double sum2 = 0;
    for(int i = n;i >= 1;i--)
    {
        sum2 += 1.0 / i;
    }
    cout<<fixed<<setprecision(50)<<sum1<<endl;
    cout<<sum2<<endl;
}
