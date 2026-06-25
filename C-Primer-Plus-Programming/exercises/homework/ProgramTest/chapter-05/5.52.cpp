#include <iostream>
#include <string>
#include <cctype>
using namespace std;
//ABeijing Chicago
int main()
{
    cout<<"Enter a string: ";
    string x;
    getline(cin,x);

    for(int i = 0;i < x.size();i++)
    {
        if((i) % 2 != 0)
        {
            cout<<x.at(i);
        }
    }
}
