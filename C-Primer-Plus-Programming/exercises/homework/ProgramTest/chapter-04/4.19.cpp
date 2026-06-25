#include <iostream>
#include <string>
#include <algorithm>
using namespace std;
//Chicago
//Los Angeles
//Atlanta
int main()
{
    cout << "Enter the first city: ";
    string c[3];
    string city;
    getline(cin, c[0], '\n');
    cout << "Enter the second city: ";
    getline(cin, c[1], '\n');
    cout << "Enter the third city: ";
    getline(cin, c[2], '\n');
    sort(c,c + 3);
    cout<<"The three cities in alphabetical order are "<<c[0]<<" "<<c[1]<<" "<<c[2];
}
