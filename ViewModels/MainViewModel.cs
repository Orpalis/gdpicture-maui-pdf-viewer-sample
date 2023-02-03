using GdPicture14.MAUI;
using System.ComponentModel;
using System.Windows.Input;


namespace maui_test.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private GdViewer _viewer;
        private ExitCommand _exitCommand;
        private FirstPageCommand _firstPageCommand;
        private PreviousPageCommand _previousPageCommand;
        private NextPageCommand _nextPageCommand;
        private LastPageCommand _lastPageCommand;
        private CloseDocumentCommand _closeDocumentCommand;
        private SaveAsPDFCommand _saveAsPDFCommand;
        private ZoomInCommand _zoomInCommand;
        private ZoomOutCommand _zoomOutCommand;
        private RotatePage90Command _rotatePage90Command;
        private RotatePage270Command _rotatePage270Command;
        private HighlightSelectedTextCommand _highlightSelectedTextCommand;
        private UnderlineSelectedTextCommand _underlineSelectedTextCommand;
        private StrikethroughSelectedTextCommand _strikethroughSelectedTextCommand;
        private RemoveSelectedTextCommand _removeSelectedTextCommand;
        private CopySelectedTextCommand _copySelectedTextCommand;


        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand;
            }
        }


        public ICommand CloseDocumentCommand
        {
            get
            {
                return _closeDocumentCommand;
            }
        }


        public ICommand SaveAsPDFCommand
        {
            get
            {
                return _saveAsPDFCommand;
            }
        }


        public ICommand FirstPageCommand
        {
            get
            {
                return _firstPageCommand;
            }
        }


        public ICommand PreviousPageCommand
        {
            get
            {
                return _previousPageCommand;
            }
        }


        public ICommand NextPageCommand
        {
            get
            {
                return _nextPageCommand;
            }
        }


        public ICommand LastPageCommand
        {
            get
            {
                return _lastPageCommand;
            }
        }


        public ICommand ZoomInCommand
        {
            get
            {
                return _zoomInCommand;
            }
        }


        public ICommand ZoomOutCommand
        {
            get
            {
                return _zoomOutCommand;
            }
        }


        public ICommand RotatePage90Command
        {
            get
            {
                return _rotatePage90Command;
            }
        }


        public ICommand RotatePage270Command
        {
            get
            {
                return _rotatePage270Command;
            }
        }


        public ICommand HighlightSelectedTextCommand
        {
            get
            {
                return _highlightSelectedTextCommand;
            }
        }


        public ICommand UnderlineSelectedTextCommand
        {
            get
            {
                return _underlineSelectedTextCommand;
            }
        }


        public ICommand StrikethroughSelectedTextCommand
        {
            get
            {
                return _strikethroughSelectedTextCommand;
            }
        }


        public ICommand RemoveSelectedTextCommand
        {
            get
            {
                return _removeSelectedTextCommand;
            }
        }


        public ICommand CopySelectedTextCommand
        {
            get
            {
                return _copySelectedTextCommand;
            }
        }


        public GdViewer Viewer
        {
            get
            {
                return _viewer;
            }
        }


        public void SetViewer(GdViewer viewer)
        {
            _viewer = viewer;
            _viewer.PropertyChanged += _viewer_PropertyChanged;
            /*_viewer.NewDocumentLoaded += delegate
            {
                _closeDocumentCommand.UpdateCanExecute(true);
                _rotatePage90Command.UpdateCanExecute(true);
                _rotatePage270Command.UpdateCanExecute(true);
            };
            _viewer.DocumentClosed += delegate
            {
                _closeDocumentCommand.UpdateCanExecute(false);
                _rotatePage90Command.UpdateCanExecute(false);
                _rotatePage270Command.UpdateCanExecute(false);
            };*/
        }


        private void _viewer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentPage")
            {
                int currentPage = _viewer.CurrentPage;
                int pageCount = _viewer.PageCount;

                _firstPageCommand.UpdateCanExecute(currentPage > 1 && pageCount > 1);
                _previousPageCommand.UpdateCanExecute(currentPage > 1 && pageCount > 1);
                _nextPageCommand.UpdateCanExecute(currentPage < pageCount);
                _lastPageCommand.UpdateCanExecute(currentPage != pageCount);
            }
            else if (e.PropertyName == "ZoomMax")
            {
                _zoomInCommand.UpdateCanExecute(_viewer.DocumentLoaded && _viewer.Zoom < _viewer.ZoomMax);
            }
            else if (e.PropertyName == "ZoomMin")
            {
                _zoomOutCommand.UpdateCanExecute(_viewer.DocumentLoaded && _viewer.Zoom > _viewer.ZoomMin);
            }
            else if (e.PropertyName == "DocumentLoaded")
            {
                _closeDocumentCommand.UpdateCanExecute(_viewer.DocumentLoaded);
                _saveAsPDFCommand.UpdateCanExecute(_viewer.DocumentLoaded);
                _rotatePage90Command.UpdateCanExecute(_viewer.DocumentLoaded);
                _rotatePage270Command.UpdateCanExecute(_viewer.DocumentLoaded);
            }
            else if (e.PropertyName == "SelectedText")
            {
                _highlightSelectedTextCommand.UpdateCanExecute(!string.IsNullOrWhiteSpace(_viewer.SelectedText));
                _underlineSelectedTextCommand.UpdateCanExecute(!string.IsNullOrWhiteSpace(_viewer.SelectedText));
                _strikethroughSelectedTextCommand.UpdateCanExecute(!string.IsNullOrWhiteSpace(_viewer.SelectedText));
                _removeSelectedTextCommand.UpdateCanExecute(!string.IsNullOrWhiteSpace(_viewer.SelectedText) && _viewer.HasTextRemovalSupport);
                _copySelectedTextCommand.UpdateCanExecute(!string.IsNullOrWhiteSpace(_viewer.SelectedText));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public MainViewModel()
        {
            _exitCommand = new ExitCommand();
            _firstPageCommand = new FirstPageCommand(this);
            _previousPageCommand = new PreviousPageCommand(this);
            _nextPageCommand = new NextPageCommand(this);
            _lastPageCommand = new LastPageCommand(this);
            _closeDocumentCommand = new CloseDocumentCommand(this);
            _saveAsPDFCommand = new SaveAsPDFCommand(this);
            _zoomInCommand = new ZoomInCommand(this);
            _zoomOutCommand = new ZoomOutCommand(this);
            _rotatePage90Command = new RotatePage90Command(this);
            _rotatePage270Command = new RotatePage270Command(this);
            _highlightSelectedTextCommand = new HighlightSelectedTextCommand(this);
            _underlineSelectedTextCommand = new UnderlineSelectedTextCommand(this);
            _strikethroughSelectedTextCommand = new StrikethroughSelectedTextCommand(this);
            _removeSelectedTextCommand = new RemoveSelectedTextCommand(this);
            _copySelectedTextCommand = new CopySelectedTextCommand(this);
        }
    }
}
