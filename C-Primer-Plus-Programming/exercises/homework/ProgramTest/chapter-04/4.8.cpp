#include <iostream>

using namespace std;

int main()
{
    cout << "Enter an ASCII code: ";
    int x;
    cin>>x;
    //static_cast<char>(x);
    cout<<"The character is "<<static_cast<char>(x);
}
