#include <iostream>
#include <vector>
#include <string>
#include <cctype>
#include <cmath>

using namespace std;

template<typename T>
class Stack
{
private:
  T* elements;
  int size;
  int capacity;
  void ensureCapacity();
public:
  Stack();
  Stack(const Stack&);
  ~Stack();
  bool empty() const;
  T peek() const;
  void push(T value);
  T pop();
  int getSize() const;
};

template<typename T>
Stack<T>::Stack(): size(0), capacity(16)
{
  elements = new T [capacity];
}

template<typename T>
Stack<T>::Stack(const Stack& stack)
{
  elements = new T [stack.capacity];
  size = stack.size;
  capacity = stack.capacity;
  for( int i = 0;i < size;i++)
  {
    elements[i] = stack.elements[i];
  }
}

template<typename T>
Stack<T>::~Stack()
{
  delete [] elements;
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
  ensureCapacity();
  elements[size++] = value;
}

template<typename T>
void Stack<T>::ensureCapacity()
{
  if(size >= capacity)
  {
    T* old = elements;
    capacity = 2 * size;
    elements = new T [capacity];
    for(int i = 0;i < size;i++)
    {
      elements[i] = old[i];
    }

    delete [] old;
  }
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

string infixToPostfix(const string& expression)
{
  Stack<char> operatorStack;
  string postfix = "";
  for(int i = 0;i < expression.length();i++)
  {
    if(expression[i] == ' ')
    {
      continue;
    }
    if(isdigit(expression[i]))
    {
      postfix += expression[i];
      postfix += ' ';
    }
    else if(expression[i] == '(')
    {
      operatorStack.push(expression[i]);
    }
    else if(expression[i] == ')')
    {
      while(operatorStack.peek() != '(')
      {
        postfix += operatorStack.pop();
        postfix += ' ';
      }
      operatorStack.pop();
    }
    else
    {
      while(!operatorStack.empty() && operatorStack.peek() != '(' && (expression[i] == '+' || expression[i] == '-') && (operatorStack.peek() == '*' || operatorStack.peek() == '/'))
      {
        postfix += operatorStack.pop();
      }
      operatorStack.push(expression[i]);
    }
  }

  while(!operatorStack.empty())
  {
    postfix += operatorStack.pop();
  }

  return postfix;
}

int main()
{
    string expression;
    cout << "Enter an expression: ";
    getline(cin, expression);
    string postfix = infixToPostfix(expression);
    cout << "The postfix expression is " << postfix << endl;
    return 0;
}