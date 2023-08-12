using DemoCRUDOperationWithSQLite.ViewModels;

namespace DemoCRUDOperationWithSQLite.Views;

public partial class UsersListPage : ContentPage
{
    private readonly UsersListPageViewmodel usersListPageViewmodel;

    public UsersListPage(UsersListPageViewmodel usersListPageViewmodel)
	{
		InitializeComponent();
		BindingContext = usersListPageViewmodel;
        this.usersListPageViewmodel = usersListPageViewmodel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        usersListPageViewmodel.LoadUserFromDatabaseCommand.Execute(null);
    }
}