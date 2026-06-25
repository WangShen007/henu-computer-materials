#include <iostream>

using namespace std;

class EvenNumber
{
    public:
    int value;
    EvenNumber()
    {
        value = 0;
    }

    EvenNumber(int value)
    {
        if(value % 2 == 0)
            this->value = value;
        else
            this->value = 0;
    }

    int getValue()
    {
        return value;
    }

    int getNext()
    {
        return value + 2;
    }

    int getPrevious()
    {
        return value - 2;
    }
};

int main()
{
    EvenNumber number;
    cout << "Enter an even number: ";
    cin >> number.value;
    cout << "The next even number is " << number.getNext() << endl;
    cout << "The previous even number is " << number.getPrevious() << endl;
}