#include <iostream>

using namespace std;

int main()
{
    cout << "Enter a three-digit integer: ";
    int x;
    cin>>x;
    if(x / 100 == x % 10)
        cout<<x<<" is a palindrome";
    else
        cout<<x<<" is not a palindrome";
}
