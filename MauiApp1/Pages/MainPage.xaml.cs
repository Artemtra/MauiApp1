using MauiApp1.Models;
using MauiApp1.Pages;
using MauiApp1.DB;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        DBFile db = new DBFile();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            db.LoadFileMovie();
            Tablichka();
        }
        public void SaveMovie()
        {
            db.AddMovies(TitleText.Text, DiscriptionText.Text, DiscriptionDate.Date);
            Tablichka();
            OnPropertyChanged(nameof(db.GetMovieList));
        }
  
        public  async void Tablichka()
        {
            MovieListTablichka.ItemsSource = await db.GetMovieList();

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

