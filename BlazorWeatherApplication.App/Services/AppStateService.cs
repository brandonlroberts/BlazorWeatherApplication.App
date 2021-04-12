using BlazorWeatherApplication.Shared;
using System;
using System.Threading.Tasks;

namespace BlazorWeatherApplication.App.Services
{
    public class AppStateService
    {
        public static AppState State { get; private set; }
        public static event Action OnChange;

        public static async Task Set(AppState state)
        {
            State = state;
        }        

        public static void NotifyStateChanged() => OnChange?.Invoke();

    }
}
