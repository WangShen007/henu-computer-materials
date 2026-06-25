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
