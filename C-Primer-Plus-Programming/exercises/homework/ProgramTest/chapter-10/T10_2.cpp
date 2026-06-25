#include <iostream>

using namespace std;

string commonChars(const string& s1, const string& s2)
{
    string result;
    for(int i = 0;i < s1.length();i++)
    {
        for(int j = 0;j < s2.length();j++)
        {
            if(s1[i] == s2[j])
            {
                result += s1[i];
            }
        }
    }

    for(int i = 0;i < result.length();i++)
    {
        for(int j = i + 1;j < result.length();j++)
        {
            if(result[i] == result[j])
            {
                result.erase(j, 1);
                j--;
            }
        }
    }

    return result;
}


int main()
{
    cout<<"Enter a string s1: ";
    string s1;
    cin>>s1;
    cout<<"Enter a string s2: ";
    string s2;
    cin>>s2;
    string result = commonChars(s1, s2);
    if(result == "")
    {
        cout<<"No common characters";
    }
    else
    {
        cout<<"The common characters are: "<<result<<endl;
    }
    return 0;
}