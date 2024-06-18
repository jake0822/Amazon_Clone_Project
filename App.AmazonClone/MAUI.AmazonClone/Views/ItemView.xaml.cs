using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone.Views;

public partial class ItemView : ContentPage
{
	public ItemView()
	{
		InitializeComponent();
        BindingContext = new ItemViewModel();
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ItemViewModel)?.AddOrUpdate();
        Shell.Current.GoToAsync("//Inventory");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Inventory");
    }
}