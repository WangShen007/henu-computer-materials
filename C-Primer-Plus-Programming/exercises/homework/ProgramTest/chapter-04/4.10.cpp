#include <iostream>

using namespace std;

int main()
{
    cout << "Enter a letter grade: ";
    char l;
    cin>>l;
    if((l >= 'A'&&l <= 'Z') || (l >= 'a' && l <= 'z'))
    {
        if(l == 'a' || l == 'e' || l == 'i' || l == 'o' || l == 'u' || l == 'A' || l == 'E' || l == 'I' || l == 'O' || l == 'U')
        {
            cout<<l<<" is a vowel";
        }
        else
        {
            cout<<l<<" is a consonant";
        }
    }
    else
    {
        cout<<l<<" is an invalid input";
    }
}
