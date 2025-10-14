namespace MauiApp1.Pages;
using MauiApp1.Models;
using System.Threading.Tasks;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
        InitializeComponent();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

}