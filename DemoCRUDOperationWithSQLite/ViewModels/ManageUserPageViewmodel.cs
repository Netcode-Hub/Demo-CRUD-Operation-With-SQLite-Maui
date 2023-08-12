using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoCRUDOperationWithSQLite.Models;
using DemoCRUDOperationWithSQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUDOperationWithSQLite.ViewModels
{
    [QueryProperty(nameof(NewUser), "UserDetails")]
    public partial class ManageUserPageViewmodel : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        User _newUser;


        private readonly IUserService userService;
        public ManageUserPageViewmodel(IUserService userService)
        {
            Title = "Manager User";
            this.userService = userService;
            NewUser = new User();
        }



        [RelayCommand]
        async Task SaveUser()
        {
            if (NewUser is null)
                return;

            var result = -1;
            if (NewUser.Id > 0)
            {
                var checkUser = await userService.GetUser(NewUser.Email);

                if (checkUser != null)
                {
                    if (checkUser.Name == NewUser.Name && checkUser.Email == NewUser.Email && checkUser.Location == NewUser.Location)
                    {
                        CreateToast("User already exist"); return;
                    }
                    result = await userService.UpdateAsync(NewUser);
                }

                
            }

            else
            {
                result = await userService.AddAsync(NewUser);
            }



            if (result > 0)
            {
                CreateToast("Data saved successfully");
                NewUser = new User();
            }

            else
            {
                CreateToast("Error occured whiles processing your request");
            }
                
        }

        private async void CreateToast(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
