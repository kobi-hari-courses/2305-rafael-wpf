# Day 03 - Dependency Properties and Data Binding
### Projects:
|     |     |
| --- | --- |
| [FunWithDependencyProperties](./projects/FunWithDProperties/) | WPF Dependency Properties | 
| [FunWithBinding](./projects/FunWithBinding/) | Data Binding, sources, and converters |

### Dependency Properties
* We have talked about the **Property Service** as a storage for property values for objects
* We talked about the `DependencyObject` class and the fact that it provides access to dependency properties.
* We saw how to define a new dependency property token using the `DependencyProperty.Register` static method.
* We saw how to define default value to the property
* We saw how to define a style that changes the property
* We saw how to query the source of the data using `DependencyPropertyHelper`.
* We saw how to **Coerce** the value of the dependency property
* We saw how to respond to value changes of the property using the `OnChange` callback.
* We saw how to use `Style Trigger` inside style in order to conditionaly set a property value according to the value of another property (for example `IsMouseOver`)
* We saw how to define property behaviors such as inheritance, default binding and more, using the `FrameworkPropertyMetadata`

### Attached Properties
* We understood that at the core - **All dependency properties may be attached to every dependency object**. 
* Still, mostly for XAML purposes, we can specifically define a property as **Attached Property** using the `RegisterAttached` method. This specifically indicates that the property is designated to be attached to **other** objects.
* We saw how to implement **Attached Behavior** By responding to the property changes and implementing some logic as a result.
* We demonstrated how to create a template that binds to attached properties.
* We saw that actually, we almost never need to inherit from a control in order to extend it
  * We can create an alternate look using the template
  * We can add data properties using attached properties
  * We can add custom behaviors controlled by properties using **Attached Behaviors**

### Resources and Styles
* We have talked about `ResourceDictionary` and the fact that each element in the visual tree has this property
* We said that `{StaticResource}` and `{DynamicResource}` search for resources by traveling up the **logical tree**
* We saw that each resource in the resource dictionary must have an `x:Key` except for `DataTemplate` and `Style`
  * If the key is ommited, they become default for their target type within the scope of the resource dictionary
* We talked about the fact that "visual" elements can not be resources since they cannot be reused. Each visual element can be placed in the visual tree only at one place.
* We said that resources should usually be either **immutable** (meaning that the classes are readonly and the properties cannot change) or **frozen** (meaning the the classes implement `IFreezble` when you can set the object as **frozen** which turns the properties into read-only).
* In any case - you should not change properties of resource once they are already used as resources.
* We saw some example of objects that are good candidates to be used as resources
  * Brushes
  * Colors
  * Geometries
  * Animations
  * Templates
  * Styles
  * Storyboards
* We saw that a `Style` is an object that defines values for properties. 
  * We saw that a `Style` object contains a list of `Setter` objects, each one defines a specific value to a specific property
  * We saw that each `Style` has `TargetType` which determines which properties are relevant for this style. A style object can be provided to an element only if the element's type is the styles `TargetType`
  * We saw that if we set a property directly on an element, it overrides the value that it receives from the style
  * We saw that a style can set any property of the element (excpet for the `Style` property itself)
  * We saw that a `Style` object can be "Based On" a different style, which means that it inherits all the property setters of the base style
* We talked about animations
  * We said that an `Animation` is like a single style setter, in the sense that it provides a value to a specific property.
  * We said that a `Storyboard` is like a single `Style` since it contains several animations where each sets a single property with a value.
  * There are 3 main differences between styles and storyboards
    1. A style setter is "weaker" than a local value, so if you provide a property with local value it overides the setter value. Animation value, on the other hand, is **stronger** than local value. 
    2. A style setter sets the property value **instantly** while an animation setter sets it over time
    3. You can only provide a single style object to an element. But you can apply many storyboards
* We talked about `Triggers`
  * We saw that each UI element has a `Triggers` property which is a list of `Trigger` objects
  * A trigger object contains 2 parts: The trigger cause, and the trigger action
    * The trigger cause is an object that describes what the triggers responds to, when it is triggered
    * The trigger action is an object that describes the side effect of the trigger
  * We saw that in the `Triggers` property we may only use a specific type of trigger called `EventTrigger` which is triggered by a specific event
  * We saw that we may use the `StartStoryboard` action so that the trigger causes a storyboard to play
  * We saw an example of how to respond to a `Loaded` event of an element in order to play a storyboard on it
* We saw how to set the storyboard "repeat" behavior to make it loop forever.
* We saw how to create an animation with several keyframes
* We saw how to set easing functions to each keyframe


### Data Binding
* We understood that a binding is an external object that synchronizes the value of properties
* We saw that the object is defined by 4 things:
  * The source object - which can be any object
  * The source property path - which can be any property on the source object, or a path from it through other objects to a final source property.
  * The target object - which must be a `DependencyObject`
  * The target property - which must be a `DependencyProperty`
* We saw that we can also add
  * Mode: One way, Two way, One time, and more
  * Converter: A value converter to modify the data that is synchronized
  * And other binding properties which we did not talk about:
    * `UpdateSourceTrigger` - controls when to update the source property on two way bindings
    * `FallbackValue` - a value to use when the binding is not legal
    * `NullValue` - a value to use when the source is null
* We saw how to use Value converters, and how to write them
* We saw how to define the binding source
  * Data Context - by default
  * Element by name
  * Self
  * Templated Parent
* We saw that implementing `INotifyPropertyChanged` on the source means that the binding knows to refresh the target value whenever the source changes
* We saw how to create binding "Programatically" in C#
* Finally we saw a cool example of how to implement a sophisticated template for `ProgressBar` using `MultiBinding` cobined with `TemplatedParent` source


