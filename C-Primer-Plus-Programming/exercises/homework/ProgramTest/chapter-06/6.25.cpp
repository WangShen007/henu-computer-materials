#include <iostream>
#include <cmath>
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



int main()
{
    cout<<left<<setw(4)<<"p"<<right<<setw(15)<<"2 ^ p - 1"<<endl;
    for(int p = 2;p <= 31;p++)
    {
        if(isPrime(p))
        {
            if(isPrime(pow(2,p) - 1))
            {
                cout<<left<<setw(4)<<p<<right<<setw(12)<<pow(2,p) - 1<<endl;
            }
        }
    }
}
