using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBuddy.ViewModels.Interfaces;

namespace TaskBuddy.ViewModels;
public class TaskIntroViewModel : ObservableObject, INavigableViewModel {
	public string Intro { get; } = "Some introductory text...";
	public string Title => "Introduction";
	public void Load() { }
	public void Reset() { }
}
