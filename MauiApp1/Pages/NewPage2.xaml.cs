using MauiApp1.Models;
using MauiApp1.DB;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Pages;
public partial class NewPage2 : ContentPage
{


   
    public Movies selectedMovie { get; set; }
    public Author selectedAuthor { get; set; }

    

    public NewPage2()
	{
        InitializeComponent();
        DBFile.SaveFileAuthor();

    }
    private void Take(int idMovie , int idAuthor)
    {
       
            DB.ListMovies[Count].Title = DB.MoviesList[idMovie].Name;
      
            ListMovies[Count].FirstName = DB.AuthorList[idAuthor].Name;
            ListMovies[Count].SecondName = AuthorList[idAuthor].SecondName;
            ListMovies[Count].LastName = AuthorList[idAuthor].ThrityName;
            Count++;

    }

    public void RemoveMovie()
    {


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