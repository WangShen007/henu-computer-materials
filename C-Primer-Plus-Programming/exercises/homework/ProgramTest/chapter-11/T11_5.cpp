#include <iostream>

using namespace std;

double min(double* array, int size)
{
    double min = array[0];
    for(int i = 1;i < size;i++)
    {
        if(array[i] < min)
        {
            min = array[i];
        }
    }
    return min;
}

int main()
{
    double array[10];
    cout<<"Enter 10 double numbers: ";
    for(int i = 0;i < 10;i++)
    {
        cin>>array[i];
    }
    cout<<"The minimum number is: ";
    cout<<min(array, 10)<<endl;
    return 0;

}