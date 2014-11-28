UnityGUIExamples
================
Update 28 Nov 2014

Updated the Default Events example for InputFields to Unity version 4.6.0f3

(3 Sep 2014)

Scripting examples for the new Unity GUI.

Since the documentation and manual for the GUI system with curent Unity release (4.6.0b18) are still limited, 
I am attempting to create some simple examples how to access the new UI from script.

All examples are in C#.


Default Events
================

(28 Nov 2014)

Shows how to subscribe to default events of:

- Buttons - onClick
- Toggles - onValueChanged
- InputFields - onSubmit

Adding and removing Listeners with and without arguments.

Note: If you are adding a listener via script when something is activated, don't forget to put in safeguards that prevent the same listener from being added multiple times. It's best to remove listeners if the element that it refers to is no longer available.

Event Trigger
================

(31 Aug 2014)

Shows how to add events to the EventTrigger component at runtime.
This includes things such as OnPointerEnter, OnPointerExit, OnPointerClick etc.

Can be used on object that don't support those events at all (eg. plain panels).

Topmost element with the Event Trigger with capture all events.

Flow Control
================

(3 Sep 2014)

This is an example for setting up navigation for keyboard and controller where user can move between selectabe UI elements.

NOTE: Most of the time you are probably better of setting this up in Editor via the Navigation field of the Selectable. 
But if you do want to make changes through code, the example shows how to create custom Navigation and set the element to be selected by default.


Toggle Group
================

(31 Aug 2014)

Shows the use of Toggle Group to turn a collection of toggles into a radio button list (force only one selection from a list)

Tabs
===============

(31 Aug 2014)

// Original Tab Contol by @digibawb (https://twitter.com/digibawb) - included with permission

Example of a UI panels with tabs. Working control of which panel is active by using the tab buttons.
Added editor functionality for adding new tabs.
