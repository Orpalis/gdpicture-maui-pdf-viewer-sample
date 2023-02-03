using System.Windows.Input;

namespace maui_test.ViewModels
{
    internal class RotatePage270Command : ICommand
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
            _owner.Viewer.RotatePage(_owner.Viewer.CurrentPage, GdPicture14.GdPictureRotateFlipType.GdPictureRotate270FlipNone);
        }


        public RotatePage270Command(MainViewModel owner)
        {
            _owner = owner;
        }
    }
}
