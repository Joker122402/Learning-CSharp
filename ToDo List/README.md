# To-Do List
This is my first ever C# Project. This is my take on the capstone project from ZeroPoint Security's C# for n00bs course. 

The goal was simple, build a To-Do List console application that allows users to do 4 things:
1. List the title of all items on the list.
2. List detailed info about specific items on the list.
3. Add items to the list.
4. Remove items from the list.

As for how to implement those features; thats left up to the student. 

Currently, the code consists of 3 files: ToDoList.cs, ToDoListItem.cs and Run.cs

## ToDoList.cs
My implementation of a To-Do list. It has 3 Properties: Title, Description and Items. 
Currently Title and Description are unused, but eventually I want to add functionality to create multiple To-Do List.
Items is a List of type ToDoListItem that stores all the items in the list.

It also has the 4 methods that implement the required functions.

## ToDoListItem.cs
Since each item stores 5 seperate pieces of data (Title, Description, Priority, Status and DueDate) I decided it would be far easier to create a class.

## Run.cs
This is the runner for the program. Its responsible for displaying the menu (which lists possible choices to the user) as well as handling the user input. 
