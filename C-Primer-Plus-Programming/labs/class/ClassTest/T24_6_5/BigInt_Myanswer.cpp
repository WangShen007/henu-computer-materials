#include <cstring>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

const int MAXN = 100;

class BigInt
{
public:
    string data;
    vector<int> v;
    bool isless = false;
    friend istream& operator>>(istream& in, BigInt& b);
    friend ostream& operator<<(ostream& out, BigInt& b);
    BigInt operator-(BigInt b)
    {
        BigInt t;
        bool lessran = false;
        if(v.size() < b.v.size())
        {
            lessran = true;
            for(int i = 0; i < b.v.size() - v.size(); i++)
            {
                v.push_back(0);
            }
        }
        else if(v.size() > b.v.size())
        {
            lessran = false;
            for(int i = 0; i < v.size() - b.v.size(); i++)
            {
                b.v.push_back(0);
            }
        }
        else
        {
            for(int i = v.size() - 1; i >= 0; i--)
            {
                if(v[i] - b.v[i] > 0)
                {
                    lessran = false;
                    break;
                }
                else if(v[i] - b.v[i] < 0)
                {
                    lessran = true;
                    break;
                }
            }
        }
        if(!lessran)//>0
        {
            for(int i = 0; i < v.size(); i++)//100-1
            {
                if(v[i] - b.v[i] >= 0)
                {
                    //t.v[i] = v[i] - b.v[i];
                    t.v.push_back(v[i] - b.v[i]);
                }
                else
                {
                    //t.v[i] = 10 + v[i] - b.v[i];
                    t.v.push_back(10 + v[i] - b.v[i]);
                    v[i + 1] -= 1;
                }
            }
        }
        else//<0
        {
            for(int i = 0; i < v.size(); i++)
            {
                if(b.v[i] - v[i] >= 0)
                {
                    //t.v[i] = b.v[i] - v[i];
                    t.v.push_back(b.v[i] - v[i]);
                }
                else
                {
                    //t.v[i] = 10 + b.v[i] - v[i];
                    t.v.push_back(10 + b.v[i] - v[i]);
                    b.v[i + 1] -= 1;
                }
            }
        }
        t.isless = lessran;
        return t;
    }
};

istream& operator>>(istream& in, BigInt& b)
{
    in >> b.data;
    for(int i = 0; i < b.data.size(); i++)
    {
        b.v.push_back(b.data.at(i) - '0');
    }
    return in;
}

ostream& operator<<(ostream& out, BigInt& b)
{
    //cout<<b.data;
    if(b.isless)
    {
        cout << "-";
    }
    bool zero = true;
    for(int i = b.v.size() - 1; i >= 0; i--)
    {
        cout << b.v[i];
    }
    return out;
}

int main()
{
    BigInt I1, I2;
    BigInt I3;
    cin >> I1 >> I2;
    //cout<<I1<<endl<<I2<<endl;
    I3 = I1 - I2;
    cout << I3 << endl;
    return 0;
}
