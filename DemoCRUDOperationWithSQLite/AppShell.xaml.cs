using DemoCRUDOperationWithSQLite.Views;

namespace DemoCRUDOperationWithSQLite
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ManageUserPage), typeof(ManageUserPage));
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
        }

    }
}
