# Module 03 - Bindings - exercise

## Exrcise - Data Binding
### Introduction
In this exrcise we will practice using the `binding` feature of WPF. Specifically: 
1. We will practice creating notifying classes
2. We will create data binding to data context
3. We will use string formats and value converters
4. We will use `Multi-Binding`

### Steps
1. Define the `Meeting` class
    * `Start: DateTime`
    * `Length: TimeSpan`
    * `Title: String`
2. Create an instance of `Meeting` 
    * Create it in the resources of the window
    * Set it as the `DataContext` of the window
3. Present the meeting
    * Present the title, start and length
    * Use string formats to format the start date
4. Create Data Converter to present the length
    * Convert it to a string the tells you how many minutes and how many hours
    * If there are no hours - only specify the minutes. If the length is round, only present the hours
    * If the number of minutes is 30 - present it as "2 hours and a half" or "half hour"
5. Additional challanges
    * If the start date is in the past, present the title background in light red
    * If the meeting is longer than 3 hours, make the title bold
    * If the meeting is in progress (according to start and length), make the background yellow.