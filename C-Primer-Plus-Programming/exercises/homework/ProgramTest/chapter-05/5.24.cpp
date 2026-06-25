#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    cout << "Loan Amount: ";
    double loanAmount;
    cin>>loanAmount;

    cout<<"Number of Years: ";
    int years;
    cin>>years;

    cout<<"Annual Interest Rate: ";
    double annualInterestRate;
    cin>>annualInterestRate;

    double monthlyInterestRate = annualInterestRate / 1200;
    double monthlyPayment = loanAmount * monthlyInterestRate / (1 - 1 / pow(1 + monthlyInterestRate, years * 12));
    monthlyPayment = static_cast<int>(monthlyPayment * 100) / 100.0;
    cout<<"Monthly Payment: "<<fixed<<setprecision(2)<<monthlyPayment<<endl;

    double totalPayment = monthlyPayment * years * 12;
    totalPayment = static_cast<int>(totalPayment * 100) / 100.0;
    cout<<"Total Payment: "<<totalPayment<<endl;

    cout<<"Payment#"<<"\t"<<"Interest"<<"\t"<<"Principal"<<"\t"<<"Balance"<<endl;

    double balance = loanAmount;
    for(int i = 1;i <= years * 12;i++)
    {
        double interest = balance * monthlyInterestRate;
        double principal = monthlyPayment - interest;
        balance = balance - principal;
        cout<<i<<"\t\t"<<interest<<"\t\t"<<principal<<"\t\t"<<balance<<endl;
    }
}























/*
#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    cout << "Loan Amount: ";
    double loanAmount;
    cin>>loanAmount;

    cout<<"Number of Years: ";
    int years;
    cin>>years;

    cout<<"Interest Rate"<<"    "<<"Monthly Payment"<<"    "<<"Total Payment"<<endl;

    double annualInterestRate;
    double addrate = 1 / 8.0;
//    double monthlyInterestRate = annualInterestRate / 1200;
//    double monthlyPayment = loanAmount * monthlyInterestRate / (1 - 1 / pow(1 + monthlyInterestRate, years * 12));
//    double totalPayment = monthlyPayment * years * 12;
//    monthlyPayment = static_cast<int>(monthlyPayment * 100) / 100.0;
//    totalPayment = static_cast<int>(totalPayment * 100) / 100.0;
    for(int i = 0;i < 25;i++)
    {
        annualInterestRate = 5.000 + i * addrate;
        double monthlyInterestRate = annualInterestRate / 1200;
        double monthlyPayment = loanAmount * monthlyInterestRate / (1 - 1 / pow(1 + monthlyInterestRate, years * 12));
        double totalPayment = monthlyPayment * years * 12;
        monthlyPayment = static_cast<int>(monthlyPayment * 100) / 100.0;
        totalPayment = static_cast<int>(totalPayment * 100) / 100.0;
        cout<<fixed<<setprecision(3)/*<<left<<setw(17)*//*<</*annualInterestRate * pow((1 + addrate),i)*//*annualInterestRate
        <<"%"<<"           "<<fixed<<setprecision(2)<<monthlyPayment<<"             "<<totalPayment<<endl;
    }
}



#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    cout<<"Enter yearly interest rate, for example 8.25: ";
    double annualInterestRate;
    cin>>annualInterestRate;

    double monthlyInterestRate = annualInterestRate / 1200;


    cout<<"Enter number of years as an integer, for example 5: ";
    int numberOfYears;
    cin>>numberOfYears;

    cout<<"Enter loan amount, for example 120000.95: ";
    double loanAmount;
    cin>>loanAmount;

    double monthlyPayment = loanAmount * monthlyInterestRate / (1 - 1 / pow(1 + monthlyInterestRate, numberOfYears * 12));
    double totalPayment = monthlyPayment * numberOfYears * 12;

    monthlyPayment = static_cast<int>(monthlyPayment * 100) / 100.0;
    totalPayment = static_cast<int>(totalPayment * 100) / 100.0;

    cout<<"The monthly payment is "<<monthlyPayment<<endl<<
    "The total payment is "<<totalPayment<<endl;

    return 0;
}


//3
//5
//1000
*/
