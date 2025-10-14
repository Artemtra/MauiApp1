using MauiApp1.Models;
using MauiApp1.Pages;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
      public List<Movies> MoviesList = new List<Movies>();
      private  int IdMovie = 0;

        public MainPage()
        {
            InitializeComponent();
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
        }
  

        private void Button_Clicked_Movie(object sender, EventArgs e)
        {
            SaveMovie();
        }

     
        private async void SaveFileMovie()
        {
            string text = "";

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            using FileStream outputStream = File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            for (int i = 0; i > MoviesList.Count; i++)
            {
                text = $"{MoviesList[i].Id}";
                await streamWriter.WriteAsync(text);
                text = $"{MoviesList[i].Name}";
                await streamWriter.WriteAsync(text);
                text = $"{MoviesList[i].Description}";
                await streamWriter.WriteAsync(text);
                text = $"{MoviesList[i].Date}";
                await streamWriter.WriteAsync(text);
             
            }
           
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

