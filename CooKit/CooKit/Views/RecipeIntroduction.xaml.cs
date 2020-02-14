﻿using CooKit.ViewModels;
using Xamarin.Forms.Xaml;

namespace CooKit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeIntroduction
    {
        public RecipeIntroduction(RecipeViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}