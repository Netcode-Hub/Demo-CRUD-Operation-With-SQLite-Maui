using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoCRUDOperationWithSQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUDOperationWithSQLite.ViewModels
{
    [QueryProperty(nameof(NewUserModel), "UserDetails")]
    public partial class UserDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _newUserModel;

        [RelayCommand]
        public async Task Home()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
