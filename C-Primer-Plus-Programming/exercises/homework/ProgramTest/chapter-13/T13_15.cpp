#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;

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


void test01()
{
    Loan loans[5] =
    {
    Loan(5.0, 5, 10000),
    Loan(),
    Loan(10.0, 15, 30000),
    Loan(),
    Loan(15.0, 25, 50000)
    };

    ofstream ofs;
    ofs.open("Exercise13_15.dat", ios::out | ios::binary);
    if (!ofs)
    {
        cerr << "Error opening file for output" << endl;
        return;
    }

    for (int i = 0; i < 5; i++) {
        ofs.write((const char *)&loans[i], sizeof(loans[i]));
    }

    ofs.close();
}

void test02()
{
    ifstream ifs;
    ifs.open("Exercise13_15.dat", ios::in | ios::binary);
    if (!ifs)
    {
        cerr << "Error opening file for input" << endl;
        return;
    }
        Loan loan;
        while(ifs.read((char *)&loan, sizeof(loan)))
        {
            cout << "Annual Interest Rate: " << loan.getAnnualInterestRate() << endl;
            cout << "Number of Years: " << loan.getNumberOfYears() << endl;
            cout << "Loan Amount: " << loan.getLoanAmount() << endl;
            cout << "Monthly Payment: " << loan.getMonthlyPayment() << endl;
            cout << "Total Payment: " << loan.getTotalPayment() << endl;
            cout << endl;
        }
}

double sum()
{
    ifstream ifs;
    ifs.open("Exercise13_15.dat", ios::in | ios::binary);
    if (!ifs)
    {
        cerr << "Error opening file for input" << endl;
        return 0;
    }
    Loan loan;
    double total = 0;
    while(ifs.read((char *)&loan, sizeof(loan)))
    {
        total += loan.getLoanAmount();
    }
    ifs.close();
    return total;
}

int main()
{
    test01();
    //test02();
    cout << "The total loan amount is " << sum() << endl;
    return 0;

}