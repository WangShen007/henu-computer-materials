#include <iostream>
using namespace std;

#ifndef ACCOUNT_H
#define ACCOUNT_H

class Account
{
public:
    int id;
    double balance;
    double annualInterestRate;
    Account();
    int getId();
    double getBalance();
    double getAnnualInterestRate();
    void setId(int newId);
    void setBalance(double newBalance);
    void setAnnualInterestRate(double newAnnualInterestRate);
    double getMonthlyInterestRate();
    void withdraw(double amount);
    void deposit(double amount);
};

#endif // ACCOUNT_H

Account::Account()
{
    id = 0;
    balance = 0;
    annualInterestRate = 0;
}

int Account::getId()
{
    return id;
}

double Account::getBalance()
{
    return balance;
}

double Account::getAnnualInterestRate()
{
    return annualInterestRate;
}

void Account::setId(int newId)
{
    id = newId;
}

void Account::setBalance(double newBalance)
{
    balance = newBalance;
}

void Account::setAnnualInterestRate(double newAnnualInterestRate)
{
    annualInterestRate = newAnnualInterestRate;
}

double Account::getMonthlyInterestRate()
{
    return annualInterestRate / 12;
}

void Account::withdraw(double amount)
{
    balance -= amount;
}

void Account::deposit(double amount)
{
    balance += amount;
}

int main()
{
    Account account;
    account.setId(1122);
    account.setAnnualInterestRate(4.5);
    account.setBalance(20000);
    account.withdraw(2500);
    account.deposit(3000);
    cout<<"Balance: "<<account.getBalance()<<endl;
    cout<<"Monthly Interest Rate:"<<account.getMonthlyInterestRate()<<endl;
}
