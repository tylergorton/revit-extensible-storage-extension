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
#if RVT2019 || RVT2020
            UnitType
#else
            ForgeTypeId
#endif
            UnitType { get; set; } =
#if RVT2019 || RVT2020
                UnitType.UT_Undefined
#else
                SpecTypeId.Custom
#endif
                ;
    }
}
