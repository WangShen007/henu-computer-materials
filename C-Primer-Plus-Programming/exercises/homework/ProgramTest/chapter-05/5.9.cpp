#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    double money = 10000.0;
    for(int i = 0;i < 10;i++)
    {
        money = money * (1 + 0.05);
        cout<<money <<endl;
    }
}
