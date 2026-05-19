using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TaskBuddy.ViewModels.Interfaces;
using TaskBuddy.Views;

namespace TaskBuddy.Converters;
public class StringEqualityConverter : IValueConverter {
	public object Convert( object value, Type targetType, object parameter, CultureInfo culture ) {
		if ( value is IBaseViewModel valueViewModel && parameter is string parameterText )
			return valueViewModel.Title == parameterText;

		return false;
	}

	public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture ) {
		throw new NotImplementedException();
	}
}
