using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using ExtensibleStorageExtension.Attributes;

namespace ExtensibleStorageExtension.ElementExtensions
{
    public static class RevitEntityElementExtension
    {        
        public static void SetEntity(this Element element, IRevitEntity revitEntity)
        {
            ISchemaCreator schemaCreator = new SchemaCreator();
            IEntityConverter entityConverter = new EntityConverter(schemaCreator);
            Entity entity = entityConverter.Convert(revitEntity);

            element.SetEntity(entity);
        }

        public static TRevitEntity GetEntity<TRevitEntity>(this Element element) 
            where TRevitEntity : class, IRevitEntity
        {
            Type revitEntityType = typeof (TRevitEntity);

            AttributeExtractor<SchemaAttribute> schemaAttributeExtractor = 
                new AttributeExtractor<SchemaAttribute>();

            var schemaAttribute =
                schemaAttributeExtractor.GetAttribute(revitEntityType);

            Schema schema = Schema.Lookup(schemaAttribute.GUID);
            if (schema == null)
                return null;

            var entity = 
                element.GetEntity(schema);

            if (entity == null || !entity.IsValid())
                return null;

            ISchemaCreator schemaCreator = new SchemaCreator();
            IEntityConverter entityConverter = new EntityConverter(schemaCreator);

            var revitEntity = entityConverter.Convert<TRevitEntity>(entity);

            return revitEntity;
        }       

        public static bool DeleteEntity<TRevitEntity>(this Element element)
            where TRevitEntity : class, IRevitEntity
        {
            Type revitEntityType = typeof(TRevitEntity);

            AttributeExtractor<SchemaAttribute> schemaAttributeExtractor =
                new AttributeExtractor<SchemaAttribute>();

            var schemaAttribute =
                schemaAttributeExtractor.GetAttribute(revitEntityType);

            Schema schema = Schema.Lookup(schemaAttribute.GUID);
            if (schema == null)
            {
                return false;
            }

            return element.DeleteEntity(schema);
        }
    }

    public static class EntityExtension
    {
        public static void SetWrapper<T>(this Entity entity, Field field, IList<T> value)
        {            
            entity.Set(field, value);
        }

        public static void SetWrapper<T>(this Entity entity, 
            Field field, 
            IList<T> value,
#if RVT2021 || RVT2022
            ForgeTypeId
#else
            DisplayUnitType 
#endif
            displayUnitType)
        {
            entity.Set(field, value, displayUnitType);
        }

        public static void SetWrapper<TKey,TValue>(this Entity entity, 
            Field field, 
            IDictionary<TKey,TValue> value)
        {
            entity.Set(field, value);
        }

        public static void SetWrapper<TKey, TValue>(this Entity entity,
            Field field,
            IDictionary<TKey, TValue> value,
#if RVT2021 || RVT2022
            ForgeTypeId
#else
            DisplayUnitType 
#endif
            displayUnitType)
        {
            entity.Set(field, value, displayUnitType);
        }
    }

}