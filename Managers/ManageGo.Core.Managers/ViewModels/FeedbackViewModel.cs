using System;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class FeedbackViewModel : BaseNavigationViewModel
    {
        public string Description 
		{
			get
			{
				return "Questions about the app? Want to request a new feature? " +
					"Complete this form and we will get back to you.";
			}
		}

		string _selectedTopic = "General feedback";
        public string SelectedTopic
		{
			get => _selectedTopic;
			set => SetPropertyChanged(ref _selectedTopic, value);
		}

		ICommand _submitCommand;
        public ICommand SubmitCommand 
		{
			get
			{
				if (_submitCommand == null)
				{
					// TODO
					_submitCommand = new Command(() => { });
				}

				return _submitCommand;
			}
		}

        public FeedbackViewModel()
        {
			Title = "App Feedback";
        }
    }
}
