#include <iostream>

using namespace std;

class StackOfIntegers
{
    public:
    StackOfIntegers()
    {
        size = 0;
    }
    bool isEmpty() const//const function can't change the value of the object
    {
        return (size == 0);//return true if size is 0
    }
    bool isPrime() const
    {
        if(elements[size - 1] == 1 || elements[size - 1] == 0)
        {
            return false;
        }
        for(int i = 2;i <= elements[size - 1] / 2;i++)//check if the number is prime
        {
            if(elements[size - 1] % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    int peek() const//return the top element of the stack
    {
        return elements[size - 1];//return the top element of the stack and don't change the size
    }
    void push(int value)
    {
        elements[size++] = value;//add the value to the stack and increase the size
    }
    int pop()
    {
        return elements[--size];//decrease the size and return the top element
    }
    int getSize() const
    {
        return size;
    }
    private:
    int elements[1000];
    int size;
};

int main()
{
    StackOfIntegers stack;
    for(int i = 0;i <= 120;i++)
    {
        stack.push(i);
    }
    for(int i = 0;i <= 120;i++)
    {
        if(stack.isPrime())
        {
            cout << stack.peek() << " ";
        }
        stack.pop();
    }
}





















/*

#include <iostream>

using namespace std;

class StackOfIntegers
{
    public:
    int value;

    StackOfIntegers()
    {
        value = 0;
    }

    bool isPrime()
    {
        if(value == 1 || value == 0)
        {
            return false;
        }
        for(int i = 2;i <= value / 2;i++)
        {
            if(value % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    int getValue()
    {
        return value;
    }

    void setValue(int value)
    {
        this->value = value;
    }
};

int main()
{
    StackOfIntegers stack[121];
    for(int i = 0;i <= 120;i++)
    {
        stack->setValue(i);
        if(stack->isPrime())
        {
            cout << stack->getValue() << " ";
        }
    }
}

*/