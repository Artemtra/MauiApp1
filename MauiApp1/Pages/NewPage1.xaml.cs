using MauiApp1.Models;
using MauiApp1.DB;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
    DBFile db = new DBFile();

    public NewPage1()
	{
		InitializeComponent();
        BindingContext = this;
        LoadTablicka();
        db.LoadFileAuthor();


    }
    public  void SaveAuthor()
    {
        db.AddAuthor(Name.Text, SecondName.Text, ThirtyName.Text, BirthDayText.Date);
        LoadTablicka();
        OnPropertyChanged(nameof(db.LoadFileAuthor));
    }
   public async void LoadTablicka()
    {
        Tablicka.ItemsSource = await db.GetAuthorList();
    }
    private void Button_Clicked_Author(object sender, EventArgs e)
    {
        SaveAuthor();
    }
   
    private async void Button_Clicked_Home(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}