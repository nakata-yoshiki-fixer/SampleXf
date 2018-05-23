using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AppCenter.Analytics;

namespace XF.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
    {      
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected BaseViewModel(string name)
		{
			Analytics.TrackEvent("ViewModelCreate", new Dictionary<string, string>
            {
                {"name", name}
            });
		}

		protected BaseViewModel()
		{
		}
	}
}
