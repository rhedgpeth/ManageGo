using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using CustomCalendar;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public abstract class BaseFilterViewModel<T> : BaseExpandableCollectionViewModel<T> where T : BaseCollectionSectionViewModel
    {
        public string SearchTerm { get; set; }

        DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                SelectedDateDescription = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_selectedDate.Month)} {_selectedDate.Day}, {_selectedDate.Year}";
            }
        }

        DateRange _selectedDates;
        public DateRange SelectedDates
        {
            get => _selectedDates;
            set
            {
                SetPropertyChanged(ref _selectedDates, value);

                if (_selectedDates != null)
                {
                    var startMonthShortName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_selectedDates.StartDate.Month);

                    if (_selectedDates.EndDate.HasValue && _selectedDates.StartDate != _selectedDates.EndDate.Value)
                    {
                        var endMonthShortName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_selectedDates.EndDate.Value.Month);

                        SelectedDateDescription = $"{startMonthShortName} {_selectedDates.StartDate.Day} - " +
                                                    $"{endMonthShortName} {_selectedDates.EndDate.Value.Day}";
                    }
                    else
                    {
                        SelectedDateDescription = $"{startMonthShortName} {_selectedDates.StartDate.Day}";
                    }
                }
            }
        }

        string _selectedDateDescription;
        public string SelectedDateDescription
        {
            get => _selectedDateDescription;
            set => SetPropertyChanged(ref _selectedDateDescription, value);
        }

        ICommand _applyFilterCommand;
        public ICommand ApplyFilterCommand
        {
            get
            {
                if (_applyFilterCommand == null)
                {
                    _applyFilterCommand = new Command(async () => await LoadAsync(true));
                }

                return _applyFilterCommand;
            }
        }

        public override async Task InitAsync()
        {
            LoadFilters();
            await LoadAsync(true);
        }

        protected virtual void LoadFilters() { }
    }
}
