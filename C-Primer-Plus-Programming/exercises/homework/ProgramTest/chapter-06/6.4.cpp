#include <iostream>

using namespace std;

void reverse(int number)
{
    int reversenumber = 0;
    for(int i = 0;i <100;i++)
    {
        int temp = number % 10;
        reversenumber = reversenumber * 10 + temp;
        number = number / 10;
        if(number == 0)
        {
            break;
        }
        //number = number / 10;
    }
    cout<<"The reverse number is "<<reversenumber;
}

int main()
{
    cout<<"Enter a number: ";
    int num;
    cin>>num;
    reverse(num);
}
