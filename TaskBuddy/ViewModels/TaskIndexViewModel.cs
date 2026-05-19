using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using TaskBuddy.Data;
using TaskBuddy.ViewModels.Interfaces;

namespace TaskBuddy.ViewModels;
public class TaskIndexViewModel : ObservableObject, IBaseViewModel {
	private readonly IDataAccessProvider<TaskItem, Guid> _dataProvider;

	public TaskIndexViewModel(IDataAccessProvider<TaskItem, Guid> dataProvider) {
		_dataProvider = dataProvider;
		ToggleCompletedCommand = new RelayCommand<TaskItem>( ToggleCompleted );
		EditTaskCommand = new RelayCommand<TaskItem>( EditTask );
	}
	public IRelayCommand<TaskItem> ToggleCompletedCommand { get; }
	public IRelayCommand<TaskItem> EditTaskCommand { get; }
	public IReadOnlyList<TaskItem> Items { get; private set; }
	public string Title => "Task Index";
	public void Load() => Items = _dataProvider.GetAll();
	public void Reset() { }
	private void ToggleCompleted( TaskItem task ) => throw new NotImplementedException();
	private void EditTask( TaskItem task ) => throw new NotImplementedException();
}
