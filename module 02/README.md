# Day 02 - Trees and Templates
### Projects:
|     |     |
| --- | --- |
| [FunWithTemplates](./projects/FunWithTemplates/) | Introduction to Templates |

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


## Specific Demos
* [Placing an object inside a button](https://github.com/kobi-hari-courses/2305-rafael-wpf/blob/da4926d107e71f323f5cba52659c2a4666c5b8f6/module%2002/projects/FunWithTemplates/FunWithTemplates/FirstExample.xaml#L21C48-L26)
  * In this code snippet we also use a `Control Template` and a `Data Template`. 
  Both are defined in the application resources

* [Defining a global resource in the `App.xaml`](https://github.com/kobi-hari-courses/2305-rafael-wpf/blob/da4926d107e71f323f5cba52659c2a4666c5b8f6/module%2002/projects/FunWithTemplates/FunWithTemplates/App.xaml#L7-L52)
    * This way it may be used everywhere in the application


[Responsing to state changes in the control](https://github.com/kobi-hari-courses/2305-rafael-wpf/blob/da4926d107e71f323f5cba52659c2a4666c5b8f6/module%2002/projects/FunWithTemplates/FunWithTemplates/CheckboxExample.xaml#L12-L36)
    * We specify the group and state that we want to respond to 
    * We create a `Storyboard` to define all the changes
    * We create an `Animation` to change a single property of a single object
    * We may add `Transition` to define that the change is done over a period of time (rather than instantly)