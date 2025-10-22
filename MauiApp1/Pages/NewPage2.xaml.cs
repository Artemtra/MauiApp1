using MauiApp1.Models;
using MauiApp1.DB;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Pages;
public partial class NewPage2 : ContentPage
{
    DBFile db = new DBFile();
    public Movies selectedMovie { get; set; }
    public Author selectedAuthor { get; set; }

    

    public NewPage2()
	{
        InitializeComponent();
        


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
        
    }
}