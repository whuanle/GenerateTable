# Welcome to the whuanle project

------
**Project introduction：**

This is a console program.
I am a college student, due to lack of experience, the procedure is not perfect. My mailbox is **158652146@qq.com**. Welcome to discuss technical issues.
The program uses more space to reduce the time cost.I used a two-dimensional array to store table information.The program can check the input effectively to confirm whether the input is valid and whether the program can run this command correctly.

----------

**Running environment：**

    Visual studio 2017 (IDE)
    .Net Core 2.2


----------
Files

| file name | describe |
| ------ | ------ |
| CommandModel.cs| The commands you enter in the console must meet the requirements of this Model. |  
| Program.cs | Console program, get your input and control the form. Most of the code is here. |  
| ResponseModel.cs | Returns the status of the function.Tell the user if the run succeeds or fails |
| TableModel.cs | Store table information |


----------

**Description:**
In a nutshell,the program should work as follows:

 - Create a new spread shee Add number in different cells and perform.
 - Some caculation on top of specific row or column
 
| Command | Description | Example |
| ------ | ------ | ------ |
| C w h | should create a new spread sheet of width w and height h(i.e. the spreadsheet can hold w * h amount of cells). | C 20 4 |
| N x1 y1 value | should insert a number in specificed cell(x1,y1) | N 2 3 666 |
| S x1 y1 x2 y2 x3 y3 | should perform sum on top of all cells from x1 y1 to x2 y2 and store the result in x3 y3 | S 1 2 1 3 2 4 |
| Q | Should quit the program | Q |

**Be careful：**
I limit the maximum range of forms.

 - width < 30
 - height < 10

Case sensitive, not lowercase letters.
The maximum number is 999 .

----------


**Test：**
I've done a lot of testing to make sure that the program doesn't crash because of wrong instructions.

Can correctly identify the instructions you enter, if you enter invalid instructions, the program will ask you to re-enter.

When you enter values beyond the table range or invalid, the program can adjust the state without exception.

Unit tests have been added to the project, and NUNIT can be used to complete the testing task.

----------

**Recent modifications：**
time:2019-2-17 9:00
Modified Readme.md.
Some function names and input parameters have been modified.
The coupling degree is reduced.
Adding unit tests: Nunit.

time:2019-2-17 10:03
Use StyleCop. Analyrs for code specification checking.
The quality of the code is checked and part of the code is modified.
Code readability has been improved.