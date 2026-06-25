#include <iostream>
#include <fstream>
#include <cstdlib>
#include <ctime>

using namespace std;

void test01()
{
    ofstream ofs;
    if(ofs.fail())
    {
        ofs.open("Exercise13_13.dat", ios::out | ios::binary);
        if (!ofs)
        {
            cerr << "Error opening file for output" << endl;
            return;
        }
        for(int i = 0; i < 100; i++)
        {
            int n = rand() % 100;
            ofs.write((const char *)&n, sizeof(n));
        }
        ofs.close();
    }
    else
    {
        ofs.open("Exercise13_13.dat", ios::out | ios::binary | ios::app);
        if (!ofs)
        {
            cerr << "Error opening file for output" << endl;
            return;
        }
        for(int i = 0; i < 100; i++)
        {
            int n = rand() % 100;
            ofs.write((const char *)&n, sizeof(n));
        }
        ofs.close();
    }
}

void test02()
{
    ifstream ifs;
    ifs.open("Exercise13_13.dat", ios::in | ios::binary);
    if (!ifs)
    {
        cerr << "Error opening file for input" << endl;
        return;
    }
    int n;
    while(ifs.read((char *)&n, sizeof(n)))
    {
        cout << n << " ";
    }
    cout << endl;
    ifs.close();
}

int main()
{
    srand(time(0));
    test01();
    //test02();
    return 0;
}