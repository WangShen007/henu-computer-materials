#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    double money = 10000.0;
    double a[10];
    for(int i = 0;i < 10;i++)
    {
        money = money * (1 + 0.05);
        a[i] = money;
    }

    for(int i = 0;i < 7;i++)
    {
        double sum = 0;
        for(int j = i;j < i + 4;j++)
        {
            sum += a[j];
        }
        cout<<sum<<endl;
    }
}
