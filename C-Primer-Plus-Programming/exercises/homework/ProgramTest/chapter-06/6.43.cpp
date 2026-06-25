#include <iostream>
#include <string>

using namespace std;
/*
welcome
we welcome you!

welcome
we invite you!
*/
int indexOf(const string& s1, const string& s2)
{
    int index = s2.find(s1);
    if(index != string::npos)
    {
        return index;
    }
    else
    {
        return -1;
    }
}

int main()
{
    cout<<"Enter the first string: ";
    string s1,s2;
    getline(cin,s1);
    cout<<"Enter the second string: ";
    getline(cin,s2);
    int index = indexOf(s1, s2);
    cout<<"indexOf(\""<<s1<<"\", \""<<s2<<"\") is "<<index<<endl;
}
