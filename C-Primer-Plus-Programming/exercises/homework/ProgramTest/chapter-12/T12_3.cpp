#include <iostream>
#include <algorithm>

using namespace std;

template <typename T>

int binarySearch(const T list[], T key, int listSize)
{
  int low = 0;
  int high = listSize - 1;

  while (high >= low)
  {
    int mid = (low + high) / 2;
    if (key < list[mid])
      high = mid - 1;
    else if (key == list[mid])
      return mid;
    else
      low = mid + 1;
  }

  return -low - 1;
}

int main()
{
    int list[] = {1, 4, 4, 2, 5, -3, 6, 2};
    sort(list, list + 8);
    int i = binarySearch(list, 4, 8);  // returns 1
    int j = binarySearch(list, -4, 8); // returns -1
    int k = binarySearch(list, -3, 8); // returns 5

    cout << i << " " << j << " " << k << endl;

    double list2[] = {1.1, 4.4, 4.4, 2.2, 5.5, -3.3, 6.6, 2.2};
    sort(list2, list2 + 8);
    double l = binarySearch(list2, 4.4, 8);  // returns 1
    double m = binarySearch(list2, -4.4, 8); // returns -1
    double n = binarySearch(list2, -3.3, 8); // returns 5

    cout << l << " " << m << " " << n << endl;

    string list3[] = {"a", "b", "b", "c", "d", "e", "f", "g"};
    sort(list3, list3 + 8);
    int o = binarySearch<string>(list3, "b", 8);  // returns 1
    int p = binarySearch<string>(list3, "z", 8); // returns -1
    int q = binarySearch<string>(list3, "e", 8); // returns 5

    cout << o << " " << p << " " << q << endl;

    return 0;
}























/*

int binarySearch(const int list[], int key, int listSize)
{
  int low = 0;
  int high = listSize - 1;

  while (high >= low)
  {
    int mid = (low + high) / 2;
    if (key < list[mid])
      high = mid - 1;
    else if (key == list[mid])
      return mid;
    else
      low = mid + 1;
  }

  return -low - 1;
}



#include <iostream>
using namespace std;

int binarySearch(const int list[], int key, int listSize);

int main()
{
  int list[] = {1, 4, 4, 2, 5, -3, 6, 2};
  int i = binarySearch(list, 4, 8);  // returns 1
  int j = binarySearch(list, -4, 8); // returns -1
  int k = binarySearch(list, -3, 8); // returns 5

  cout << i << " " << j << " " << k << endl;
  return 0;
}

int binarySearch(const int list[], int key, int listSize)
{
  int low = 0;
  int high = listSize - 1;

  while (high >= low)
  {
    int mid = (low + high) / 2;
    if (key < list[mid])
      high = mid - 1;
    else if (key == list[mid])
      return mid;
    else
      low = mid + 1;
  }

  return -low - 1;
}


*/