#include <iostream>
#include <ctime>
#include <cstdlib>
#include <string>
using namespace std;

int main()
{
    string x;
    srand(time(0));
    for(int i = 0;i < 3;i++)
    {
        char a = rand() % ('Z' - 'A' + 1) + 'A';
        x += a;
    }
    cout<<x;
}
