using System;
using ManageGo.Core.Validation;

using System.ComponentModel.DataAnnotations;

namespace ManageGo.Core.Managers.Models
{
	public class Registration : ValidatableBase
    {      
		const string NAMESREGEXPATTERN = @"\A\p{L}+([\p{Zs}\-][\p{L}]+)*\z";
       

		string _name = "Rob";
       
		[Required(ErrorMessage = "Name is required.")]
        [RegularExpression(NAMESREGEXPATTERN, ErrorMessage = "Name contains invalid characters.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name requires a minimum of 2 characters and a maximum of 10.")]
        public string Name
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value);
        }

        string _companyName;

		[Required(ErrorMessage = "Company name is required.")]
        [RegularExpression(NAMESREGEXPATTERN, ErrorMessage = "Company name contains invalid characters.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Company name requires a minimum of 2 characters and a maximum of 15.")]
        public string CompanyName
        {
            get => _companyName;
            set => SetPropertyChanged(ref _companyName, value);
        }

        string _email;
        public string Email
        {
            get => _email;
            set => SetPropertyChanged(ref _email, value);
        }

        string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetPropertyChanged(ref _phoneNumber, value);
        }

        string _unitCount;
        public string UnitCount
        {
            get => _unitCount;
            set => SetPropertyChanged(ref _unitCount, value);
        }
    }
}
