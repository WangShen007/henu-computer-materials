#include <iostream>

using namespace std;

int main()
{
    cout<<"Enter an integer: ";
    int num;
    cin>>num;
    cout<<"Is "<<num<<" divisible by 5 and 6? ";
    if (num % 5 == 0 && num % 6 == 0)
        cout<<"true"<<endl;
    else
        cout<<"false"<<endl;
    cout<<"Is "<<num<<" divisible by 5 or 6? ";
    if(num % 5 == 0 || num % 6 == 0)
        cout<<"true"<<endl;
    else
        cout<<"false"<<endl;
    cout<<"Is "<<num<<" divisible by 5 or 6, but not both? ";
    if((num % 5 == 0 || num % 6 == 0) && !(num % 5 == 0 && num % 6 == 0))
        cout<<"true"<<endl;
    else
        cout<<"false"<<endl;
}
