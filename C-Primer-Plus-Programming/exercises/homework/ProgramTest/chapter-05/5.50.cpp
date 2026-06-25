#include <iostream>
#include <string>
using namespace std;

int main()
{
    cout<<"Enter a string: ";
    string x;
    getline(cin,x);
    cout<<"The reversed string is ";
    for(int i = x.size() - 1;i >= 0;i--)
    {
        cout<<x.at(i);
    }
}
