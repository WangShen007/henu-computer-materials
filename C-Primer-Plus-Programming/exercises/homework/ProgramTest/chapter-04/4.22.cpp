#include <iostream>
#include <string>
#include <iomanip>
#include <cstdlib>
using namespace std;

int main()
{
    cout<<"Enter employee's name: ";
    string name;
    getline(cin, name);

    cout<<"Enter number of hours worked in a week: ";
    double hours;
    cin>>hours;

    cout<<"Enter hourly pay rate: ";
    double hourlyPayRate;
    cin>>hourlyPayRate;

    cout<<"Enter federal tax withholding rate: ";
    double federaltaxrate;
    cin>>federaltaxrate;

    cout<<"Enter state tax withholding rate: ";
    double statetaxrate;
    cin>>statetaxrate;

    cout<<endl;

    cout<<"Employee Name: "<<name<<endl;

    cout<<"Hours Worked: "<<fixed<<setprecision(1)<<hours<<endl;

    cout<<"Pay Rate: $"<<fixed<<setprecision(2)<<hourlyPayRate<<endl;

    cout<<"Gross Pay: $";
    double grosspay = hourlyPayRate * hours;
    cout/*<<fixed<<setprecision(2)*/<<grosspay<<endl;

    cout<<"Deductions: "<<endl;

    cout<<"  "<<"Federal Withholding ("/*<<fixed<<setprecision(1)*/<<federaltaxrate * 100<<"%): $";
    double federal = federaltaxrate * grosspay;
    cout<<federal<<endl;

    cout<<"  "<<"State Withholding ("/*<<fixed<<setprecision(2)*/<<statetaxrate * 100<<"%): $";
    double state = statetaxrate * grosspay;
    cout<<state<<endl;

    cout<<"  "<<"Total Deduction: $";
    double total = federal + state;
    cout<<total<<endl;

    cout<<"Net Pay: $";
    double netpay = grosspay - total;
    cout<<netpay<<endl;
}


/*
Smith
10
9.75
0.20
0.09
*/
