﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CooKit.Models;
using CooKit.Views;
using Xamarin.Forms;

namespace CooKit.ViewModels
{
    public sealed class RecipeViewModel : INotifyPropertyChanged
    {
        public string Name { get; }
        public string Description { get; }
        public ImageSource MainImage { get; }
        public ObservableCollection<ImageSource> Pictograms { get; }

        public ObservableCollection<IIngredient> Ingredients { get; }
        public ObservableCollection<string> Steps { get; }

        public ICommand BackCommand { get; }
        public ICommand CookCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private IRecipe _recipe;

        public RecipeViewModel(IRecipe recipe)
        {
            Name = recipe.Name;
            Description = recipe.Description;
            MainImage = recipe.MainImage;
            Pictograms = new ObservableCollection<ImageSource>(new []{ ImageSource.FromFile("breakfast.png"), ImageSource.FromFile("breakfast.png") });

            Ingredients = new ObservableCollection<IIngredient>();
            Steps = new ObservableCollection<string>(new []{ "Boil an egg!", "Eat the egg!" });

            for (var i = 0; i < 10; i++)
                Ingredients.Add(new MockIngredient());

            BackCommand = new Command(() => Shell.Current.Navigation.PopAsync());
            CookCommand = new Command(() => Shell.Current.Navigation.PushAsync(new RecipeView(this)));

            _recipe = recipe;
        }
    }
}
