#include <iostream>
#include <cmath>
#include <string>
using namespace std;
//013601267
//013031997
int main()
{
    cout << "Enter the first 9 digits of an ISBN as integer: ";
    string isbn9;
    cin>>isbn9;
    int a[10];
    int sum = 0;
    cout<<"The ISBN-10 number is ";
    for(int i = 0;i < 9;i++)
    {
        a[i] = isbn9.at(i) - '0';
        sum += a[i] * (i + 1);
        cout<<a[i];
    }
    a[9] = sum % 11;
    if (a[9] == 10)
        cout<<"X";
    else
        cout<<a[9];
}


























/*
#include <iostream>
#include <cmath>
using namespace std;
//013601267
//013031997
int main()
{
    cout << "Enter the first 9 digits of an ISBN as integer: ";
    int isbn9;
    cin>>isbn9;
    int temp = isbn9;
    int d[10];
    for(int i = 0; i < 9;i++)
        {
            d[8 - i] = temp % 10;
            temp = temp / 10;
        }
    int sum = 0;
    cout<<"The ISBN-10 number is ";
    for(int i = 0; i < 9;i++)
    {
        sum += d[i] * (i + 1);
        cout<<d[i];
    }
    d[9] = sum % 11;
    if (d[9] == 10)
        cout<<"X";
    else
        cout<<d[9];
}
*/
