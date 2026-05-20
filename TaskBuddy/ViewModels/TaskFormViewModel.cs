using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBuddy.ViewModels.Interfaces;

namespace TaskBuddy.ViewModels;
public class TaskFormViewModel : ObservableObject, INavigableViewModel {
	public string Title => "Empty Task Form";
	public void Load() { }
	public void Reset() { }
}
