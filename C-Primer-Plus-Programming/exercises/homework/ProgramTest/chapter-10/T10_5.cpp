#include <iostream>
#include <cctype>

using namespace std;

bool isPalindrome(const string &s)
{
    string a;
    for (int i = 0; i < s.length(); i++)
    {
        if (isalpha(s[i]))
        {
            a += tolower(s[i]);
        }
    }
    for (int i = 0; i < a.length() / 2; i++)
    {
        if (a[i] != a[a.length() - 1 - i])
        {
            return false;
        }
    }
    return true;
}

int main()
{
    string s;
    cout << "Enter a string s: ";
    getline(cin, s);
    if (isPalindrome(s))
    {
        cout <<s<< " is a palindrome\n";
    }
    else
    {
        cout <<s<<" is not a palindrome\n";
    }
}