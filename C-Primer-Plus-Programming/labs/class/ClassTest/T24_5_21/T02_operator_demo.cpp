#include <iostream>
using namespace std;

class Matrix
{
public:
    int row;
    int column;
    int **data;
    
    Matrix() 
    {
        row = column = 0;
        data = NULL;
    }
    Matrix(int r, int c) 
    {
        row = r;
        column = c;
        data = new int*[row];
        for(int i = 0; i < row; i++)
        {
            data[i] = new int[column];
        }
    }
    ~Matrix() 
    {
        for(int i = 0; i < row; i++)
        {
            delete[] data[i];
        }
        delete[] data;
        data = NULL;
        row = column = 0;
    }
    
    friend istream& operator>>(istream &istr, Matrix &mat)
    {
        for(int i = 0; i < mat.row; i++)
        {
            for(int j = 0; j < mat.column; j++)
            {
                istr >> mat.data[i][j];
            }
        }
        return istr;
    }
    
    friend ostream& operator<<(ostream &ostr, Matrix mat);
    
    Matrix operator+(const Matrix &mat)
    {
        Matrix newMat(row, column);
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < column; j++)
            {
                newMat.data[i][j] = data[i][j] + mat.data[i][j];
            }
        }
        return newMat;
    }
    
    Matrix operator-(const Matrix &mat);
};

ostream& operator<<(ostream &ostr, Matrix mat)
{
    for(int i = 0; i < mat.row; i++)
    {
        for(int j = 0; j < mat.column; j++)
        {
            ostr << mat.data[i][j];
            if (j < mat.column - 1) ostr << " ";
        }
        ostr << endl;
    }
    return ostr;
}

Matrix Matrix::operator-(const Matrix &mat)
{
    Matrix newMat(row, column);
    for(int i = 0; i < row; i++)
    {
        for(int j = 0; j < column; j++)
        {
            newMat.data[i][j] = data[i][j] - mat.data[i][j];
        }
    }
    return newMat;
}

int main()
{
    int i,j;
    cin >> i >> j;
    Matrix m1(i,j), m2(i,j);
    cin >> m1;
    cin >> m2;

    cout << "m1 + m2 :" << endl ;
    cout << (m1+m2);
    cout << "m1 - m2 :" << endl ;
    cout << (m1-m2);
    return 0;
}
