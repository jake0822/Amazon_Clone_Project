using MAUI.AmazonClone.ViewModels;
using Library.AmazonClone.Services;

namespace MAUI.AmazonClone.Views;

public partial class CheckoutView : ContentPage
{
	public CheckoutView()
	{
		BindingContext = new CartViewModel();
		InitializeComponent();
	}

    private void Confirm_Clicked(object sender, EventArgs e)
    {
        Cart.Current.Clear();
        (BindingContext as CartViewModel)?.RefreshItems();
        Shell.Current.GoToAsync("//Customer");
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Cart");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CartViewModel)?.RefreshItems();
        (BindingContext as CartViewModel)?.RefreshTotal();
    }
}