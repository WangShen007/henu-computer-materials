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

void printMenu()
{
    cout<<"Main menu"<<endl;
    cout<<"1: check balance"<<endl;
    cout<<"2: withdraw"<<endl;
    cout<<"3: deposit"<<endl;
    cout<<"4: exit"<<endl;
    cout<<"Enter a choice: ";
}

void Choose(int choice, Account &account)
{
    switch(choice)
    {
        case 1:
            cout<<"The balance is "<<account.getBalance()<<endl;
            break;
        case 2:
            cout<<"Enter an amount to withdraw: ";
            double amount;
            cin>>amount;
            account.withdraw(amount);
            break;
        case 3:
            cout<<"Enter an amount to deposit: ";
            double aamount;
            cin>>aamount;
            account.deposit(aamount);
            break;
        case 4:
            break;
    }
}



int main()
{
    Account account[10];
    for(int i = 0;i < 10;i++)
    {
        account[i].setId(i);
        account[i].setBalance(100);
    }
    int id;
    do
    {
        do
        {
            cout<<"Enter an id: ";
            cin>>id;
        }while(id < 0 || id > 9);

        cout<<endl;

        int choice;
        do
        {
            printMenu();
            cin>>choice;
            Choose(choice, account[id]);
            cout<<endl;
        } while (choice != 4);

    } while (true);
    
    return 0;
}


















/*
#Program Test : T9_3


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


*/