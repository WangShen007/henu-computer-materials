#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

bool AllOnes(vector<int> &input)
{
    for(int i = 0;i < input.size();i++)
    {
        if(input[i] != 1)
        {
            return false;
        }
    }
    return true;
}

bool AllZeros(vector<int> &input)
{
    for(int i = 0;i < input.size();i++)
    {
        if(input[i] != 0)
        {
            return false;
        }
    }
    return true;
}

int main()
{
    srand(time(0));
    cout<<"Enter the size of the matrix: ";
    int n;
    cin>>n;
    vector<vector<int>> m(n, vector<int>(n));
    for(int i = 0;i < m.size();i++)
    {
        for(int j = 0;j < m[i].size();j++)
        {
            m[i][j] = rand() % 2;
            cout << m[i][j] << " ";
        }
        cout << endl;
    }

    vector<bool> rowones(n, false);
    vector<bool> rowzeros(n, false);
    bool rowexist = false;
    for(int i = 0;i < m.size();i++)
    {
        if(AllOnes(m[i]))
        {
            rowones[i] = true;
            rowexist = true;
        }
        if(AllZeros(m[i]))
        {
            rowzeros[i] = true;
            rowexist = true;
        }
    }
    if(!rowexist)
    {
        cout << "No same numbers on a row" << endl;
    }
    else
    {
        cout<<"All 1s on row: ";
        for(int i = 0;i < rowones.size();i++)
        {
            if(rowones[i])
            {
                cout << i << ", ";
            }
        }
        cout << endl;
        cout << "All 0s on row: ";
        for(int i = 0;i < rowzeros.size();i++)
        {
            if(rowzeros[i])
            {
                cout << i << ", ";
            }
        }
    }

    vector<bool> columnones(n, false);
    vector<bool> columnzeros(n, false);
    bool columnexist = false;
    for(int i = 0;i < m[0].size();i++)
    {
        vector<int> column;
        for(int j = 0;j < m.size();j++)
        {
            column.push_back(m[j][i]);
        }
        if(AllOnes(column))
        {
            columnones[i] = true;
            columnexist = true;
        }
        if(AllZeros(column))
        {
            columnzeros[i] = true;
            columnexist = true;
        }
    }
    if(!columnexist)
    {
        cout << "No same numbers on a column" << endl;
    }
    else
    {
        cout<<"All 1s on column: ";
        for(int i = 0;i < columnones.size();i++)
        {
            if(columnones[i])
            {
                cout << i << ", ";
            }
        }
        cout << endl;

        cout << "All 0s on column: ";
        for(int i = 0;i < columnzeros.size();i++)
        {
            if(columnzeros[i])
            {
                cout << i << ", ";
            }
        }
        cout << endl;
    }

    vector<int> diagonal;
    for(int i = 0;i < m.size();i++)
    {
        diagonal.push_back(m[i][i]);
    }
    if(AllOnes(diagonal))
    {
        cout << "All 1s on diagonal" << endl;
    }
    else if(AllZeros(diagonal))
    {
        cout << "All 0s on diagonal" << endl;
    }
    else
    {
        cout << "No same numbers on the major diagonal" << endl;
    }

    vector<int> diagonal2;
    for(int i = 0;i < m.size();i++)
    {
        diagonal2.push_back(m[i][m.size() - 1 - i]);
    }
    if(AllOnes(diagonal2))
    {
        cout << "All 1s on the sub-diagonal" << endl;
    }
    else if(AllZeros(diagonal2))
    {
        cout << "All 0s on the sub-diagonal" << endl;
    }
    else
    {
        cout << "No same numbers on the sub-diagonal" << endl;
    }
}