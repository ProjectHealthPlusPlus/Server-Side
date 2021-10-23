﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthPlusPlus_AW.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
        {
            //Apply Naming Convention for Each Entity

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                if (entity.BaseType == null)
                {
                    entity.SetTableName(entity.GetTableName().ToSnakeCase());

                    foreach (var property in entity.GetProperties())
                        // property.SetColumnName(property.GetColumnName().ToSnakeCase());
                    {
                        var tableIdentifier = StoreObjectIdentifier.Table(entity.GetTableName(), null);
                        property.SetColumnName(property.GetColumnName(tableIdentifier).ToSnakeCase());
                    }

                    foreach (var key in entity.GetKeys())
                        key.SetName(key.GetName().ToSnakeCase());

                    foreach (var foreignKey in entity.GetForeignKeys())
                        foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());

                    foreach (var index in entity.GetIndexes())
                        index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                }
            }
        }
    }
}