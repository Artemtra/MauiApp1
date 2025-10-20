namespace MauiApp1.Pages;
using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

public partial class NewPage2 : ContentPage
{
    public ObservableCollection<Movies> MoviesList { get; set; } = new ObservableCollection<Movies>();
    public ObservableCollection<Author> AuthorList { get; set; } = new ObservableCollection<Author>();
    //
    public ObservableCollection<ListMovies> ListMovies { get; set; } = new ObservableCollection<ListMovies>();
    public int Count = 1;

    public NewPage2()
	{
        InitializeComponent();
        LoadFileAuthor();
        LoadFileMovie();
     
    }
    private void Take(int idMovie , int idAuthor)
    {
       
            ListMovies[Count].Title = MoviesList[idMovie].Name;
      
            ListMovies[Count].FirstName = AuthorList[idAuthor].Name;
            ListMovies[Count].SecondName = AuthorList[idAuthor].SecondName;
            ListMovies[Count].LastName = AuthorList[idAuthor].ThrityName;
            Count++;

    }
    private async void LoadFileAuthor()
    {

        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
        if (File.Exists(targetFile))
        {
            string a = File.ReadAllText(targetFile);

            AuthorList = JsonSerializer.Deserialize<ObservableCollection<Author>>(a);

        }
        OnPropertyChanged(nameof(AuthorList));
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


    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private void Button_Clicked_Save(object sender, EventArgs e)
    {
        Take(int.Parse(MovieId.Text), int.Parse(AuthorId.Text));
    }
}