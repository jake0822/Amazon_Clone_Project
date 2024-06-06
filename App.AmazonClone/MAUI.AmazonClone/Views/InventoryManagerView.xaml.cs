using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone.Views;

public partial class InventoryManagerView : ContentPage
{
	public InventoryManagerView()
	{
		InitializeComponent();
		BindingContext = new InventoryManagerViewViewModel();
	}
}