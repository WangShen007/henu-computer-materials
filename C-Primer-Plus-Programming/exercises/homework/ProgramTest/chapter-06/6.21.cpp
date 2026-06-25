#include <iostream>
#include <string>
#include <cstdlib>
#include <iomanip>
using namespace std;

bool isPrime(int number)
{
    for(int divisor = 2;divisor <= number / 2;divisor++)
    {
        if(number % divisor == 0)
        {
            return false;
        }
    }

    return true;
}

bool isPalindrome(int number)
{
    int sum = 0;
    int number2 = number;
    for(int i = 0;i < 100;i++)
    {
        sum++;
        number2 /= 10;
        if(number2 == 0)
            break;
    }
    char c[sum];
    itoa(number,c,10);
    string s;
    for(int i = 0;i < sum;i++)
    {
        s += c[i];
    }

    int low = 0;

    int high = s.length() - 1;

    while(low < high)
    {
        if(s[low] != s[high])
        {
            return false;
        }
        low++;
        high--;
    }
    return true;
}
int main()
{
    int sum1 = 0;
    int sum2 = 0;
    int number = 2;
    while(sum1 != 100)
    {
        if(isPalindrome(number))
        {
            if(isPrime(number))
            {
                cout<<setw(5)<<number<<"   ";
                sum1++;
                sum2++;
            }
        }
        if(sum2 == 10)
        {
            cout<<endl;
            sum2 = 0;
        }
        number++;
    }
}





/*
#include <iostream>
#include <string>
using namespace std;

int main()
{
    cout <<"Enter a string: ";
    string s;
    getline(cin,s);

    int low = 0;

    int high = s.length() - 1;

    bool isPalindrome = true;
    while(low < high)
    {
        if(s[low] != s[high])
        {
            isPalindrome = false;
            break;
        }
        low++;
        high--;
    }

    if(isPalindrome)
        cout<<s<<" is a palindrome"<<endl;
    else
        cout<<s<<" is not a palindrome"<<endl;

    return 0;
}

bool isPrime(int number)
{
    for(int divisor = 2;divisor <= number / 2;divisor++)
    {
        if(number % divisor == 0)
        {
            return false;
        }
    }

    return true;
}
*/
