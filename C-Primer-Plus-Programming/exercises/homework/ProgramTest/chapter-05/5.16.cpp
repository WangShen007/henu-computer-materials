#include <iostream>
#include <cmath>
using namespace std;

/*
125
2525
*/
int main()
{
    cout<<"Enter first integer: ";
    int n1;
    cin>>n1;

    cout<<"Enter second integer: ";
    int n2;
    cin>>n2;

    int gcd = 1;
    int k = min(n1,n2);
    while(k > 0)
    {
        if(n1 % k == 0 && n2 % k == 0)
            {
                gcd = k;
                break;
            }
        k--;
    }

    cout<<"The greatest common divisor for "<<n1<<" and "
    <<n2<<" is "<<gcd<<endl;

    return 0;
}
