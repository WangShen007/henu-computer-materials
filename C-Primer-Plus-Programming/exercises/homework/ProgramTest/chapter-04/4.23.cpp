#include <iostream>
#include <string>
#include <cctype>
using namespace std;
/*
232-23-5435
23-23-5435
*/
int main()
{
    cout << "Enter a SSN: ";
    string ssn;
    cin>>ssn;

    if(ssn.length() == 11)
    {
            char a[11];
            for(int i = 0;i < 11;i++)
            {
                a[i] = ssn.at(i);
            }

            if(isdigit(a[0]) && isdigit(a[1]) && isdigit(a[2]) && isdigit(a[4]) && isdigit(a[5]) && isdigit(a[7]) &&
               isdigit(a[8]) && isdigit(a[9]) && isdigit(a[10]) && a[3] == '-' && a[6] == '-')
            {
                cout<<ssn<<" is a valid social security number"<<endl;
            }

            else
            {
                cout<<ssn<<" is an invalid social security number"<<endl;
            }

    }

    else
    {
                cout<<ssn<<" is an invalid social security number"<<endl;
    }

}
