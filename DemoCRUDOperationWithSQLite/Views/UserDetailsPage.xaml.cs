using DemoCRUDOperationWithSQLite.ViewModels;

namespace DemoCRUDOperationWithSQLite.Views;

public partial class UserDetailsPage : ContentPage
{
	public UserDetailsPage(UserDetailsPageViewModel userDetailsPageViewModel)
	{
		InitializeComponent();
		BindingContext = userDetailsPageViewModel;
	}
}