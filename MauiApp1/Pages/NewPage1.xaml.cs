using MauiApp1.Models;
using System.Collections.ObjectModel;
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
        author.BirthDay = BirthdayDate.Date;



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
        string text = "";

        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new StreamWriter(outputStream);
        for (int i = 0; i > AuthorList.Count; i++)
        {
            text = $"{AuthorList[i].Id}";
            await streamWriter.WriteAsync(text);
            text = $"{AuthorList[i].Name}";
            await streamWriter.WriteAsync(text);
            text = $"{AuthorList[i].SecondName}";
            await streamWriter.WriteAsync(text);
            text = $"{AuthorList[i].BirthDay}";
            await streamWriter.WriteAsync(text);

            OnPropertyChanged(nameof(AuthorList));
        }

    }
    private async void Button_Clicked_Home(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}