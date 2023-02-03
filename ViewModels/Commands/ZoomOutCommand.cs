using System.Windows.Input;

namespace maui_test.ViewModels
{
    internal class ZoomOutCommand : ICommand
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
            _owner.Viewer.ZoomOut();
        }


        public ZoomOutCommand(MainViewModel owner)
        {
            _owner = owner;
        }
    }
}
