# Day 04 - Layout Panels and Resources
### Projects:
|     |     |
| --- | --- |
| [Fun With Items Control](FunWithItemsControl/) | Cool demo of `ListBox` templateing | 
| [FunWithTpl](FunWithTpl/) | Introduction to Task Parallel Library |

    ### Items Controls
* We talked about customization of items controls
* We saw how to create a `ControlTemplate` to the items control
  * We saw that we are required to place a `ItemsPresenter` somewhere in the template in order to present the items themselves
* We saw how to customize the layout
  * We learned about the `ItemsPanelTemplate` type
  * We saw how to set the panel using the `ItemsPanel` property. 
* We learned about the item containers
  * `ListBoxItem` for list boxes
  * `ComboBoxItem` for combo boxes
  * `MenuItem` for menus
  * `TreeViewItem` for tree views
* We understood that each items control generates a single "item container" per item it needs to present
* We understood that each item container is:
  * A control, so it may be styled and templated
  * A content control, so we may also template the content
* We saw how to set the style per item container using the `ItemContainerStyle` property
* We saw how to create a custom template for the item container using the style
* In our example, for `ListBoxItem` we saw how to use visual states to determines how an item should look when it is selected
* We saw how to use the item container style to set the panel attached properties
  * In our example we set the `Canvas.Top` and `Canvas.Left` properties
  * We even used Binding inside the style to set these properties
* Finally, we saw how to use the `ItemTemplate` property to set the `DataTemplate` for each item.
  * The item container uses these templates as `ContentTemplate`


### Introduction to TPL
* We talked about the evolution of asynchronous programming though the first versions of the .NET framework
* We defined the concept of `Process` and understood that it
  * Mostly defines a separation of memory
  * Also defines a set of threads
* We understood the concept of `Thread`
  * The only entity that actually runs code
  * May be shared and reused in an application
* We understood that .net framework comes with a `Thread Pool` to make better use of threads
  * avoid creating and destroying threads - that are expensive to allocate
* We understood that the `TPL` model attempts to minimize the number of threads used by the application by reusing them
* We understood what a `Task` is
  * An object describing "something that needs to be completed with result"
  * Contains 2 fields
    * The status (in progress, completed, or failed)
    * The result (or error if failed)
  * We understood that tasks are based on "Push", so you cannot call them to get the result synchronously. Instead, they call you back with the result.
  * We understood that tasks do not run code. Threads do. Tasks are only there to tell you when the code completes.
  * We saw how to create a new task using `Task.Factory.StartNew`
  * We saw how to respond to completion using `Task.ContinueWith`
  * We saw how to set the thread context that the continuation will run on using the `TaskScheduler`
  * We saw that in order to set properties on the ui when tasks complete, we need to set the continuation to run on the main thread.
  * We learned about the `async` and `await` keywords and understood that they are
    * Compilation directives
    * `async` means that the method will be compiled in a different way
    * `await` actually ends the method. Anything after it is in a new method
    * `await` must come before a task object
    * Whatever comes after the `await` is registered as continuation of the Task.
    * `async` and `await` gives us better code readbility

