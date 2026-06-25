#include <iostream>
#include <cctype>

using namespace std;

int countLetters(const string &s)
{
    int count = 0;
    for (int i = 0; i < s.length(); i++)
    {
        if (isalpha(s[i]))
        {
            count++;
        }
    }
    return count;
}

int main()
{
    cout << "Enter a string: ";
    string s;
    getline(cin, s);
    cout << "The number of letters in " << s << " is: " << countLetters(s) << endl;
    return 0;
}







/*
#T7_35.cpp

#include <iostream>
#include <cctype>

using namespace std;

int countLetters(const char s[])
{
    int count = 0;
    for (int i = 0; s[i] != '\0'; i++)
    {
        if (isalpha(s[i]))
        {
            count++;
        }
    }
    return count;
}

int main()
{
    cout<<"Enter a string: ";
    char s[100];
    cin.getline(s, 100);
    cout<<"The number of letters in "<<s<<" is: "<<countLetters(s)<<endl;
    return 0;
}
*/