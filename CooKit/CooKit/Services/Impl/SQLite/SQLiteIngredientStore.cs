﻿using System;
using System.Threading.Tasks;
using CooKit.Models;
using CooKit.Models.Impl;
using CooKit.Models.Impl.Generic;
using CooKit.Models.Impl.SQLite;
using SQLite;
using Xamarin.Forms;

namespace CooKit.Services.Impl.SQLite
{
    internal sealed class SQLiteIngredientStore : SQLiteStoreBase<IIngredient, IIngredientBuilder, SQLiteIngredientInternalInfo>, IIngredientStore
    {
        private readonly ImageSource _defaultIcon;

        internal SQLiteIngredientStore(SQLiteAsyncConnection connection, IImageStore imageStore) : base(connection, imageStore)
        {
            // TODO: replace with default icon
            _defaultIcon = null;
        }

        public override IIngredientBuilder CreateBuilder() =>
            new StoreCallbackIngredientBuilder(this);

        private protected override Task<IIngredient> InternalInfoToObject(SQLiteIngredientInternalInfo info)
        {
            if (info is null)
                throw new ArgumentNullException(nameof(info));

            var ingredient = new GenericIngredient
            {
                Id = info.Id,
                Name = info.Name
            };

            return SafeImageLoadAsync(info.ImageLoader, info.ImageSource, _defaultIcon).ContinueWith(iconTask =>
            {
                ingredient.Icon = iconTask.Result;
                return ingredient as IIngredient;
            });
        }

        private protected override Task<SQLiteIngredientInternalInfo> BuilderToInternalInfo(IIngredientBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            var info = new SQLiteIngredientInternalInfo
            {
                Id = builder.Id.Value,
                Name = builder.Name.Value,
                ImageLoader = builder.ImageLoader.Value,
                ImageSource = builder.ImageSource.Value
            };

            return Task.FromResult(info);
        }
    }
}
