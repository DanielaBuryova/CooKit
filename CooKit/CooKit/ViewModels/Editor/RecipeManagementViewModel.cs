﻿using CooKit.Models;
using CooKit.Views.Editor.Designers;

namespace CooKit.ViewModels.Editor
{
    public sealed class RecipeManagementViewModel : SharedManagementViewModel<IRecipe, IRecipeBuilder>
    {
        public RecipeManagementViewModel() 
            : base(App.GetRecipeStore(), typeof(RecipeDesignerView)) { }
    }
}
