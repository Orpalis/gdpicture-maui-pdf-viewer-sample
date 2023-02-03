using System.Windows.Input;

namespace maui_test.ViewModels
{
    internal class ExitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            Application.Current.Quit();
        }
    }
}
