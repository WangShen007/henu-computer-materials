#include <iostream>

using namespace std;

class stock
{
public:
    string symbol;
    string name;
    double previousClosingPrice;
    double currentPrice;
    stock(string symbol, string name)
    {
        this->symbol = symbol;
        this->name = name;
    }
    string getsymbol() const
    {
        return symbol;
    }
    string getname() const
    {
        return name;
    }

    double getpreviousClosingPrice() const
    {
        return previousClosingPrice;
    }

    double getcurrentPrice() const
    {
        return currentPrice;
    }

    void setpreviousClosingPrice(double previousClosingPrice)
    {
        this->previousClosingPrice = previousClosingPrice;
    }

    void setcurrentPrice(double currentPrice)
    {
        this->currentPrice = currentPrice;
    }

    double getChangePercent() const
    {
        return ((currentPrice - previousClosingPrice) / previousClosingPrice) * 100;
    }
};

int main()
{
    stock stock1("MSFT", "Microsoft Corporation");
    stock1.setpreviousClosingPrice(27.5);
    stock1.setcurrentPrice(27.6);
    cout << "The price-change percentage is: " << stock1.getChangePercent() << "%" << endl;
}