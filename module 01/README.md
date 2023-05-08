# Day 01 - XAML, Trees and Templates
### Projects:
|     |     |
| --- | --- |
| [BareBones](BareBones/) | The core of WPF - without XAML | 
| [FunWithXaml](FunWithXaml/) | Deep dive into XAML |
| [FunWithTemplates](FunWithTemplates/) | Introduction to trees and templates in WPF |

### The core of WPF
* We learned that WPF is a rich client framework that works directly through low level graphics drivers (`DirectX`) rather than through the `GDI`
* We learned that WPF uses 4 `DLL` packages:
  * `PresentationCore`
  * `PresentationFramework`
  * `WindowsBase`
  * `System.Xaml`
* We saw that WPF uses a special threading model
  * Single main thread that handles UI
  * Thread Pool to handle tasks in the background
  * Dispatchers schedule work units for each group of threads one dispatcher per group
  * Must use the **Single-Threaded Apartments** model (`STAThread`)
* All WPF objects can be constructed and displayed using "normal" C# code to construct the instances and connect them together.
* We saw an example of how we create a full UI application using C# only:
  * Created several UI elements (`Button`, `Ellispe`, `Window`, `StackPanel`)
  * Connected them together by setting refernces to each other in their respective properties (`Content`, `Children`)
  * Created an `Application` object in order to instrument the application
  * Started the application by calling the `Application.Run(Window)` method

### Introduction to XAML
* We saw that XAML is just an additional language that can perform the same logic that we previously did in C# code
* We prefer using XAML because it is **Declarative** while C# in **Imperative**.
  * Imperative languages describe flow of logic, they tell the computer what to do, step by step. 
  * Declarative languages tell the computer **What** to build, but not **how**. They describe the final state of the UI rather than the steps to get to that state.
  * UI built using declarative languages are easier to read.
* We understood that XAML is an enhancment of XML. It describes a hierarchical structure of data, and adds a few extra features.
* At the core, all XAML does is instantiates C# objects and fills their properties.
* We learned how to read and understand the XAML syntax for **namespaces**
    * We saw how to add a prefix to specific C# namespace, and understood that there is also a way to add prefix to a group of namespaces
    * We saw some of the common prefix and namespaces such as the `x` namespace for XAML language constructs, the `d` namespace for design only attributes, and the `mc` namespace for compatibility issues.
* We saw that we create new instances by adding class elements, for example `<Button>` and `<local:Person>`.
* We saw that we can set their properties using 2 types of syntax
    * The **Property Elements** set the property value explicitly. for example: `<Button.Width>128</Button.Width>` and `<local:Person.FirstName>John</Local:Person.FirstName>`
    * The **Property Attributes** set the property implicitly by "secretly" applying a type converter for the specific type of property
* We saw that some classes have a default property which can be set without specifying the property element. This is called the **Content Property**
* We saw that XAML also helps us to fill collection properties such as `IList<T>` and `IDictionary<T>`. 
    * We saw that we need to make sure the collection itself is instantiated in the object constructor
    * We saw that when using the **Property Element** Syntax, we can simply fill the element with object elements.
    * If we use a dictionary collection, we also need to supply a key for each element using the `x:Key` attribute
* We learned about **Type Converters**
    * We saw how to implement our own type converter for a custom type.
* We learned about **Markup Extensions**
    * We understood that markup extension is a wrapper to a method that nees to be executed while filling the value of a property
    * We saw some built in markup extensions such as `{Binding}`, `{StaticResource}` and `{x:Null}`
    * We saw how to create our own custom markup extension

### Trees and Templates
* We understood that WPF uses 2 type of trees
  * **The Visual Tree** - A single tree that holds all visual elements and represents the hierarchical structure of the UI
    * responsible for: rendering, layout, transforms, enablement, hit testing and more
  * **The logical Tree** - in fact several of them, that represent the logical hierarchy of the UI without specifying the internal implementation detail of each element
    * responsible for: inheriting dependency property values, resolving resource keys, looking up elements by name, bubbling of events
* We learned about the `Shape` elements and how they behave in each tree
  * We also saw tha path markup language
* We learned about the `Decorator` elements and how they behave in each tre
* We defined the term `Control` in WPF and understood that it is an UI element that seperates logic and visual
  * The logic is hard coded in the control class
  * The visual is injected into it using a `ControlTemplate`
* We understood what a template is and that there are 3 types of templates in WPF - the first of them is the `ControlTemplate` which defines the visual implementation of a control.
* We saw that the `ControlTemplate` and the `Control` have a "contract" that allows them to interact
  * The control exposes properties, some of them visual properties, and the template **Binds** to the properties using the `{TemplateBinding}` markup extension, in order to apply them on the visual itself. 
  * The control exposes a set of "visual states" and the template responds to them by defining animations that will be activated in each specific state
* We saw the `ContentControl` class which is the base class of all controls that contain content
  * It has a `Content` property that can hold any object
  * Since data objects can not be displayed in the visual tree, it has a `ContentTemplate` property of type `DataTemplate` in order to define how the data is to be presented.
  * The `ControlTemplate` places a `<ContentPresenter>` element in order to specify where the content will be displayed
