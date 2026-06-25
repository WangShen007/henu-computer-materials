#include <iostream>
#include <vector>
#include <cmath>

using namespace std;

double det(const vector<vector<double>>& matrix)
{
    double determinant = 0;
    if (matrix.size() == 1)
    {
        return matrix[0][0];
    }
    else if (matrix.size() == 2)
    {
        return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
    }
    else
    {
        for (int i = 0; i < matrix.size(); i++)
        {
            vector<vector<double>> submatrix;
            for (int j = 1; j < matrix.size(); j++)
            {
                vector<double> row;
                for (int k = 0; k < matrix[j].size(); k++)
                {
                    if (k != i)
                    {
                        row.push_back(matrix[j][k]);
                    }
                }
                submatrix.push_back(row);
            }
            determinant += matrix[0][i] * det(submatrix) * (i % 2 == 0 ? 1 : -1);
        }
    }
    return determinant;
}

double calcCramer(const vector<vector<double>>& matrix, const vector<double>& b, int index)
{
    vector<vector<double>> newMatrix = matrix;
    for (int i = 0; i < matrix.size(); i++)
    {
        newMatrix[i][index] = b[i];
    }
    return det(newMatrix) / det(matrix);
}

int main()
{
    vector<vector<double>> matrix(3, vector<double>(3));
    cout<<"Enter a11, a12, a13, a21, a22, a23, a31, a32, a33: ";
    for (int i = 0; i < matrix.size(); i++)
    {
        for (int j = 0; j < matrix[i].size(); j++)
        {
            cin >> matrix[i][j];
        }
    }
    cout<<"Enter b1, b2, b3: ";
    vector<double> b(3);
    for (int i = 0; i < b.size(); i++)
    {
        cin >> b[i];
    }
    double d = det(matrix);
    if (d == 0)
    {
        cout << "No solution" << endl;
    }
    else
    {
        cout << "x = " << (fabs(calcCramer(matrix, b, 0) - 0) < 1e-10 ? 0 : calcCramer(matrix, b, 0)) << endl;
        cout << "y = " << (fabs(calcCramer(matrix, b, 1) - 0) < 1e-10 ? 0 : calcCramer(matrix, b, 1)) << endl;
        cout << "z = " << (fabs(calcCramer(matrix, b, 2) - 0) < 1e-10 ? 0 : calcCramer(matrix, b, 2)) << endl;
    }
}