using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone.Views;

public partial class InventoryManagerView : ContentPage
{
	public InventoryManagerView()
	{
		InitializeComponent();
		BindingContext = new InventoryManagerViewViewModel();
	}
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}