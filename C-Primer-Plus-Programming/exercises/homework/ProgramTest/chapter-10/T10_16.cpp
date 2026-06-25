#include <iostream>

using namespace std;

class StackOfIntegers
{
private:
    int elements[100];
    int size;
public:
    StackOfIntegers()
    {
        size = 0;
    }
    
    bool empty()
    {
        return size == 0;
    }
    
    int peek()
    {
        return elements[size - 1];
    }
    
    void push(int value)
    {
        elements[size++] = value;
    }
    
    int pop()
    {
        return elements[--size];
    }
    
    int getSize()
    {
        return size;
    }

    bool isPrime(int n)
    {
        for(int i = 2;i <= n / 2;i++)
        {
            if(n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
};

int main()
{
    StackOfIntegers stack;
    int n;
    cout << "Enter an integer: ";
    cin >> n;
    int i = 2;
    while(n != 1)
    {
        while(n % i == 0 && stack.isPrime(i))
        {
            stack.push(i);
            n /= i;
        }
        i++;
    }
    while(!stack.empty())
    {
        cout << stack.pop() << " ";
    }
    cout << endl;
    return 0;
}