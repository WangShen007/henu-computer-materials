#include <iostream>
#include <iomanip>
#include "Loan.h"
using namespace std;

int main()
{

    cout<<"Enter yearly interest rate, for example 8.25: ";
    double annualInterestRate;
    cin>>annualInterestRate;


    cout<<"Enter number of years as an integer, for example 5: ";
    int numberOfYears;
    cin>>numberOfYears;


    cout<<"Enter loan amount, for example 120000.95: ";
    double loanAmount;
    cin>>loanAmount;


    Loan loan(annualInterestRate, numberOfYears, loanAmount);


    cout<<fixed<<setprecision(2);
    cout<<"The monthly payment is "
        <<loan.getMonthlyPayment()<<endl;
    cout<<"The total payment is "<<loan.getTotalPayment()<<endl;

    return 0;
}
