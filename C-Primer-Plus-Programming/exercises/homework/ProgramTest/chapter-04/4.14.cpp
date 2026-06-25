#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    cout << "Enter a decimal value (0 to 15): " ;
    int x;
    cin>>x;
    if(x >= 0 && x <= 9)
    {
        cout<<"The hex value is "<<x;
    }
    else if(x >= 10 && x <= 15)
    {
        cout<<"The hex value is ";
        char name;
        switch(x)
        {
        case 10 :
            name = 'a';
            break;
        case 11 :
            name = 'b';
            break;
        case 12 :
            name = 'c';
            break;
        case 13 :
            name = 'd';
            break;
        case 14 :
            name = 'e';
            break;
        case 15 :
            name = 'f';
            break;
        }
        name = toupper(name);
        cout<<name;
    }
    else
    {
        cout<<x<<" is an invalid input";
    }
}
