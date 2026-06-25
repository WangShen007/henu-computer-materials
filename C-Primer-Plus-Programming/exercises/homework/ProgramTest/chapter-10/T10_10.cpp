#include <iostream>
#include <string>

using namespace std;

class MyInteger
{
    public:
    int value;
    MyInteger(int value)
    {
        this->value = value;
    }

    bool isEven() const
    {
        return value % 2 == 0;
    }

    bool isOdd() const
    {
        return value % 2 != 0;
    }

    bool isPrime() const
    {
        if (value == 1 || value == 0)
            return false;
        for (int i = 2; i <= value / 2; i++)
        {
            if (value % i == 0)
                return false;
        }
        return true;
    }

    static bool isEven(int value)
    {
        return value % 2 == 0;
    }

    static bool isOdd(int value)
    {
        return value % 2 != 0;
    }

    static bool isPrime(int value)
    {
        if (value == 1 || value == 0)
            return false;
        for (int i = 2; i <= value / 2; i++)
        {
            if (value % i == 0)
                return false;
        }
        return true;
    }

    static bool isEven(const MyInteger &myInteger)
    {
        return myInteger.isEven();
    }

    static bool isOdd(const MyInteger &myInteger)
    {
        return myInteger.isOdd();
    }

    static bool isPrime(const MyInteger &myInteger)
    {
        return myInteger.isPrime();
    }

    bool equals(int value) const
    {
        return this->value == value;
    }

    bool equals(const MyInteger &myInteger) const
    {
        return this->value == myInteger.value;
    }

    static int parseInt(const string &s)
    {
        int value = stoi(s);
        return value;
    }
};

int main()
{
    MyInteger n1(5);
    cout << "n1 is even? " << n1.isEven() << endl;
    cout << "n1 is odd? " << n1.isOdd() << endl;
    cout << "n1 is prime? " << n1.isPrime() << endl;

    MyInteger n2(24);
    cout << "n2 is even? " << n2.isEven() << endl;
    cout << "n2 is odd? " << n2.isOdd() << endl;
    cout << "n2 is prime? " << n2.isPrime() << endl;

    cout << "15 is odd? " << MyInteger::isOdd(15) << endl;
    cout << "24 is even? " << MyInteger::isEven(24) << endl;
    cout << "73 is prime? " << MyInteger::isPrime(73) << endl;

    MyInteger n3(5);
    cout << "n3 is equal to 5? " << n3.equals(5) << endl;
    cout << "n3 is equal to n1? " << n3.equals(n1) << endl;

    cout << "100 is odd? " << MyInteger::isOdd(100) << endl;
    cout << "100 is even? " << MyInteger::isEven(100) << endl;
    cout << "100 is prime? " << MyInteger::isPrime(100) << endl;

    string s = "12345";
    cout << MyInteger::parseInt(s) << endl;

    return 0;
}