#include <iostream>
using namespace std;
void displaySortedNumbers (double num1, double num2, double num3)
{
    if(num1 >= num2 && num2 >= num3)
    {
        cout<<num3 <<" "<<num2<<" "<<num1;
    }
    else if(num1 >= num3 && num3 >= num2)
    {
        cout<<num2 <<" "<<num3<<" "<<num1;
    }
    else if(num2 >= num3 && num3 >= num1)
    {
        cout<<num1 <<" "<<num3<<" "<<num2;
    }
    else if(num2 >= num1 && num1 >= num3)
    {
        cout<<num3 <<" "<<num1<<" "<<num2;
    }
    else if(num3 >= num1 && num1 >= num2)
    {
        cout<<num2 <<" "<<num1<<" "<<num3;
    }
    else
    {
        cout<<num1 <<" "<<num2<<" "<<num3;
    }
}
int main()
{
    double a,b,c;
    cout<<"Enter three numbers: ";
    cin>>a>>b>>c;
    displaySortedNumbers(a,b,c);
}

//max函数 and fmax函数 也可以
//#include <iostream>
//#include <algorithm>
//using namespace std;
//void displaySortedNumbers (double num1, double num2, double num3)
//{
//    double a[] = {num1, num2, num3};
//    sort(a,a + 3);
//    cout<<a[0]<<" "<<a[1]<<" "<<a[2]<<endl;
//}
//int main()
//{
//    double a,b,c;
//    cout<<"Enter three numbers: ";
//    cin>>a>>b>>c;
//    displaySortedNumbers(a,b,c);
//}
