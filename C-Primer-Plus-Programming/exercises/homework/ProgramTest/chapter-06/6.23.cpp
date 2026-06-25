#include <iostream>
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

int changenumber(int number)
{
    int changednumber = 0;
    while(number != 0)
    {
        changednumber *= 10;
        changednumber += number % 10;
        number /= 10;
    }
    return changednumber;
}

int main()
{
    int sum = 0;
    int number = 2;
    int sum2 = 0;
    while(sum != 100)
    {
        if(isPrime(number))
        {
            int changednum = changenumber(number);
            if(isPrime(changednum))
            {
                cout<<setw(5)<<number<<" ";
                sum2++;
                sum++;
                if(sum2 == 10)
                {
                    cout<<endl;
                    sum2 = 0;
                }
            }
        }
        number++;
    }
}









/*
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
*/
