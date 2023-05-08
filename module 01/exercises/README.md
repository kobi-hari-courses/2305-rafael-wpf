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
2. In `MainWindow.xaml` 
    - Remove the `<Grid>`
    - Enter an `Exam` instead
    - Fill in the properties of the Exam
    - Create a few questions for example
3. Add a new type: 
    - `Answer`
        * UserAnswer: `int`
        * IsCorrect: `boolean`
    - Also for `Question` add another property: Id: `string`
    - Fill in the missing property for every question that you have created in the xaml
4. In Exam, add a property:
    - Answers: `Dictionary<string, Answer>`
5. Fill in some answers as example.
    - Note that you should use the question id as key for the answer inside the collection
6. Add a new type: 
    - `ExamScore`
        * CorrectAnswers: int
        * WrongAnswers: int
    - Add a property to Exam:
        * Score: `ExamScore`
7. Enter a score into the exam using the `explicit notation`
8. Now create a type converter that allows you to fill the score in the following format: "4, 6" (4 is the number of correct answers, and 6 is the number of wrong ones)
9. In the xaml, enter the score using the `implicit notation`
