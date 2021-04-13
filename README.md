# Extensible Storage Extension

Extensible storage in Revit requires creation and registration of a data schema. In code, we need to also create a class with properties. The effort of creating and registering a schema with Revit has been alleviated by the Extensible Storage Extension's set of classes, functions, and attributes that you can apply to any class whose data you want to persist in Revit across sessions.

## Build

Visual Studio was used for this C# solution. Individual projects build against the particular Revit API major versions (per year). Set your build options to build only one project at a time to inhibit crossing of auto generated files during build. 
