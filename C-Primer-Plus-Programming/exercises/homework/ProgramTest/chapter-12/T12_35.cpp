#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

vector<int> getFactors(int n)
{
    vector<int> factors;
    for (int i = 2; i <= sqrt(n); i++)
    {
        while (n % i == 0)
        {
            factors.push_back(i);
            n /= i;
        }
    }
    if (n > 1)
    {
        factors.push_back(n);
    }
    return factors;
}

vector<int> getUniqueFactors(vector<int> factors)
{
    vector<int> uniqueFactors(0);
    for(int i = 0; i < factors.size(); i++)
    {
        bool isUnique = true;
        for(int j = 0; j < uniqueFactors.size(); j++)
        {
            if(factors[i] == uniqueFactors[j])
            {
                isUnique = false;
                break;
            }
        }
        if(isUnique)
        {
            uniqueFactors.push_back(factors[i]);
        }
    }
    return uniqueFactors;
}

int findSmallestNumber(vector<int> factors)
{
    vector<int> uniqueFactors = getUniqueFactors(factors);
    int result = 1;
    for(int i = 0; i < uniqueFactors.size(); i++)
    {
        int count = 0;
        for(int j = 0; j < factors.size(); j++)
        {
            if(uniqueFactors[i] == factors[j])
            {
                count++;
            }
        }
        if(count % 2 != 0)
        {
            result *= uniqueFactors[i];
        }
    }

    return result;
}

int main()
{
    cout<<"Enter an integer m: ";
    int m;
    cin>>m;
    cout<<"The smallest number n for m * n to be a perfect square is ";
    vector<int> factors = getFactors(m);
    int smallestNumber = findSmallestNumber(factors);
    cout<<smallestNumber<<endl;
    cout<<"m * n is "<<m * smallestNumber<<endl;
}

/*

#include <iostream>
#include <cmath>
#include <vector>
#include <unordered_map>

using namespace std;

// 获取整数 n 的质因数
vector<int> getFactors(int n)
{
    vector<int> factors;
    for (int i = 2; i <= sqrt(n); i++)
    {
        while (n % i == 0)
        {
            factors.push_back(i);
            n /= i;
        }
    }
    if (n > 1)
    {
        factors.push_back(n);
    }
    return factors;
}

// 计算最小整数 n 使得 m * n 是一个完全平方数
int findSmallestNumber(const vector<int>& factors)
{
    unordered_map<int, int> factorCounts;

    // 统计每个质因数的出现次数
    for (int factor : factors)
    {
        factorCounts[factor]++;
    }

    int result = 1;
    // 如果质因数出现的次数是奇数，则需要再乘以一个该质因数来使次数变为偶数
    for (const auto& pair : factorCounts)
    {
        if (pair.second % 2 != 0)
        {
            result *= pair.first;
        }
    }
    return result;
}

int main()
{
    cout << "Enter an integer m: ";
    int m;
    cin >> m;
    cout << "The smallest number n for m * n to be a perfect square is ";
    vector<int> factors = getFactors(m);
    int smallestNumber = findSmallestNumber(factors);
    cout << smallestNumber << endl;
    cout << "m * n is " << m * smallestNumber << endl;
}

*/