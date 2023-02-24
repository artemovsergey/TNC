using System.Reflection.PortableExecutable;
using TNC.MAUI.Models;

namespace TNC.MAUI.Views;

public partial class СarouselViewPage : ContentPage
{
	public СarouselViewPage()
	{
		InitializeComponent();
	}

    private void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        Product? current = e.CurrentItem as Product;
        Product? previous = e.PreviousItem as Product;
        header.Text = $"Current: {current?.Name}  Previous: {previous?.Name}";
    }
}