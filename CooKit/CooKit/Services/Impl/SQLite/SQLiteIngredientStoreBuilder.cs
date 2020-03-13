﻿using System;
using System.Threading.Tasks;
using CooKit.Models;
using CooKit.Models.Impl;
using SQLite;

namespace CooKit.Services.Impl.SQLite
{
    public sealed class SQLiteIngredientStoreBuilder
    {
        public IBuilderProperty<SQLiteIngredientStoreBuilder, IImageStore> ImageStore { get; }
        public IBuilderProperty<SQLiteIngredientStoreBuilder, SQLiteAsyncConnection> DatabaseConnection { get; }

        public SQLiteIngredientStoreBuilder()
        {
            ImageStore = new BuilderPropertyImpl<SQLiteIngredientStoreBuilder, IImageStore>(this);
            DatabaseConnection = new BuilderPropertyImpl<SQLiteIngredientStoreBuilder, SQLiteAsyncConnection>(this);
        }

        public async Task<IIngredientStore> BuildAsync()
        {
            if (ImageStore.Value is null)
                throw new ArgumentNullException(nameof(ImageStore));

            if (DatabaseConnection.Value is null)
                throw new ArgumentNullException(nameof(DatabaseConnection));

            var store = new SQLiteIngredientStore(DatabaseConnection.Value, ImageStore.Value);

            await store.InitAsync();
            return store;
        }
    }
}