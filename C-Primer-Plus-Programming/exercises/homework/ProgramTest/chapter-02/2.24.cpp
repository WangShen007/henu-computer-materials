#include <iostream>

using namespace std;

int main()
{
    cout<<"Enter an amount in int, for example 1156: ";
    int amount;
    cin>>amount;
    int remainingAmount = amount;
    int numberOfOneDollars = remainingAmount / 100;
    remainingAmount = remainingAmount % 100;
    int numberOfQuaters = remainingAmount / 25;
    remainingAmount = remainingAmount % 25;
    int numberOfDimes = remainingAmount / 10;
    remainingAmount = remainingAmount % 10;
    int numberOfNickels = remainingAmount / 5;
    remainingAmount = remainingAmount % 5;
    int numberOfPennies = remainingAmount;
    cout<<"Your amount "<<amount<<" consists of"<<endl
    <<"  "<<numberOfOneDollars<<" dollars"<<endl
    <<"  "<<numberOfQuaters<<" quarters"<<endl
    <<"  "<<numberOfDimes<<" dimes"<<endl
    <<"  "<<numberOfNickels<<" nickels"<<endl
    <<"  "<<numberOfPennies<<" pennies"<<endl;
}
