using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone.Views;

public partial class CartView : ContentPage
{
	public CartView()
	{
		InitializeComponent();
		BindingContext = new CartViewModel();
	}

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Customer");
    }

    private void Remove_Clicked(object sender, EventArgs e)
    {
        (BindingContext as CartViewModel).RefreshItems();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CartViewModel)?.RefreshItems();
    }
}