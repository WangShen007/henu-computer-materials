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
int main()
{
    int n;
    cout<<"Enter an integer: ";
    cin>>n;
    cout<<getSize(n)<<endl;
}
