#include <iostream>

using namespace std;

int main()
{
    cout << "Enter a character: " ;
    char c;
    cin>>c;
    cout<<"The ASCII code for the character is "<<static_cast<int>(c);
}
