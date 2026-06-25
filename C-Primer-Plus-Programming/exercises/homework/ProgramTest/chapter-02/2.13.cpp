#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout << "Enter the monthly saving amount: " ;
    double savingamount;
    cin>>savingamount;
    double yearrate = 0.05,monthrate = yearrate / 12.0;
    double money = 0;
    for(int i = 0;i < 6;i++)
    {
        money += savingamount;
        money = money * (1 + monthrate);
    }
    double m = money;
    m = floor(m * 100.0) / 100.0;
    cout<<"After the sixth month, the account value is $"<<m<<endl;
    return 0;
}
