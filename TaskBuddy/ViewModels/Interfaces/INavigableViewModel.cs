using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBuddy.ViewModels.Interfaces;
public interface INavigableViewModel {
	string Title { get; }
	void Load();
	void Reset();

}
