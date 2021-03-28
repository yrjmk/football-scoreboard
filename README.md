# Football World Cup Score Board

### General information
.Net Core 3.1  
TDD approach  
Unit testing framework: NUnit  

### Repository structure
* **master** - stable version
* **develop** - development branch, has full development commit history 
 
Develop branch has a lot more commits than I usually do. But since project was so simple, I was committing very small steps.

### TDD Notes
First I wrote all tests, and only after that I started to implement functionality. But during developmnet it was nessesary to change couple data types in unit tests.

### Summary of games order
Since Game Id is always increasing, it is used for order games by time they was added to system. No any additional inforamion is needed.
