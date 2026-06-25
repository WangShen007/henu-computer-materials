#include <iostream>
#include <fstream>

using namespace std;

void test01()
{
    // Enter a source file
    cout << "Enter a source file name: ";
    string inputFilename;
    cin >> inputFilename;

    cout<<"Enter a target file name: ";
    string outputFilename;
    cin>>outputFilename;

    ifstream input(inputFilename.c_str(), ios::binary | ios::in);
    ofstream output(outputFilename.c_str(), ios::binary | ios::out);

    if (input.fail())
    {
        cout << inputFilename << " does not exist" << endl;
        cout << "Exit program" << endl;
        return;
    }

    char ch = input.get() - 5;
    while (!input.eof()) // Continue if not end of file
    {
        output.put(ch);
        ch = input.get(); // Read next character
    }

    input.close();
    output.close();


}

int main()
{
    test01();
    return 0;
}
