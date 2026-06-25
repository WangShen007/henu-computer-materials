#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;
double futureInvestmentValue(double investmentAmount, double monthlyTnterestRate, int years)
{
    double value = investmentAmount * pow((1 + monthlyTnterestRate),years * 12);
    return value;
}
int main()
{
    cout<<"The amount invested: ";
    double investmentAmount;
    cin>>investmentAmount;
    cout<<"Annual interest rate: ";
    double annualInterestRate;
    cin>>annualInterestRate;

    cout<<"Years"<<"     "<<"Future Value"<<endl;
    for(int i = 1;i <= 30;i++)
    {
        cout<<left<<setw(10)<<i<<fixed<<setprecision(2)<<futureInvestmentValue(investmentAmount, annualInterestRate / 1200.0 , i)<<endl;
    }
}


/*
#include <iostream>
#include <cmath>
#include <math.h>

using namespace std;

int main()
{
    cout << "Enter investment amount: " ;
    double value,investmentamount,annualinterestrate,years;
    cin>>investmentamount;
    cout<<"Enter annual interest rate in percentage: ";
    cin>>annualinterestrate;
    cout<<"Enter number of years: ";
    cin>>years;
    value = investmentamount * pow((1 + annualinterestrate / 1200.0),years * 12);
    //value = floor(value * 100.0) / 100.0;
    cout<<"Accumulated value is $"<<value<<endl;
}

*/
