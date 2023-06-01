# Day 02 - Trees and Template and Layout
### Projects:
|     |     |
| --- | --- |
| [FunWithTemplates](./projects/FunWithTemplates/) | Introduction to Templates |
| [FunWithPanels](./projects/FunWithPanels/) | Introduction to the common panels in WPF |


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

## Layout in WPF and Layout properties
* Layout in WPF is a 2-pass algorithm.
  * The **measure** pass where each parent asks child to measure the minimum space required for its presentation
  * The **arrange** pass where eah parent allocates space and position for its child
* The layout passes allocate the **Bounding Box** for its children.
* Once a bounding box is allocated, the layout properties arrange the element inside the box
  * The `Margin` property may allocate some of the bounding box for whitespace and reduce the effective available box
  * The `Width` and `Height` properties may give the element a size that is different than the bounding box. 
  * If the `Width` and `Height` are not set, then the `MinWidth`, `MinHeight`, `MaxWidth` and `MaxHeight` properties may still limit the size
  * The `VerticalAlignment` and `HorizontalAlignment` may set the sizing and position of the element.
    * If the value `Stretch` is used, then the element will be sized according to the available box. (assuming `Width` and `Height` are not set)
    * Otherwise, the element will be sized according to the measure pass.
    * The alignment will set the position of the element within the bounding box
* Custom layout behavior may be programmed into new element classes by overriding the layout methods:
  * `MeasureOverride`
  * `ArrangeOverrride`

  
## The various Panels of WPF
* The `Canvas` panel is the most simple panel because it does not really do any calculations. It simply places each element when it asks to be.
  * Alignment is never relevant because the box allocated for each element is exactly what it requires to be.
  * Position is controlled using the `Canvas.Top` `Canvas.Left`, `Canvas.Bottom` and `Canvas.Right` properties.
* The `StackPanel` is a useful panel for stacking elements in one direction
  * It can either be horizontal or vertical
  * In the stacking direction, the element will always get exactly the desired size
  * In the other dimension, the panel calcualtes the max desired size of all the children, and then allocates that maximum to all of them
*  The `WrapPanel` is a useful panel for stacking and wrapping of elements. It stacks elements in a single direction and then wraps to the next stack if there is not enough space in the container
*  The `DockPanel` is useful for docking elements to the panel boundaries and to fill the ramainder space
   *  `LastChildFill` property decides if the last child fills the entire space that remains after previous children are placed
   *  Each child has a docking direction controlled by the `DockPanel.Dock` property
   *  Multiple elements may be stacked to the same direction
*  The `Grid` panel is the most versitile panel of them all
   *  It is used to fill spaces in 2 dimensions
   *  First you use the `ColumnDefinitions` and `RowDefinitions` properties to divide the space into rows and columns
   *  Then you can place elements in cells using the `Grid.Row` and `Grid.Column` properties
   *  You can span an element on a rectangle of cells using `Grid.RowSpan` and `Grid.ColumnSpan`
   *  Columns and Rows may have various size logics:
      *  `auto` sizing - the row or column will have the minimum size required to fit its content
      *  `pixel` sizing - provides the exact size for the row or column
      *  `star` sizing - divides the remaining space according to proportional weights
   *  We have seen how to use `GridSplitter` along with `Grid` in order to allow to user to resize rows and columns
   *  We have talked about `Size Sharing Group` to allow different grids to share sizing definitions


