#include <iostream>
#include <string>
#include <cctype>

using namespace std;

//I'm here

string swapCase(const string& s)
{
    string newS;
    for(int i = 0;i < s.length();i++)
    {
        if(islower(s.at(i)))
        {
            newS += toupper(s.at(i));
            //s[i] = toupper(s.at(i));wrong
//            char x = toupper(s.at(i));
            //s = s.replace(i,1,toupper(s.at(i)));
//            s.replace(i,1,toupper(s.at(i)));

        }
        else if(isupper(s.at(i)))
        {
            newS += tolower(s.at(i));
            //s.replace(i,1,tolower(s.at(i)));
        }
        else
        {
            newS += s.at(i);
        }
    }

    return newS;
}

int main()
{
    cout<<"Enter a string: ";
    string s;
    getline(cin,s);
    cout<<"The new string is: ";
    //s = swapCase(s);
    s = swapCase(s);
    cout<<s<<endl;
}
