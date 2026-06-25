#include <iostream>
#include <string>

using namespace std;

string dec2Bin(int value)
{
    string bin;
    while(value != 0)
    {
        char x = value % 2 + '0';
        bin = x + bin;
        value /= 2;
    }
    return bin;
}

int main()
{
    cout<<"Enter a decimal number: ";
    int number;
    cin>>number;
    string bin = dec2Bin(number);
    cout<<bin<<endl;
}
