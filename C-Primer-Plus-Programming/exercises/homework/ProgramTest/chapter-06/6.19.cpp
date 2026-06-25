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

void printPrimeNumbers(int number)
{
    int num = 2;
    while(num <= number)
    {
        if(isPrime(num))
        {
            if(isPrime(num + 2))
            {
                cout<<"("<<num<<", "<<num + 2<<")"<<endl;
            }
        }
        num++;
    }
}

int main()
{
    int number = 100;
    printPrimeNumbers(number);
}





/*
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

void printPrimeNumbers()
{
    const int NUMBERS = 10000;
    const int NUMBER_OF_PRIMES_PER_LINE = 10;
    int count = 0;
    int number = 2;

    while(number < NUMBERS)
    {
        if(isPrime(number))
        {
            count++;
            if(count % NUMBER_OF_PRIMES_PER_LINE == 0)
            {
                cout<<setw(6)<<number<<endl;
            }
            else
            {
                cout<<setw(6)<<number;
            }
        }
        number++;
    }
}

int main()
{
    cout<<"The numbers are \n";
    printPrimeNumbers();

    return 0;
}











/*
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

void printPrimeNumbers(int numberOfPrimes)
{
    const int NUMBER_OF_PRIMES = 50;
    const int NUMBER_OF_PRIMES_PER_LINE = 10;
    int count = 0;
    int number = 2;

    while(count < numberOfPrimes)
    {
        if(isPrime(number))
        {
            count++;
            if(count % NUMBER_OF_PRIMES_PER_LINE == 0)
            {
                cout<<setw(4)<<number<<endl;
            }
            else
            {
                cout<<setw(4)<<number;
            }
        }
        number++;
    }
}

int main()
{
    cout<<"The first 50 prime numbers are \n";
    printPrimeNumbers(50);

    return 0;
}
*/
