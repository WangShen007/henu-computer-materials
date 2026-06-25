#include <iostream>
#include <cctype>
#include <string>

using namespace std;

/*
1-800-Flowers
1800flowers
*/

int getNumber(char uppercaseLetter)
{
    char x = tolower(uppercaseLetter);
    if(x >='a' && x <= 'c')
    {
        return 2;
    }
    else if(x >='d' && x <= 'f')
    {
        return 3;
    }
    else if(x >='g' && x <= 'i')
    {
        return 4;
    }
    else if(x >='j' && x <= 'l')
    {
        return 5;
    }
    else if(x >='m' && x <= 'o')
    {
        return 6;
    }
    else if(x >='p' && x <= 's')
    {
        return 7;
    }
    else if(x >='t' && x <= 'v')
    {
        return 8;
    }
    else//(x >='w' && x <= 'z')
    {
        return 9;
    }
}

int main()
{
    cout<<"Enter a string: ";
    string s;
    getline(cin,s);
    int length = s.length();
    for(int i = 0;i < length;i++)
    {
        char x = s.at(i);
        if(isalpha(x))
        {
            cout<<getNumber(x);
        }
        else
        {
            cout<<x;
        }
    }
}









/*
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

*/
