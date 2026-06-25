#include <iostream>
#include <vector>
using namespace std;

template <typename T>

class Stack
{
    public:
    Stack();
    bool empty() const;
    T peek() const;
    void push(T value);
    T pop();
    int getSize() const;

    private:
    vector<T> elements;
    int size;
};

template <typename T>
Stack<T>::Stack()
{
    size = 0;
}

template <typename T>
bool Stack<T>::empty() const
{
    return elements.empty();
}

template <typename T>
T Stack<T>::peek() const
{
    return elements.at(size - 1);
}

template <typename T>
void Stack<T>::push(T value)
{
    elements.push_back(value);
    size++;
}

template <typename T>
T Stack<T>::pop()
{
    T value = elements.at(size - 1);
    elements.pop_back();
    size--;
    return value;
}

template <typename T>
int Stack<T>::getSize() const
{
    return size;
}

int main()
{
    Stack<int> intStack;
    Stack<string> stringStack;

    intStack.push(1);
    intStack.push(2);
    intStack.push(3);

    stringStack.push("London");
    stringStack.push("Paris");
    stringStack.push("Berlin");

    cout << "intStack: ";
    while (!intStack.empty())
    {
        cout << intStack.pop() << " ";
    }
    cout << endl;

    cout << "stringStack: ";
    while (!stringStack.empty())
    {
        cout << stringStack.pop() << " ";
    }
    cout << endl;

    return 0;
}
