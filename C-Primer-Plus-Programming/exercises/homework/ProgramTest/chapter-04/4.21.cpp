#include <iostream>
#include <string>
using namespace std;

int main()
{
    cout << "Enter two characters: " ;
    string x;
    cin>>x;
    char a = x.at(0);
    char b = x.at(1);
    if(a != 'M' && a != 'C' && a != 'I')
    {
        cout<<"Invalid major code";
    }
    else if(b != '1' && b !='2' && b != '3' && b != '4')
    {
        cout<<"Invalid status code";
    }
    else
    {
            if(a == 'M')
        {
            cout<<"Mathematics ";
        }
        else if(a == 'C')
        {
            cout<<"Computer Science ";
        }
        else if(a == 'I')
        {
            cout<<"Information Technology ";
        }
        else
        {

        }

        int c = x.at(1) - '0';
        string n;//name
        switch(c)
        {
        case 1 :
            n = "Freshman";
            cout<<n;
            break;
        case 2 :
            n = "Sophomore";
            cout<<n;
            break;
        case 3 :
            n = "Junior";
            cout<<n;
            break;
        case 4 :
            n = "Senior";
            cout<<n;
            break;
        }

    }
}

    /*
    if(x.at(1) == 'M')
    {
        cout<<"Mathematics ";
    }
    else if(x.at(1) == 'C')
    {
        cout<<"Computer Science ";
    }
    else if(x.at(1) == 'I')
    {
        cout<<"Information Technology ";
    }
    else
    {
        cout<<"Invalid major code";
    }
    string n;//name
    switch(x.at(2))
    {
    case 1 :
        n = "Freshman";
        cout<<n;
        break;
    case 2 :
        n = "Sophomore";
        cout<<n;
        break;
    case 3 :
        n = "Junior";
        cout<<n;
        break;
    case 4 :
        n = "Senior";
        cout<<n;
        break;
    default :
        cout<<"Invalid status code";
        break;
    }
    */


























/*
int main()
{
    cout << "Enter two characters: " ;
    string x;
    cin>>x;
    if(x.at(1) == 'M')
    {
        cout<<"Mathematics ";
    }
    else if(x.at(1) == 'C')
    {
        cout<<"Computer Science ";
    }
    else if(x.at(1) == 'I')
    {
        cout<<"Information Technology ";
    }
    else
    {
        cout<<"Invalid major code";
    }
    string n;//name
    switch(x.at(2))
    {
    case 1 :
        n = "Freshman";
        cout<<n;
        break;
    case 2 :
        n = "Sophomore";
        cout<<n;
        break;
    case 3 :
        n = "Junior";
        cout<<n;
        break;
    case 4 :
        n = "Senior";
        cout<<n;
        break;
    default :
        cout<<"Invalid status code";
        break;
    }
}
*/
