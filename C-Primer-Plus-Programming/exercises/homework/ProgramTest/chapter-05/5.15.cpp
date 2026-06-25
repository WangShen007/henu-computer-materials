#include <iostream>

using namespace std;

int main()
{
    int n = 100;
    while(n * n * n > 12000)
    {
        n--;
    }
    cout<<n;
}
