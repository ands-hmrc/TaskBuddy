using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskBuddy.Data;
using TaskBuddy.ViewModels.Interfaces;

namespace TaskBuddy.ViewModels;
public class MainWindowViewModel : ObservableObject, INavigableViewModel {
	private INavigableViewModel _currentViewModel;

	public MainWindowViewModel() {
		var dataProvider = new TaskProvider();
		TaskIndexViewModel = new TaskIndexViewModel( dataProvider );
		TaskFormViewModel = new TaskFormViewModel();
		TaskIntroViewModel = new TaskIntroViewModel();
		NavigateToCommand = new RelayCommand<INavigableViewModel>( NavigateTo );
	}

	public IRelayCommand<INavigableViewModel> NavigateToCommand { get; }
	public INavigableViewModel TaskIndexViewModel { get; }
	public INavigableViewModel TaskFormViewModel { get; }
	public INavigableViewModel TaskIntroViewModel { get; }
	public INavigableViewModel CurrentViewModel {
		get => _currentViewModel;
		//private set => _currentViewModel = value; // to demonstrate lack of UI updates
		//private set { if ( _currentViewModel != value ) { _currentViewModel = value;  OnPropertyChanged( nameof( CurrentViewModel ) ); } } // update invoked
		private set => SetProperty( ref _currentViewModel, value );
	}
	public string Title => "Task Buddy";

	public void NavigateTo( INavigableViewModel viewModel ) {
		if ( viewModel is null || viewModel == CurrentViewModel ) return;
		if( CurrentViewModel is not null ) 
			CurrentViewModel.Reset();
		CurrentViewModel = viewModel;
		CurrentViewModel.Load();
	}

	public void Load() { NavigateTo( TaskIntroViewModel ); }

	public void Reset() { }
}
