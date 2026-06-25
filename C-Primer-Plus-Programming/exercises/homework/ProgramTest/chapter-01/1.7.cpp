#include <iostream>

using namespace std;

int main()
{
    long double x = 4 * (1.0 - 1.0 / 3 + 1.0 / 5 - 1.0 / 7 + 1.0 / 9 - 1.0 / 11);
    long double y = 4 * (1.0 - 1.0 / 3 + 1.0 / 5 - 1.0 / 7 + 1.0 / 9 - 1.0 / 11 + 1.0 / 13);
    cout<<"4 * (1 - 1 / 3 + 1 / 5 - 1 / 7 + 9 / 1 - 1 / 11) = "<<x<<endl;
    cout<<"4 * (1 - 1 / 3 + 1 / 5 - 1 / 7 + 9 / 1 - 1 / 11 + 1 / 13) = "<<y<<endl;
}
