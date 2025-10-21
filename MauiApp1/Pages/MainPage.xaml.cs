using MauiApp1.Models;
using MauiApp1.Pages;
using MauiApp1.DB;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            DBFile.LoadFileMovie();
         
        }
        public void SaveMovie()
        {
            Movies movies = new Movies();
            movies.Id = MoviesList.Count+1;
            movies.Name = TitleText.Text;
            movies.Description = DiscriptionText.Text;
            movies.Date = DiscriptionDate.Date;

            DBFile.MoviesList.Add(movies);
            DBFile.SaveFileMovie();
           
            OnPropertyChanged(nameof(MoviesList));
        }
  

        private void Button_Clicked_Movie(object sender, EventArgs e)
        {
            SaveMovie();
        }


        public async void Button_Clicked_To_Page2(object sender, EventArgs e)
        {
            //new NavigationPage(new NewPage1());
            await Navigation.PushModalAsync(new NewPage1());
        }
        public async void Button_Clicked_To_Page3(object sender, EventArgs e)
        {
            //new NavigationPage(new NewPage1());
            await Navigation.PushModalAsync(new NewPage2());
        }
    }

    }

