#include <iostream>
using namespace std;

class Foo
{
public:
    int x;
    int y;

    Foo()
    {
        x = 10;
        y = 10;
    }

    void p()
    {
        int x = 20;
        cout<<"x is "<<x<<endl;
        cout<<"y is "<<y<<endl;
    }
};

int main()
{
    Foo foo;
    foo.p();

    return 0;
}
