#include <iostream>

using namespace std;

class Location
{
public:
int row;
int column;
double maxValue;
const int ROW_SIZE = 3;
const int COLUMN_SIZE = 4;

};

Location locateLargest(double a[][4])
{
    Location location;
    location.maxValue = a[0][0];
    location.row = 0;
    location.column = 0;
    for(int i = 0;i < 3;i++)
    {
        for(int j = 0;j < 4;j++)
        {
            if(a[i][j] > location.maxValue)
            {
                location.maxValue = a[i][j];
                location.row = i;
                location.column = j;
            }
        }
    }
    return location;
}

int main()
{
    cout<<"Enter a 3-by-4 matrix row by row: ";
    double a[3][4];
    /*for(int i = 0;i < 3;i++)
    {
        for(int j = 0;j < 4;j++)
        {
            cin >> a[i][j];
        }
    }*/
    for(int i = 0;i < 3;i++)
    {
        for(int j = 0;j < 4;j++)
        {
            a[i][j] = i + j;
        }
    }
    Location location = locateLargest(a);
    cout << "The location of the largest element is " << location.maxValue << " at (" << location.row << ", " << location.column << ")" << endl;
    return 0;
}