#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    cout<<"Enter the number of source files: ";
    int numberOfFiles;
    cin>>numberOfFiles;

    string * inputFilename = new string[numberOfFiles];
    for(int i = 0;i < numberOfFiles;i++)
    {
        cout<<"Enter a source file: ";
        cin>>inputFilename[i];
    }

    string outputFilename;
    cout<<"Enter a target file: ";
    cin>>outputFilename;

    ofstream output(outputFilename.c_str(), ios::binary | ios::out);

    for(int i = 0;i < numberOfFiles;i++)
    {
        ifstream input(inputFilename[i].c_str(), ios::binary | ios::in);

        if (input.fail())
        {
            cout << inputFilename[i] << " does not exist" << endl;
            cout << "Exit program" << endl;
            return 0;
        }

        char ch = input.get();
        while (!input.eof()) // Continue if not end of file
        {
            output.put(ch);
            ch = input.get(); // Read next character
            if(input.eof())
                break;
        }

        input.close();
    }
    output.close();
}