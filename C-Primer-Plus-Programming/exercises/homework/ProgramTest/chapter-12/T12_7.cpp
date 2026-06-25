#include <iostream>

using namespace std;

template<typename T>
class Stack
{
public:
  Stack();
  bool empty() const;
  T peek() const;
  void push(T value);
  T pop();
  int getSize() const;
  bool contains(T element) const;

private:
  T elements[100];
  int size;
};

template<typename T>
Stack<T>::Stack()
{
  size = 0;
}

template<typename T>
bool Stack<T>::empty() const
{
  return (size == 0);
}

template<typename T>
T Stack<T>::peek() const
{
  return elements[size - 1];
}

template<typename T>
void Stack<T>::push(T value)
{
  elements[size++] = value;
}

template<typename T>
T Stack<T>::pop()
{
  return elements[--size];
}

template<typename T>
int Stack<T>::getSize() const
{
  return size;
}

template<typename T>
bool Stack<T>::contains(T element) const
{
  for (int i = 0; i < size; i++)
  {
    if (element == elements[i])
    {
      return true;
    }
  }

  return false;
}

int main()
{
  Stack<int> intStack;
  intStack.push(1);
  intStack.push(2);
  intStack.push(3);

  cout << "The stack contains 1: " << intStack.contains(1) << endl;
  cout << "The stack contains 2: " << intStack.contains(2) << endl;
  cout << "The stack contains 3: " << intStack.contains(3) << endl;
  cout << "The stack contains 4: " << intStack.contains(4) << endl;

  return 0;
}




/*
#ifndef STACK_H
#define STACK_H

template<typename T>
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
  T elements[100];
  int size;
};

template<typename T>
Stack<T>::Stack()
{
  size = 0;
}

template<typename T>
bool Stack<T>::empty() const
{
  return (size == 0);
}

template<typename T>
T Stack<T>::peek() const
{
  return elements[size - 1];
}

template<typename T>
void Stack<T>::push(T value)
{
  elements[size++] = value;
}

template<typename T>
T Stack<T>::pop()
{
  return elements[--size];
}

template<typename T>
int Stack<T>::getSize() const
{
  return size;
}

#endif

*/