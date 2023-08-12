using DemoCRUDOperationWithSQLite.ViewModels;

namespace DemoCRUDOperationWithSQLite.Views;

public partial class ManageUserPage : ContentPage
{
	public ManageUserPage(ManageUserPageViewmodel manageUserPageViewmodel)
	{
		InitializeComponent();
		BindingContext = manageUserPageViewmodel;
	}
}