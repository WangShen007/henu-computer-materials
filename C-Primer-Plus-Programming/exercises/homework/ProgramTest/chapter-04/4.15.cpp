#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    cout<<"Enter a letter: ";
    char x;
    cin>>x;
    if(x >= '0' && x <= '9')
    {
        cout<<"The corresponding number is ";
        cout<<x;
    }
    else if(x >='a' && x <= 'c')
    {
        cout<<"The corresponding number is ";
        cout<<"2";
    }
    else if(x >='d' && x <= 'f')
    {
        cout<<"The corresponding number is ";
        cout<<"3";
    }
    else if(x >='g' && x <= 'i')
    {
        cout<<"The corresponding number is ";
        cout<<"4";
    }
    else if(x >='j' && x <= 'l')
    {
        cout<<"The corresponding number is ";
        cout<<"5";
    }
    else if(x >='m' && x <= 'o')
    {
        cout<<"The corresponding number is ";
        cout<<"6";
    }
    else if(x >='p' && x <= 's')
    {
        cout<<"The corresponding number is ";
        cout<<"7";
    }
    else if(x >='t' && x <= 'v')
    {
        cout<<"The corresponding number is ";
        cout<<"8";
    }
    else if(x >='w' && x <= 'z')
    {
        cout<<"The corresponding number is ";
        cout<<"9";
    }
    else
    {
        cout<<x<<" is an invalid input";
    }
}
