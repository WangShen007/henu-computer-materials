#include <iostream>

using namespace std;

int sumDigits(long n)
{
    int temp = n;
    int a[n];
    int sum = 0;
    int digitsum = 0;
    for(int i = 0;i < n;i++)
    {
        a[i] = n % 10;
        sum++;
        digitsum += a[i];
        temp /= 10;
        if(temp == 0)
        {
            break;
        }
    }

    return digitsum;
}

int main()
{
    cout<<"Enter a digit: ";
    long n;
    cin>>n;
    int sum = sumDigits(n);
    cout<<sum<<endl;
}
