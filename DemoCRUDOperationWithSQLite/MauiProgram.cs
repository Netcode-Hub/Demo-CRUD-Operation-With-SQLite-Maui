using CommunityToolkit.Maui;
using DemoCRUDOperationWithSQLite.Services;
using DemoCRUDOperationWithSQLite.ViewModels;
using DemoCRUDOperationWithSQLite.Views;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace DemoCRUDOperationWithSQLite
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<UsersListPage>();
            builder.Services.AddTransient<UsersListPageViewmodel>();

            builder.Services.AddTransient<UserDetailsPage>();
            builder.Services.AddTransient<UserDetailsPageViewModel>();

            builder.Services.AddTransient<ManageUserPage>();
            builder.Services.AddTransient<ManageUserPageViewmodel>();





#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
