#include <iostream>
#include <fstream>
#include <ctime>
#include <cstdlib>

using namespace std;
int main()
{
  ofstream output("Exercise13_1.txt");
  if (output.fail())
  {
    cout << "File does not exist" << endl;
    return 0;
  }
  srand(time(0));
  for(int i = 0; i < 100; i++)
  {
    output << rand() << " ";
  }
  output.close();
}







/*#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int main()
{
  // Enter a source file
  cout << "Enter a source file name: ";
  string inputFilename;
  cin >> inputFilename;

  // Enter a target file
  cout << "Enter a target file name: ";
  string outputFilename;
  cin >> outputFilename;

  // Create input and output streams
  ifstream input(inputFilename.c_str());
  ofstream output(outputFilename.c_str());

  if (input.fail())
  {
    cout << inputFilename << " does not exist" << endl;
    cout << "Exit program" << endl;
    return 0;
  }

  char ch = input.get();
  while (!input.eof()) // Continue if not end of file
  {
    output.put(ch);
    ch = input.get(); // Read next character
  }
  /*
  while(!input.eof())
  {
    output.put(input.get());
  }
  *//*
  input.close();
  output.close();

  cout << "\nCopy Done" << endl;

  return 0;
}
*/