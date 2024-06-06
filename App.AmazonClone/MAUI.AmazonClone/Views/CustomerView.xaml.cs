using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone.Views;

public partial class CustomerView : ContentPage
{
	public CustomerView()
	{
		InitializeComponent();
		BindingContext = new CustomerViewViewModel();
	}

	private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}