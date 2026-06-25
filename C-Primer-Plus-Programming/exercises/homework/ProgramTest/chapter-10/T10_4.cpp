#include <iostream>
#include <algorithm>
using namespace std;

string sort(string &s)
{
    string s1 = s;
    sort(s1.begin(), s1.end());
    return s1;
}

int main()
{
    string s;
    cout<<"Enter a string s: ";
    cin>>s;
    cout<<"The sorted string is: "<<sort(s)<<"\n";
}