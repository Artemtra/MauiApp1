using MauiApp1.Models;
using MauiApp1.Pages;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Movies> MoviesList { get; set; } = new ObservableCollection<Movies>();
      private  int IdMovie = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            LoadFileMovie();
         
        }
        public void SaveMovie()
        {
            Movies movies = new Movies();
            movies.Id = IdMovie;
            movies.Name = TitleText.Text;
            movies.Description = DiscriptionText.Text;
            movies.Date = DiscriptionDate.Date;

            MoviesList.Add(movies);
            SaveFileMovie();
            IdMovie++;
            OnPropertyChanged(nameof(MoviesList));
        }
  

        private void Button_Clicked_Movie(object sender, EventArgs e)
        {
            SaveMovie();
        }


        private async void SaveFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, MoviesList);
            }
            MoviesList.Clear();
            LoadFileMovie();
        }
        private async void LoadFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            if (File.Exists(targetFile))
            {
                string a = File.ReadAllText(targetFile);
                MoviesList = JsonSerializer.Deserialize<ObservableCollection<Movies>>(a);
          
            }
            OnPropertyChanged(nameof(MoviesList));
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

