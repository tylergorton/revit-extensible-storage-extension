using System;
using Autodesk.Revit.DB;

namespace ExtensibleStorageExtension.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute()
        {
            UnitType = UnitType.UT_Undefined;
        }

        public string Documentation { get; set; }
        public UnitType UnitType { get; set; }
    }
}