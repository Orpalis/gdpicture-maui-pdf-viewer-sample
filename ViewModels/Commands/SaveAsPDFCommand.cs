using GdPicture14.MAUI.IO;
using System.Diagnostics;
using System.Windows.Input;

namespace maui_test.ViewModels
{
    internal class SaveAsPDFCommand : ICommand
    {
        private MainViewModel _owner;
        public event EventHandler CanExecuteChanged;
        private bool _canExecute;


        public void UpdateCanExecute(bool canExecute)
        {
            if (_canExecute != canExecute)
            {
                _canExecute = canExecute;
                CanExecuteChanged?.Invoke(null, null);
            }
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }


        private static string GetAppPath()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }


        public void Execute(object parameter)
        {
            string outputPath = Path.Combine(GetAppPath(), "output.pdf"); //todo: find a way to have a file selection dialog box.

            using (FileStream fileStream = File.Create(outputPath))
            {
                _owner.Viewer.SaveAsPDF(fileStream, new PDFOutputOptions() { Optimize = false/*set true to enable PDF optimization*/ });
                Browser.Default.OpenAsync(new Uri(outputPath), BrowserLaunchMode.SystemPreferred);
                App.Current.MainPage.DisplayAlert("All right!", $"The PDF has been saved here {outputPath}", "OK");
            }
        }


        public SaveAsPDFCommand(MainViewModel owner)
        {
            _owner = owner;
        }
    }
}
