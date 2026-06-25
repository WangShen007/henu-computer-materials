#include <iostream>
#include <vector>

using namespace std;

const int SIZE = 2;
bool SameLine(const vector<vector<double>> &points, int numberOfPoints)
{
    double slope = (points[1][1] - points[0][1]) / (points[1][0] - points[0][0]);
    for (int i = 2; i < numberOfPoints; i++)
    {
        if (slope != (points[i][1] - points[0][1]) / (points[i][0] - points[0][0]))
        {
            return false;
        }
    }
    return true;
}

int main()
{
    vector<vector<double>> points(SIZE, vector<double>(SIZE));
    cout << "Enter " << SIZE << " points: ";
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            cin >> points[i][j];
        }
    }
    /*points[0][0] = 1;
    points[0][1] = 2;
    points[1][0] = 2;
    points[1][1] = 3;*/
    if (SameLine(points, SIZE))
    {
        cout << "The points are on the same line" << endl;
    }
    else
    {
        cout << "The points are not on the same line" << endl;
    }
}