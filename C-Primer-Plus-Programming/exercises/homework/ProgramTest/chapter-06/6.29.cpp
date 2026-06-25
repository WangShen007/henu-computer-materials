#include <iostream>

using namespace std;

int getSize(int n)
{
    int sum = 0;
    do
    {
        n /= 10;
        sum++;
    }while(n != 0);
    return sum;
}

int sumOfOddPlaces(int n)
{
    int sum = 0;
    int index = getSize(n) - 1;
    sum = n % 10;
    n /= 10;
    for(int i = 0;i < index / 2;i++)
    {
        sum += (n / 10) % 10 ;
        n /= 100;
    }
    return sum;
}

int main()
{
    cout<<"Enter an integer: ";
    int n;
    cin>>n;
    cout<<sumOfOddPlaces(n)<<endl;
}
