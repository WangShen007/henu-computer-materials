#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    cout<<"Enter the initial deposit amount: ";
    double initialDepositAmount;
    cin>>initialDepositAmount;

    cout<<"Enter annual percentage yield: ";
    double annualPercentageYield;
    cin>>annualPercentageYield;

    cout<<"Enter maturity period (number of months): ";
    int month;
    cin>>month;

    double monthRate = annualPercentageYield / 1200.0;
    double money = initialDepositAmount;

    cout<<"Month"<<" "<<"CD Value"<<endl;

    for(int i = 1;i <= 18;i++)
    {
        money *= (1 + monthRate);
        //money = static_cast<int>(money * 100) / 100.0;
        cout<<left<<setw(6)<<i<<fixed<<setprecision(2)<<money<<endl;
    }
}
/*
10000
5.75
18


monthlyPayment = static_cast<int>(monthlyPayment * 100) / 100.0;
*/
