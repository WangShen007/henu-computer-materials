#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

template <typename T>
void shuffle(vector<T>& v)
{
    vector<T> temp;
    srand(time(0));
    for(int n = v.size(); n > 0; n--)
    {
        int r = rand() % n;
        temp.push_back(v[r]);
        v.erase(v.begin() + r);
    }
    v = temp;
}

int main()
{
    vector<int> v = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    shuffle(v);
    for(int i = 0;i < v.size();i++)
    {
        cout << v[i] << " ";
    }
    cout << endl;
    return 0;
}