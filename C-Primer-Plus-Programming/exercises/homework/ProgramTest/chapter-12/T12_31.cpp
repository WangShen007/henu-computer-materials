#include <iostream>
#include <vector>

using namespace std;

template <typename T>
vector<T> intersect(const vector<T>& v1, const vector<T>& v2)
{
    vector<T> result;
    for(int i = 0;i < v1.size();i++)
    {
        for(int j = 0;j < v2.size();j++)
        {
            if(v1[i] == v2[j])
            {
                result.push_back(v1[i]);
                break;
            }
        }
    }

    for(int i = 0;i < result.size();i++)
    {
        for(int j = i + 1;j < result.size();j++)
        {
            if(result[i] == result[j])
            {
                result.erase(result.begin() + j);
                j--;
            }
        }
    }
    return result;
}

int main()
{
    cout<<"Enter five strings for vector1: ";
    vector<string> v1(5);
    for(int i = 0;i < v1.size();i++)
    {
        cin>>v1[i];
    }

    cout<<"Enter five strings for vector2: ";
    vector<string> v2(5);
    for(int i = 0;i < v2.size();i++)
    {
        cin>>v2[i];
    }

    vector<string> result = intersect(v1, v2);
    cout<<"The common strings are: ";
    for(int i = 0;i < result.size();i++)
    {
        cout<<result[i]<<" ";
    }
}