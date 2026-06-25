#include <iostream>
#include <vector>

using namespace std;

class Location
{
private:
    int row;
    int column;
    double maxValue;
public:
    Location()
    {
        row = 0;
        column = 0;
        maxValue = 0;
    }
    Location(int row, int column, double maxValue)
    {
        this->row = row;
        this->column = column;
        this->maxValue = maxValue;
    }
    int getRow()
    {
        return row;
    }
    int getColumn()
    {
        return column;
    }
    double getMaxValue()
    {
        return maxValue;
    }
    void setRow(int row)
    {
        this->row = row;
    }
    void setColumn(int column)
    {
        this->column = column;
    }
    void setMaxValue(double maxValue)
    {
        this->maxValue = maxValue;
    }
};

Location locateLargest(const vector<vector<double>>& a)
{
    Location location;
    location.setMaxValue(a[0][0]);
    for (int i = 0; i < a.size(); i++)
    {
        for (int j = 0; j < a[i].size(); j++)
        {
            if (a[i][j] > location.getMaxValue())
            {
                location.setRow(i);
                location.setColumn(j);
                location.setMaxValue(a[i][j]);
            }
        }
    }
    return location;
}

int main()
{
    vector<vector<double>> matrix(3, vector<double>(3));
    cout<<"Enter a 3-by-3 matrix row by row: ";
    for (int i = 0; i < matrix.size(); i++)
    {
        for (int j = 0; j < matrix[i].size(); j++)
        {
            cin >> matrix[i][j];
        }
    }
    Location location = locateLargest(matrix);
    cout<<"The location of the largest element is "<<location.getMaxValue()<<" at ("<<location.getRow()<<", "<<location.getColumn()<<")"<<endl;
    return 0;
}