using System.Windows.Input;

namespace maui_test.ViewModels
{
    internal class CopySelectedTextCommand : ICommand
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


        public void Execute(object parameter)
        {
            Clipboard.Default.SetTextAsync(_owner.Viewer.SelectedText);
        }


        public CopySelectedTextCommand(MainViewModel owner)
        {
            _owner = owner;
        }
    }
}
