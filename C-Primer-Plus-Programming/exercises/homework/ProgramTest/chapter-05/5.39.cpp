#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    double totalMoney = 0;
    double basicMoney = 5000;
    double salesMoney = 15000;//0 start is a dead loop
    double commissionRate;
    do{
        if(salesMoney >= 0.01 && salesMoney <= 5000)
        {
            commissionRate = 0.08;
            totalMoney = salesMoney * commissionRate + basicMoney;
            salesMoney += 0.01;
        }
        else if(salesMoney >= 5000.01 && salesMoney <= 10000)
        {
            commissionRate = 0.10;
            totalMoney = 5000 * 0.08 + (salesMoney - 5000.0) * commissionRate + basicMoney;
            salesMoney += 0.01;
        }
        else if(salesMoney >= 10000.01)
        {
            commissionRate = 0.12;
            totalMoney = 5000 * 0.08 + 5000 * 0.10 + (salesMoney - 10000.0) * commissionRate + basicMoney;
            salesMoney += 0.01;
        }
    }while(totalMoney < 30000);

    cout<<fixed<<setprecision(2)<<salesMoney<<endl;
}
