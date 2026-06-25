#include <iostream>
#include <cctype>
using namespace std;

int* count(const string& s)
{
    //int counts[26] = {0};
    int* counts = new int[26];
    for(int i = 0;i < 26;i++)
    {
        counts[i] = 0;
    }
    for(int i = 0;i < s.size();i++)
    {
        counts[tolower(s[i]) - 'a']++;
    }
    return counts;
}

int main()
{
    string s = "ABcaB";
    //int counts[] = count(s);//wrong
    int *counts = count(s);
    for(int i = 0;i < 26;i++)
    {
        if(counts[i] != 0)
        {
            cout<<char(i + 'a')<<": "<<counts[i]<<" times"<<endl;
        }
    }
}



























/*
#Program Test T10_7

void count(const string& s, int counts[], int size)
{
    for(int i = 0;i < s.length();i++)
    {
        if(s[i] - 'a' >= 0 && s[i] - 'a' < 26)
        {
            counts[s[i] - 'a']++;
        }
        else if(s[i] - 'A' >= 0 && s[i] - 'A' < 26)
        {
            counts[s[i] - 'A']++;
        }
    }

    for(int i = 0;i < size;i++)
    {
        if(counts[i] != 0)
        {
            cout<<char(i + 'a')<<": "<<counts[i]<<" times"<<endl;
        }
    }
}

*/