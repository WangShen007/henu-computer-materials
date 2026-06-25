#include <iostream>

class StackOfIntegers
{
public:
  StackOfIntegers();
  bool isEmpty() const;
  int peek() const;
  void push(int value);
  int pop();
  int getSize() const;
  int &operator[](int index)
  {
    return elements[index];
  }

private:
  int elements[100];
  int size;
};

StackOfIntegers::StackOfIntegers()
{
  size = 0;
}

bool StackOfIntegers::isEmpty() const
{
  return (size == 0);
}

int StackOfIntegers::peek() const
{
  return elements[size - 1];
}

void StackOfIntegers::push(int value)
{
  elements[size++] = value;
}

int StackOfIntegers::pop()
{
  return elements[--size];
}

int StackOfIntegers::getSize() const
{
  return size;
}
