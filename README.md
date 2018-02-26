# Data Driven Testing

This project is for learning purposes. Specifically to learn how to create a data driven testing framework using TDD. 

## Structure of Project
### TestDataAccess project:
  This part contains all the classes that are needed for the testing framework, it also includes unit tests for the testing framework.

* **JSONFile Class**:
  This class represents a JSON file. An instance is created using the fullpath(including file name), or using the path and the file name.
The path is validated in the constructor, to make sure the file exists and the path and name are in the correct format and not null.
  Example:
  ```
  var jsonFile = new JSONFile("C:/test.json");
  var jsonFile = new JSONFile("C:/Projects", "testdata.json");
  ```

* **JSONReader Class** :
  This class represents a JSONReader for a specific JSONFile. The constructor must be provided with an instance of the JSONFile class that represents the JSON File that contains the test data.
    Example:
    `var JSONReader = new JSONReader(jsonFile);`
     where jsonFile is an instance of the JSONFile class.

### TestDataAccess.Tests project:
This part of the project contains the unit tests for the testing framework in TestDataAccess, and some demonstrational testing data to make sure both the JSONFile Class and the JSONReader class behave as expected.

* **JSONFileTests**:
  Is a TestFixture that contains unit tests for the JSONFile Class.

* **JSONReaderTests** :
  Is a TestFixture that contains unit tests for the JSONReader Class.
  
* **testData.json** : 
  Contains some demonstrational test data (in JSON format) for the sake of test driven development of the testing framework created in the TestDataAccess project.