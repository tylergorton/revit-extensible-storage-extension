using System;
using Autodesk.Revit.DB;

namespace ExtensibleStorageExtension.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute() { }

        public string Documentation { get; set; }

        public
#if RVT2021
            ForgeTypeId
#else
            UnitType 
#endif
            UnitType { get; set; } =
#if RVT2021
                SpecTypeId.Custom
#else
                UnitType.UT_Undefined
#endif
                ;
    }
}
