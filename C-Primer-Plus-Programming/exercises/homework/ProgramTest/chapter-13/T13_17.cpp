#include <iostream>
#include <fstream>

using namespace std;

int main()
{
  // Enter a source file
  cout << "Enter a source file name: ";
  string inputFilename;
  cin >> inputFilename;

  // Enter the numbers of bytes in each smaller file:
    cout << "Enter the number of bytes in each smaller file: ";
    int numberOfBytes;
    cin >> numberOfBytes;

    // Create input stream
    ifstream input(inputFilename.c_str(), ios::binary | ios::in);

    if (input.fail())
    {
      cout << inputFilename << " does not exist" << endl;
      cout << "Exit program" << endl;
      return 0;
    }

    // Get the size of the input file
    int fileSize;
    input.seekg(0, ios::end);
    fileSize = input.tellg();

    // Calculate the number of smaller files
    int numberOfFiles = fileSize / numberOfBytes;
    if (fileSize % numberOfBytes != 0)
      numberOfFiles++;

    // Create the smaller files
    input.seekg(0, ios::beg);
    for (int i = 0; i < numberOfFiles; i++)
    {
      // Create output stream
      string outputFilename = inputFilename + "." + to_string(i);
      ofstream output(outputFilename.c_str(), ios::binary | ios::out);

      // Copy numberOfBytes from input to output
      for (int j = 0; j < numberOfBytes; j++)
      {
        char ch = input.get();
        if (input.eof())
          break;
        output.put(ch);
      }

      output.close();
    }

    input.close();
}

