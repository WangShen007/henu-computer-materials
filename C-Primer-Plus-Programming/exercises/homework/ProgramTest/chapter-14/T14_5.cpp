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


/*int main()
{
  MyString s1("Welcome to C++");
  cin>>s1;
  cout<<s1.data()<<endl;

  return 0;
}*/