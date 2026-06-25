#include <iostream>
#include <string>
#include <cctype>
using namespace std;

int main()
{
    cout<<"Enter your password: "<<endl;
    string password;
    cin>>password;
    int digit = password.length();
    bool follow = true;
    int sumch = 0;

    if(digit < 8)//8
    {
        follow = false;
    }

    int theNumberOfNumbers = 0;

    for(int i = 0;i < digit;i++)
    {
        if(!isalnum(password.at(i)))
        {
            follow = false;
        }

        if(isdigit(password.at(i)))
        {
            theNumberOfNumbers++;
        }
    }

    if(theNumberOfNumbers >=2 && follow)
    {
        cout<<"valid password";
    }
    else
    {
        cout<<"invalid password";
    }
}
