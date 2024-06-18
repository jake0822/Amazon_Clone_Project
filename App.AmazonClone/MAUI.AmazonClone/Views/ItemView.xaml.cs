namespace MAUI.AmazonClone.Views;

public partial class ItemView : ContentPage
{
	public ItemView()
	{
		InitializeComponent();
	}

    private void OkClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Inventory");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Inventory");
    }
}