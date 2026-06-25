#include <iostream>

using namespace std;
int reverse(int number)
{
    int reversenumber = 0;
    for(int i = 0;i < 100;i++)
    {
        int temp = number % 10;
        reversenumber = reversenumber * 10 + temp;
        number = number / 10;
        if(number == 0)
        {
            break;
        }
    }
    return reversenumber;
}

bool isPalindrome(int number)
{
    int reversenumber = reverse(number);
    if(reversenumber == number)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

int main()
{
    cout<<"Enter a number: ";
    int num;
    cin>>num;
    if(isPalindrome(num))
    {
        cout<<"Yes"<<endl;
    }
    else
    {
        cout<<"No"<<endl;
    }
}
