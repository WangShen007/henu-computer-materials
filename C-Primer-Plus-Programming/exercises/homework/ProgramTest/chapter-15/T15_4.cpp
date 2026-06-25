#include <iostream>
#include <string>

using namespace std;

class Account
{
private:
    int id;
    double balance;
    double annualInterestRate;
    string dateCreated;
public:
    Account()
    {
        id = 0;
        balance = 0;
        annualInterestRate = 0;
        dateCreated = "dateCreated";
    }
    Account(int id, double balance)
    {
        this->id = id;
        this->balance = balance;
        annualInterestRate = 0;
        dateCreated = "dateCreated";
    }
    int getId() const
    {
        return id;
    }
    double getBalance() const
    {
        return balance;
    }
    double getAnnualInterestRate() const
    {
        return annualInterestRate;
    }
    string getDateCreated() const
    {
        return dateCreated;
    }
    void setId(int id)
    {
        this->id = id;
    }
    void setBalance(double balance)
    {
        this->balance = balance;
    }
    void setAnnualInterestRate(double annualInterestRate)
    {
        this->annualInterestRate = annualInterestRate;
    }
    double getMonthlyInterestRate() const
    {
        return annualInterestRate / 12;
    }
    double getMonthlyInterest() const
    {
        return balance * getMonthlyInterestRate() / 100;
    }
    void withdraw(double amount)
    {
        balance -= amount;
    }
    void deposit(double amount)
    {
        balance += amount;
    }
    virtual string toString() = 0;
};

class SavingsAccount : public Account
{
    private:
        double overdraftLimit;
    public:
        string toString()
        {
            string Sbalance = to_string(getBalance());
            return "Savings Account Balance: " + Sbalance;
        }
};

class CheckingAccount : public Account
{
    private:
        double overdraftLimit;
    public:
        string toString()
        {
            string Cbalance = to_string(getBalance());
            return "Checking Account Balance: " + Cbalance;
        }
};

int main()
{
    Account *a = new SavingsAccount();
    a->setBalance(1000);
    cout << a->toString() << endl;
    a = new CheckingAccount();
    a->setBalance(2000);
    cout << a->toString() << endl;
    return 0;
}