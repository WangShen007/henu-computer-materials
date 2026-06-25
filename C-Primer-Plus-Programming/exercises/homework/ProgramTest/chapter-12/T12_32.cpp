#include <iostream>
#include <vector>

using namespace std;

template<typename T>
void removeDuplicate(vector<T>& v)
{
    for(int i = 0;i < v.size();i++)
    {
        for(int j = i + 1;j < v.size();j++)
        {
            if(v[i] == v[j])
            {
                v.erase(v.begin() + j);
                j--;
            }
        }
    }
}

int main()
{
    cout<<"Enter ten integers: ";
    vector<int> v(10);
    for(int i = 0;i < v.size();i++)
    {
        cin>>v[i];
    }

    removeDuplicate(v);
    cout<<"The distinct integers are: ";
    for(int i = 0;i < v.size();i++)
    {
        cout<<v[i]<<" ";
    }
    cout<<endl;
    return 0;
}