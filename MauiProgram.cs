#if WINDOWS
//#define WINDOWS_FULL_SCREEN_START
#endif

using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using System.Windows.Input;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace maui_test;

public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {
        new GdPicture14.LicenseManager().RegisterKEY("0499485907387127663371864");

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
#if WINDOWS_FULL_SCREEN_START
            .ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(windowsLifecycleBuilder =>
                {
                    windowsLifecycleBuilder.OnWindowCreated(window =>
                    {
                        window.ExtendsContentIntoTitleBar = false;
                        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        var id = Win32Interop.GetWindowIdFromWindow(handle);
                        var appWindow = AppWindow.GetFromWindowId(id);
                        switch (appWindow.Presenter)
                        {
                            case OverlappedPresenter overlappedPresenter:
                                overlappedPresenter.SetBorderAndTitleBar(true, true);
                                overlappedPresenter.Maximize();
                                break;
                        }
                    });
                });
            })
#endif

            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
