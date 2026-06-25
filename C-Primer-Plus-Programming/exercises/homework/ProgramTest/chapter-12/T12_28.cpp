#include <iostream>
#include <cstdlib>
#include <ctime>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    srand(time(0));
    vector<vector<int>> m(4, vector<int>(4));
    for(int i = 0;i < m.size();i++)
    {
        for(int j = 0;j < m[i].size();j++)
        {
            m[i][j] = rand() % 2;
        }
    }
    vector<int> countRow(m.size(), 0);
    vector<int> countColumn(m[0].size(), 0);
    for(int i = 0;i < m.size();i++)
    {
        for(int j = 0;j < m[i].size();j++)
        {
            cout << m[i][j] << " ";
            if(m[i][j] == 1)
            {
                countRow[i]++;
                countColumn[j]++;
            }
        }
        cout << endl;
    }
    cout<<"The largest row index: ";
    for(int i = 0;i < countRow.size();i++)
    {
        if(countRow[i] == *max_element(countRow.begin(), countRow.end()))
        {
            cout << i << ", ";
        }
    }
    cout << endl;
    cout << "The largest column index: ";
    for(int i = 0;i < countColumn.size();i++)
    {
        if(countColumn[i] == *max_element(countColumn.begin(), countColumn.end()))
        {
            cout << i << ", ";
        }
    }


}