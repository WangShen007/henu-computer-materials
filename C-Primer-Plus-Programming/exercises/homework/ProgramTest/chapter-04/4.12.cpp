#include <iostream>

using namespace std;

int main()
{
    cout<<"Enter a letter grade: ";
    char grade;
    cin>>grade;
    if(grade == 'a' || grade == 'A')
    {
        cout<<"The numeric value for grade "<<grade<<" is "<<"4";
    }
    else if(grade == 'b' || grade == 'B')
    {
        cout<<"The numeric value for grade "<<grade<<" is "<<"3";
    }
    else if(grade == 'c' || grade == 'C')
    {
        cout<<"The numeric value for grade "<<grade<<" is "<<"2";
    }
    else if(grade == 'd' || grade == 'D')
    {
        cout<<"The numeric value for grade "<<grade<<" is "<<"1";
    }
    else if(grade == 'f' || grade == 'F')
    {
        cout<<"The numeric value for grade "<<grade<<" is "<<"0";
    }
    else
    {
        cout<<grade<<" is an invalid grade";
    }
}
