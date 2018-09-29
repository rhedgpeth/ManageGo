using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        List<string> _topics = new List<string> { "General feedback", "Support" };
        public List<string> Topics 
        {
            get => _topics;
            set => SetPropertyChanged(ref _topics, value);
        }

        string _selectedTopic;
        public string SelectedTopic
		{
			get 
            {
                if (string.IsNullOrEmpty(_selectedTopic))
                {
                    _selectedTopic = Topics[0];
                }

                return _selectedTopic;
            }
			set => SetPropertyChanged(ref _selectedTopic, value);
		}

        string _comments;
        public string Comments
        {
            get => _comments;
            set => SetPropertyChanged(ref _comments, value);
        }

		ICommand _submitCommand;
        public ICommand SubmitCommand 
		{
			get
			{
				if (_submitCommand == null)
				{
					_submitCommand = new Command(async () => await SubmitFeedback());
				}

				return _submitCommand;
			}
		}

        public FeedbackViewModel()
        {
			Title = "App Feedback";
        }

        async Task SubmitFeedback()
        {
            // TODO: Add the feedback submission

            Reset();

            await AlertService.ShowToast(Core.Enumerations.AlertType.Success, 
                                         "Feedback Submitted", "Your feedback has been submitted to ManagoGo.");
        }

        void Reset()
        {
            SelectedTopic = Topics[0];
            Comments = null;
        }
    }
}
