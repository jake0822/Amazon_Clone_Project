using MAUI.AmazonClone.ViewModels;

namespace MAUI.AmazonClone
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void CustomerClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Customer");
        }
        private void InventoryClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Inventory");
        }
    }

}
