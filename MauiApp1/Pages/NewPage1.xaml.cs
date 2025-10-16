using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Text.Json;
namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
    public ObservableCollection<Author> AuthorList { get; set; } = new ObservableCollection<Author>();
    private int IdAuthor = 0;
    public NewPage1()
	{
		InitializeComponent();
        BindingContext = this;
      
        
    }
    public void SaveAuthor()
    {
        Author author = new Author();
        author.Id = IdAuthor;
        author.Name = Name.Text;
        author.SecondName = SecondName.Text;
        author.ThrityName = ThirtyName.Text;
        author.BirthDay = BirthDayText.Date;



        AuthorList.Add(author);

        IdAuthor++;    
        SaveFileAuthor();
        OnPropertyChanged(nameof(AuthorList));
    }
    private void Button_Clicked_Author(object sender, EventArgs e)
    {
        SaveAuthor();
    }
    private async void SaveFileAuthor()
    {
        
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
        using (FileStream outputStream = File.Create(targetFile))
        {
            await JsonSerializer.SerializeAsync(outputStream, AuthorList);
        }
        AuthorList.Clear();
        LoadFileAuthor();
    }
    private async void LoadFileAuthor()
    {
       
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
        if (File.Exists(targetFile))
        {
            string a = File.ReadAllText(targetFile);
       
            AuthorList = JsonSerializer.Deserialize<ObservableCollection<Author>>(a);
        }
    }
    private async void Button_Clicked_Home(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}