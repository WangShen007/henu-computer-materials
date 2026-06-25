#include <iostream>
using namespace std;

template <typename T>

int linearSearch(T list[], T key, int arraySize)
{
  for (int i = 0; i < arraySize; i++)
  {
    if (key == list[i])
      return i;
  }

  return -1;
}

int main()
{
    int list[] = {1, 4, 4, 2, 5, -3, 6, 2};
    double list2[] = {1.1, 4.4, 4.4, 2.2, 5.5, -3.3, 6.6, 2.2};
    string list3[] = {"a", "b", "b", "c", "d", "e", "f", "g"};
    int i = linearSearch(list, 4, 8);  // returns 1
    int j = linearSearch(list, -4, 8); // returns -1
    int k = linearSearch(list, -3, 8); // returns 5
    int l = linearSearch(list2, 4.4, 8);  // returns 1
    int m = linearSearch(list2, -4.4, 8); // returns -1
    int n = linearSearch(list2, -3.3, 8); // returns 5
    int o = linearSearch<string>(list3, "b", 8);  // returns 1
    int p = linearSearch<string>(list3, "z", 8); // returns -1
    int q = linearSearch<string>(list3, "e", 8); // returns 5

    cout << i << " " << j << " " << k << " " << l << " " << m << " " << n << " " << o << " " << p << " " << q << endl;
    return 0;
}



















/*
#include <iostream>
using namespace std;

int linearSearch(int [], int, int);

int main()
{
  int list[] = {1, 4, 4, 2, 5, -3, 6, 2};
  int i = linearSearch(list, 4, 8);  // returns 1
  int j = linearSearch(list, -4, 8); // returns -1
  int k = linearSearch(list, -3, 8); // returns 5

  cout << i << " " << j << " " << k << endl;
  return 0;
}

int linearSearch(int list[], int key, int arraySize)
{
  for (int i = 0; i < arraySize; i++)
  {
    if (key == list[i])
      return i;
  }

  return -1;
}

*/