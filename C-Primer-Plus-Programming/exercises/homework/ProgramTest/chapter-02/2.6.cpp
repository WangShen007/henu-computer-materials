#include <iostream>

using namespace std;

int main()
{
    int x,sum = 0;
    cout<<"Enter a number between 0 and 1000: ";
    cin>>x;
    for(int i = 0;i < x;i++)
    {
        sum +=x%10;
        x = x / 10;
        if(x==0)
            break;
    }
    cout<<"The sum of digits is "<<sum<<endl;
}
