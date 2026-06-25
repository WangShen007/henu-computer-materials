#include <iostream>
#include <cstring>

using namespace std;

const int MAXIMUM_SIZE = 100; // Maximum string size 100

class MyString
{
public:
  MyString()
  {
    size = 0;
  }

  MyString(const char* chars)
  {
    int i = 0;
    for (; chars[i] != '\0'; i++)
      value[i] = chars[i];

    size = i;
  }

  char at(int index) const
  {
    return value[index];
  }

  int length() const
  {
    return size;
  }

  void clear()
  {
    size = 0;
  }

  bool empty() const
  {
    return size == 0;
  }

  int compare(const MyString& s) const
  {
    return compare(0, size, s);
  }

  int compare(int index, int n, MyString s) const
  {
    char* s1 = data();
    char* s2 = s.data();

    return strcmp(s1, s2);
  }

  void copy(char s[], int index, int n)
  {
    int i = 0;
    for (; i < size && i < n; i++)
      s[i] = value[i + index];

    i = i + 1;
    s[i] = '\0';
  }

  char* data() const
  {
    char * temp = new char[size + 1];
    for (int i = 0; i < size; i++)
      temp[i] = value[i];

    temp[size] = '\0';

    return temp;
  }

  int find(char ch) const
  {
    return find(ch, 0);
  }

  int find(char ch, int index) const
  {
    for (int i = index; i < size; i++)
      if (value[i] == ch) return i;

    return -1;
  }

  int find(const MyString& s, int index) const
  {
    return -1;
  }
  friend istream& operator>>(istream& in, MyString& s);
  bool operator==(const MyString& s) const
  {
    return compare(s) == 0;
  }
  bool operator!=(const MyString& s) const
  {
    return compare(s) != 0;
  }
  bool operator>(const MyString& s) const
  {
    return compare(s) > 0;
  }
  bool operator>=(const MyString& s) const
  {
    return compare(s) >= 0;
  }
  char operator[](int index) const
  {
    return at(index);
  }
  MyString operator+(const MyString &s) const
  {
    char buffer[MAXIMUM_SIZE];
    for(int i = 0; i < size; i++)
      buffer[i] = value[i];
    for(int i = 0; i < s.size; i++)
      buffer[size + i] = s.value[i];
    buffer[size + s.size] = '\0';
    return MyString(buffer);
  }
  MyString operator+=(const MyString &s)
  {
    char buffer[MAXIMUM_SIZE];
    for(int i = 0; i < size; i++)
      buffer[i] = value[i];
    for(int i = 0; i < s.size; i++)
      buffer[size + i] = s.value[i];
    buffer[size + s.size] = '\0';
    *this = MyString(buffer);
    return *this;
  }

private:
  char value[MAXIMUM_SIZE];
  int size;
}; // Must place a semicolon here

istream& operator>>(istream& in,MyString& s)
{
  char buffer[MAXIMUM_SIZE];
  in>>buffer;
  s = MyString(buffer);
  return in;
}

/*
int main()
{
  MyString s1("Welcome to C++");
  MyString s2("Welcome to C++");

  cout << s1.compare(s2) << endl;
  cout << s1.compare(0, 11, s2) << endl;
  cout << s1.compare(0, 11, s2) << endl;

  MyString s3("Welcome to Java");
  cout << s1.compare(s3) << endl;
  cout << s1.compare(0, 11, s3) << endl;
  cout << s1.compare(0, 11, s3) << endl;

  cout << s1.find('e') << endl;
  cout << s1.find('e', 5) << endl;
  cout << s1.find('x') << endl;

  cout << s1.find(s2, 0) << endl;
  cout << s1.find(s2, 5) << endl;
  cout << s1.find(s3, 0) << endl;

  MyString s4("Welcome to C++");
  cout << (s1 == s4) << endl;
  cout << (s1 != s4) << endl;
  cout << (s1 > s4) << endl;
  cout << (s1 >= s4) << endl;

  MyString s5("Welcome to C");
  cout << (s1 == s5) << endl;
  cout << (s1 != s5) << endl;
  cout << (s1 > s5) << endl;
  cout << (s1 >= s5) << endl;

  MyString s6("Welcome to C++");
  cout << (s1 == s6) << endl;
  cout << (s1 != s6) << endl;
  cout << (s1 > s6) << endl;
  cout << (s1 >= s6) << endl;

  MyString s7("Welcome to C++");
  cout << s7[0] << endl;
  cout << s7[5] << endl;
  cout << s7[11] << endl;

  MyString s8("Welcome to C++");
  MyString s9(" and Java");
  MyString s10 = s8 + s9;
  cout << s10.data() << endl;

  MyString s11("Welcome to C++");
  MyString s12(" and Java");
  s11 += s12;
  cout << s11.data() << endl;

}*/