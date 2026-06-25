#include <iostream>
#include <vector>

using namespace std;

vector<int> findLargestBlock(const vector<vector<int>>& m)
{
    vector<int> result(3);
    vector<vector<int>> s(m.size(), vector<int>(m[0].size()));
    for (int i = 0; i < m.size(); i++)
    {
        for (int j = 0; j < m[i].size(); j++)
        {
            if (m[i][j] == 1)
            {
                s[i][j] = 1;
            }
        }
    }
    for (int i = 1; i < m.size(); i++)
    {
        for (int j = 1; j < m[i].size(); j++)
        {
            if (m[i][j] == 1)
            {
                s[i][j] = min(s[i - 1][j - 1], min(s[i - 1][j], s[i][j - 1])) + 1;
            }
        }
    }
    int max = s[0][0];
    int maxRow = 0;
    int maxColumn = 0;
    for (int i = 0; i < s.size(); i++)
    {
        for (int j = 0; j < s[i].size(); j++)
        {
            if (s[i][j] > max)
            {
                max = s[i][j];
                maxRow = i;
                maxColumn = j;
            }
        }
    }
    result[0] = maxRow;
    result[1] = maxColumn;
    result[2] = max;
    return result;
}

int main()
{
    vector<vector<int>> m(6, vector<int>(6));
    cout << "Enter a 6-by-6 matrix row by row: ";
    for (int i = 0; i < m.size(); i++)
    {
        for (int j = 0; j < m[i].size(); j++)
        {
            cin >> m[i][j];
        }
    }
    vector<int> result = findLargestBlock(m);
    cout << "The maximum square submatrix is at (" << result[0] << ", " << result[1] << ") with size " << result[2] << endl;
    return 0;
}