using System;
using System.Collections.Generic;
using Autodesk.Revit.DB.ExtensibleStorage;

namespace ExtensibleStorageExtension
{
    /// <summary>
    /// Create an Autodesk Extensible storage schema from a type
    /// </summary>
    public interface ISchemaCreator
    {
        Schema CreateSchema(Type type);
    }
}