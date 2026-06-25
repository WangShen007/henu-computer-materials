#include <iostream>

using namespace std;

int main()
{
    cout<<"Enter an amount in double, for example 11.56: ";
    double amount;
    cin>>amount;
    int remainingAmount = static_cast<int>(amount * 100);
    int numberOfOneDollars = remainingAmount / 100;
    remainingAmount = remainingAmount % 100;
    int numberOfQuaters = remainingAmount / 25;
    remainingAmount = remainingAmount % 25;
    int numberOfDimes = remainingAmount / 10;
    remainingAmount = remainingAmount % 10;
    int numberOfNickels = remainingAmount / 5;
    remainingAmount = remainingAmount % 5;
    int numberOfPennies = remainingAmount;
    cout<<"Your amount "<<amount<<" consists of"<<endl;
    if(numberOfOneDollars != 0)
    {
        if(numberOfOneDollars == 1)
            cout<<"  "<<numberOfOneDollars<<" dollar"<<endl;
        else
            cout<<"  "<<numberOfOneDollars<<" dollars"<<endl;
    }
    if(numberOfQuaters != 0)
    {
        if(numberOfQuaters == 1)
            cout<<"  "<<numberOfQuaters<<" quarter"<<endl;
        else
            cout<<"  "<<numberOfQuaters<<" quarters"<<endl;
    }
    if(numberOfDimes != 0)
    {
        if(numberOfDimes == 1)
            cout<<"  "<<numberOfDimes<<" dime"<<endl;
        else
            cout<<"  "<<numberOfDimes<<" dimes"<<endl;
    }
    if(numberOfNickels != 0)
    {
        if(numberOfNickels == 1)
            cout<<"  "<<numberOfNickels<<" nickel"<<endl;
        else
            cout<<"  "<<numberOfNickels<<" nickels"<<endl;
    }
    if(numberOfPennies != 0)
    {
        if(numberOfPennies == 1)
            cout<<"  "<<numberOfPennies<<" pennie"<<endl;
        else
            cout<<"  "<<numberOfPennies<<" pennies"<<endl;
    }
}
