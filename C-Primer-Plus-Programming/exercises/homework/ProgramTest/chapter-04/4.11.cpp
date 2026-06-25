#include <iostream>
#include <cctype>
using namespace std;

int main()
{
    cout<<"Enter an uppercase letter: ";
    char l;
    cin>>l;
    /*
    char x = l - 'A' + 'a';
    cout<<"The lowercase letter is "<<x;
    */
    cout<<"The lowercase letter is "<<static_cast<char>(tolower(l));
}
