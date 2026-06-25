#include <iostream>
#include <vector>

using namespace std;

class Date
{
private:
    int year;
    int month;
    int day;
public:
    Date()
    {
        year = 0;
        month = 0;
        day = 0;
    }
    Date(int year, int month, int day)
    {
        this->year = year;
        this->month = month;
        this->day = day;
    }
    int getYear()
    {
        return year;
    }
    int getMonth()
    {
        return month;
    }
    int getDay()
    {
        return day;
    }
    void setDate(int year, int month, int day)
    {
        this->year = year;
        this->month = month;
        this->day = day;
    }

};

class Transaction
{
private:
    Date date;
    char type;
    double amount;
    double balance;
    string description;
public:
    Transaction()
    {
        type = ' ';
        amount = 0;
        balance = 0;
        description = "";
    }
    Transaction(char type, double amount, double balance, string description)
    {
        this->type = type;
        this->amount = amount;
        this->balance = balance;
        this->description = description;
    }
    char getType()
    {
        return type;
    }
    double getAmount()
    {
        return amount;
    }
    double getBalance()
    {
        return balance;
    }
    string getDescription()
    {
        return description;
    }
    void setType(char type)
    {
        this->type = type;
    }
    void setAmount(double amount)
    {
        this->amount = amount;
    }
    void setBalance(double balance)
    {
        this->balance = balance;
    }
    void setDescription(string description)
    {
        this->description = description;
    }
    void setDate(int year, int month, int day)
    {
        date.setDate(year, month, day);
    }
    Date getDate()
    {
        return date;
    }
};

class Account
{
private:
    string name;
    static double annualInterestRate;
    double balance;
    vector<Transaction> transactions;
    string id;
public:
    Account()
    {
        name = "";
        balance = 0;
        id = "";
    }
    Account(string name, double balance, string id)
    {
        this->name = name;
        this->balance = balance;
        this->id = id;
    }
    string getName()
    {
        return name;
    }
    double getBalance()
    {
        return balance;
    }
    string getId()
    {
        return id;
    }
    void setName(string name)
    {
        this->name = name;
    }
    void setBalance(double balance)
    {
        this->balance = balance;
    }
    void setId(string id)
    {
        this->id = id;
    }
    static void setAnnualInterestRate(double rate)
    {
        annualInterestRate = rate;
    }
    double getMonthlyInterestRate()
    {
        return annualInterestRate / 12;
    }
    double getMonthlyInterest()
    {
        return balance * getMonthlyInterestRate();
    }
    void withdraw(double amount)
    {
        balance -= amount;
        transactions.push_back(Transaction('W', amount, balance, "Withdrawal"));
    }
    void deposit(double amount)
    {
        balance += amount;
        transactions.push_back(Transaction('D', amount, balance, "Deposit"));
    }
    vector<Transaction> getTransactions()
    {
        return transactions;
    }
    double getAnnualInterestRate()
    {
        return annualInterestRate;
    }
};

double Account::annualInterestRate = 1.5;

int main()
{
    Account account("George", 1122, "12345");
    Account::setAnnualInterestRate(1.5);
    account.deposit(30);
    account.deposit(40);
    account.deposit(50);
    account.withdraw(5);
    account.withdraw(4);
    account.withdraw(2);
    cout << "Name: " << account.getName() << endl;
    cout << "Annual Interest Rate: " << account.getAnnualInterestRate() << endl;
    cout << "Balance: " << account.getBalance() << endl;
    cout << "Monthly Interest: " << account.getMonthlyInterest() << endl;
    cout << "Transactions: " << endl;
    vector<Transaction> transactions = account.getTransactions();
    for (int i = 0; i < transactions.size(); i++)
    {
        cout << "Date: " << transactions[i].getDate().getYear() << "/" << transactions[i].getDate().getMonth() << "/" << transactions[i].getDate().getDay() << endl;
        cout << "Type: " << transactions[i].getType() << endl;
        cout << "Amount: " << transactions[i].getAmount() << endl;
        cout << "Balance: " << transactions[i].getBalance() << endl;
        cout << "Description: " << transactions[i].getDescription() << endl;
    }
    return 0;
}