using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone.Views;

public partial class CartWishlistView : ContentPage
{
	public CartWishlistView()
	{
		BindingContext = new CartWishlistViewModel();
		InitializeComponent();
	}

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Customer");
    }

    private void Use_Cart_Clicked(object sender, EventArgs e)
    {

    }
}