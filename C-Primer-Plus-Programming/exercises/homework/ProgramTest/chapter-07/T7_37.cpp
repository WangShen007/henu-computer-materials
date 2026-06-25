#include <iostream>
#include <cstring>

using namespace std;

void count(const char s[], int counts[])
{
    for(int i = 0;i < strlen(s);i++)//strlen 会在遇到'\0'时停止
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

    for(int i = 0;i < 26;i++)
    {
        if(counts[i] != 0)
        {
            cout<<char(i + 'a')<<": "<<counts[i]<<" times"<<endl;
        }
    }
}

int main()
{
    cout<<"Enter a string: ";
    char s[100];
    cin.getline(s, 100);
    int counts[26] = {0};
    count(s, counts);
    return 0;
}