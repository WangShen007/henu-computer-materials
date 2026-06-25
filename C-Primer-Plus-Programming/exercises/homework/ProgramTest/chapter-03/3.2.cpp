#include <iostream>

using namespace std;

int main()
{
    cout << "Enter two integers: " ;
    int a,b;
    cin>>a>>b;
    if(a % b == 0)
    {
        cout<<a<<" is divisible by "<<b;
    }
    else
    {
        cout<<a<<" is not divisible by "<<b;
    }
    return 0;
}
