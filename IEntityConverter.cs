using Autodesk.Revit.DB.ExtensibleStorage;

namespace ExtensibleStorageExtension
{
    public interface IEntityConverter
    {
        Entity Convert(IRevitEntity revitEntity);
        TRevitEntity Convert<TRevitEntity>(Entity entity) where TRevitEntity : class, IRevitEntity;
    }
}