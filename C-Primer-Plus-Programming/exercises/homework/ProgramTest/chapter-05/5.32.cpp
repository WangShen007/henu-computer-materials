#include <iostream>

using namespace std;

int main()
{
    double monthMoney;
    double annualInterestRate;
    int month;

    cout<<"Enter the monthly money: ";
    cin>>monthMoney;

    cout<<"Enter the annual interest rate: ";
    cin>>annualInterestRate;

    cout<<"Enter the month: ";
    cin>>month;

    double monthRate = annualInterestRate / 1200.0;
    double sum = 0;
    for(int i = 1;i <= month;i++)
    {
        sum += monthMoney;
        sum *= (1 + monthRate);
    }
    cout<<sum<<endl;
}
