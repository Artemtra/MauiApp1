using MauiApp1.Models;
using MauiApp1.DB;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
  
 
    public NewPage1()
	{
		InitializeComponent();
        BindingContext = this;
        
        

    }
    public void SaveAuthor()
    {
        Author author = new Author();
       
        author.Id = DBFile.AuthorList.Count + 1;
        author.Name = Name.Text;
        author.SecondName = SecondName.Text;
        author.ThrityName = ThirtyName.Text;
        author.BirthDay = BirthDayText.Date;



        DBFile.AuthorList.Add(author);
  
        DBFile.SaveFileAuthor();
        OnPropertyChanged(nameof(DBFile.AuthorList));
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