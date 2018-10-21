using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ManageGo.Core.Validation
{
	public class ValidatableBase : BaseNotify, IValidatableBase
    {
        public bool IsValidationEnabled
        {
            get { return Errors.IsValidationEnabled; }
            set { Errors.IsValidationEnabled = value; }
        }

        public Validator Errors { get; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add { Errors.ErrorsChanged += value; }
            remove { Errors.ErrorsChanged -= value; }
        }

        public ValidatableBase()
        {
            Errors = new Validator(this);
        }

        public ReadOnlyDictionary<string, ReadOnlyCollection<string>> GetAllErrors()
        {
            return Errors.GetAllErrors();
        }

        public bool ValidateProperties()
        {
            return Errors.ValidateProperties();
        }

        public void SetAllErrors(IDictionary<string, ReadOnlyCollection<string>> entityErrors)
        {
            Errors.SetAllErrors(entityErrors);
        }

        protected override bool SetPropertyChanged<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            var result = base.SetPropertyChanged(ref currentValue, newValue, propertyName);

            if (result && !string.IsNullOrWhiteSpace(propertyName))
            {
                if (Errors.IsValidationEnabled)
                {
                    Errors.ValidateProperty(propertyName);
                }
            }

            return result;
        }
    }
}