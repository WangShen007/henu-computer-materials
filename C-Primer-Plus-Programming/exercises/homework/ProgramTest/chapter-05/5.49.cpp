#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
using namespace std;
//Programming Is Fun;
int main()
{
    string s1;
    string s2;
    string s;

    cout<<"Enter s1: ";
    getline(cin,s1);

    cout<<"Enter s2: ";
    getline(cin,s2);

    int lengthmax = max(s1.length(),s2.length());
    bool noCommonPrefix = true;
    for(int i = 0;i < lengthmax;i++)
    {
        if(s1.at(i) == s2.at(i))
        {
            s += s1.at(i);
            noCommonPrefix = false;
        }
        else
        {
            break;
        }
    }

    if(noCommonPrefix)
    {
        cout<<s1<<" and "<<s2<<" have no common prefix"<<endl;
    }
    else
    {
        cout<<"The common prefix is "<<s<<endl;
    }
}
