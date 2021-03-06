﻿using System;
using System.Collections.Generic;
using CooKit.Models.Steps;
using Xamarin.Forms;

namespace CooKit.Models
{
    public interface IRecipe : IStorable
    {
        string Name { get; }
        string Description { get; }
        ImageSource Image { get; }
        TimeSpan RequiredTime { get; }

        IReadOnlyList<IIngredient> Ingredients { get; }
        IReadOnlyList<IPictogram> Pictograms { get; }
        IReadOnlyList<IRecipeStep> Steps { get; }
    }
}
