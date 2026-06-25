#include <cmath>
#include <iostream>
using namespace std;

#ifndef LOAN_H
#define LOAN_H

class Loan
{
public:
    Loan();
    Loan(double rate, int years, double amount);
    double getAnnualInterestRate();
    int getNumberOfYears();
    double getLoanAmount();
    void setAnnualInterestRate(double rate);
    void setNumberOfYears(int years);
    void setLoanAmount(double amount);
    double getMonthlyPayment();
    double getTotalPayment();
    static double getMonthlyPayment(double annualInterestRate, int numberOfYears, double loanAmount);
    static double getTotalPayment(double annualInterestRate, int numberOfYears, double loanAmount);

private:
    double annualInterestRate;
    int numberOfYears;
    double loanAmount;
};

#endif // LOAN_H

Loan::Loan()
{
    annualInterestRate = 9.5;
    numberOfYears = 30;
    loanAmount = 100000;
}

Loan::Loan(double rate, int years, double amount)
{
    annualInterestRate = rate;
    numberOfYears = years;
    loanAmount = amount;
}

double Loan::getAnnualInterestRate()
{
    return annualInterestRate;
}

int Loan::getNumberOfYears()
{
    return numberOfYears;
}

double Loan::getLoanAmount()
{
    return loanAmount;
}

void Loan::setAnnualInterestRate(double rate)
{
    annualInterestRate = rate;
}

void Loan::setNumberOfYears(int years)
{
    numberOfYears = years;
}

void Loan::setLoanAmount(double amount)
{
    loanAmount = amount;
}

double Loan::getMonthlyPayment()
{
    double monthlyInterestRate = annualInterestRate / 1200;
    return loanAmount * monthlyInterestRate / (1 -
        (pow(1 / (1 + monthlyInterestRate), numberOfYears * 12)));
}

double Loan::getTotalPayment()
{
    return getMonthlyPayment() * numberOfYears * 12;
}

double Loan::getMonthlyPayment(double annualInterestRate, int numberOfYears, double loanAmount)
{
    double monthlyInterestRate = annualInterestRate / 1200;
    return loanAmount * monthlyInterestRate / (1 -
        (pow(1 / (1 + monthlyInterestRate), numberOfYears * 12)));
}

double Loan::getTotalPayment(double annualInterestRate, int numberOfYears, double loanAmount)
{
    return getMonthlyPayment(annualInterestRate, numberOfYears, loanAmount) * numberOfYears * 12;
}

int main()
{
    Loan loan1(7.5, 30, 100000);
    cout << "The loan was created on " << loan1.getLoanAmount() << " for " << loan1.getNumberOfYears() << " years at " << loan1.getAnnualInterestRate() << "%." << endl;
    cout << "The monthly payment is " << loan1.getMonthlyPayment() << endl;
    cout << "The total payment is " << loan1.getTotalPayment() << endl;

    return 0;
}














/*
#9-13 Loan.cpp

#include "Loan.h"
#include <cmath>
using namespace std;

Loan::Loan()
{
    annualInterestRate = 9.5;
    numberOfYears = 30;
    loanAmount = 100000;
}

Loan::Loan(double rate, int years, double amount)
{
    annualInterestRate = rate;
    numberOfYears = years;
    loanAmount = amount;
}

double Loan::getAnnualInterestRate()
{
    return annualInterestRate;
}

int Loan::getNumberOfYears()
{
    return numberOfYears;
}

double Loan::getLoanAmount()
{
    return loanAmount;
}

void Loan::setAnnualInterestRate(double rate)
{
    annualInterestRate = rate;
}

void Loan::setNumberOfYears(int years)
{
    numberOfYears = years;
}

void Loan::setLoanAmount(double amount)
{
    loanAmount = amount;
}

double Loan::getMonthlyPayment()
{
    double monthlyInterestRate = annualInterestRate / 1200;
    return loanAmount * monthlyInterestRate / (1 -
        (pow(1 / (1 + monthlyInterestRate), numberOfYears * 12)));
}

double Loan::getTotalPayment()
{
    return getMonthlyPayment() * numberOfYears * 12;
}



#9-13 Loan.h

#ifndef LOAN_H
#define LOAN_H

class Loan
{
public:
    Loan();
    Loan(double rate, int years, double amount);
    double getAnnualInterestRate();
    int getNumberOfYears();
    double getLoanAmount();
    void setAnnualInterestRate(double rate);
    void setNumberOfYears(int years);
    void setLoanAmount(double amount);
    double getMonthlyPayment();
    double getTotalPayment();

private:
    double annualInterestRate;
    int numberOfYears;
    double loanAmount;
};

#endif // LOAN_H


*/