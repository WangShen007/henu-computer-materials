#include <iostream>
#include <vector>

using namespace std;

bool isConsecutiveFour(const vector<vector<int>>& values)
{
    int count = 1;
    for (int i = 0; i < values.size(); i++)
    {
        for (int j = 0; j < values[i].size() - 1; j++)
        {
            if (values[i][j] == values[i][j + 1])
            {
                count++;
                if (count == 4)
                {
                    return true;
                }
            }
            else
            {
                count = 1;
            }
        }
    }
    return false;
}

int main()
{
    vector<vector<int>> values;
    int n;
    cout << "Enter the number of rows in the list: ";
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        vector<int> row;
        int m;
        cout << "Enter the number of elements in row " << i + 1 << ": ";
        cin >> m;
        cout << "Enter the elements of row " << i + 1 << ": ";
        for (int j = 0; j < m; j++)
        {
            int x;
            cin >> x;
            row.push_back(x);
        }
        values.push_back(row);
    }
    cout << "The list has consecutive four numbers: " << (isConsecutiveFour(values) ? "true" : "false") << endl;
    return 0;
}