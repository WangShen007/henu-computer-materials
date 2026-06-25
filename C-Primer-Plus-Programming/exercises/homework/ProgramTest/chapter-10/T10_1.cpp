#include <iostream>
#include <string>

using namespace std;

bool isAnagram(const string &s1, const string &s2)
{
    bool hasTheSameWords = true;
    for(int i = 0;i < s1.size();i++)
    {
        if(s2.find(s1[i]) == string::npos)
        {
            hasTheSameWords = false;
            break;
        }
    }

    bool result = hasTheSameWords;
    if(hasTheSameWords)
    {
        if(s1 == s2)
        {
            result = false;
        }
    }

    return result;
}

int main()
{
    string s1, s2;
    cout<<"Enter a string s1: ";
    cin>>s1;
    cout<<"Enter a string s2: ";
    cin>>s2;

    cout<<s1<<" and "<<s2<<" are "<<(isAnagram(s1, s2)? "" : "not ")<<"anagrams"<<endl;
    return 0;
}