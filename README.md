# Data Driven Testing

## Overview:
This project is for learning purposes. Specifically to learn how to create a data driven testing framework using TDD. 
It is written in C#, and it is assumed that the testing data will be present in a JSON file. So we first started working on creating a framework that would enable us to retrieve the test data from the JSON File using inputs like the property and index of the needed data for any given test. 

In order to be able to read the test data efficiently from the JSON file, we used [Newtonsoft's JSON.Net Library](https://www.newtonsoft.com/json/help/html/Introduction.htm).

For the sake of encapsulation, and seperatation of concerns we created a JSONFile class, with 2 constructors. This class is the only parameter that constuctors for the JSONReader class constructor takes in order to be able to read the data from the JSON file using the different available methods in the class.

The entire process of building these classes was aided by the use of Test Driven Development.

## Structure of Project
### TestDataAccess project:
  This part contains all the classes that are needed for the testing framework, it also includes unit tests for the testing framework.

* **JSONFile Class**:
  This class represents a JSON file. An instance is created using the fullpath(including file name), or using the path and the file name.
The path is validated in the constructor, to make sure the file exists and the path and name are in the correct format and not null.
  Example:
  ```C#
  // Constructor 1# (Accepts full path):
  var jsonFile = new JSONFile("C:/test.json");
  
  // Constructor 2# (Accepts parent folder, and filename):
  var jsonFile = new JSONFile("C:/Projects", "testdata.json");
  ```

* **JSONReader Class** :
  This class represents a JSONReader for a specific JSONFile. The constructor must be provided with an instance of the JSONFile class that represents the JSON File that contains the test data.
    Example:
    ```C#
    // Constructor 1#:
    var JSONReader = new JSONReader(jsonFile);
    ```
     
     where jsonFile is an instance of the JSONFile class.

### TestDataAccess.Tests project:
This part of the project contains the unit tests for the testing framework in TestDataAccess, and some demonstrational testing data to make sure both the JSONFile Class and the JSONReader class behave as expected.

* **JSONFileTests**:
  Is a TestFixture that contains unit tests for the JSONFile Class.

* **JSONReaderTests** :
  Is a TestFixture that contains unit tests for the JSONReader Class.
  
* **testData.json** : 
  Contains some demonstrational test data (in JSON format) for the sake of test driven development of the testing framework created in the TestDataAccess project.
