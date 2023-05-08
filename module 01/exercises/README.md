# Module 01 - XAML - Exercises

## Exercise 01 - XAML
### Introduction
In this exercise we will practice using XAML as a language for instansiation of objects and population of properties. We will pracice:
1. Defining classes
2. Instantiating the classes in XAML
3. Populating atomic properties
4. Populating complex properties
5. Writing Type convertors
6. Populating lists
7. Populating dictionaries

### Steps
1. Create the following classes:
    - `Exam`
        * DisplayName: `string`
        * Questions: `List<Question>`
        * Answers: 
    - `Question`
        * Caption: `string`
        * Answers: `List<string>`
        * CorrectAnswer: `int`
    - `Answer`
        * UserAnswer: `int`
        * IsCorrect: `boolean`
2. In `MainWindow.xaml` 
