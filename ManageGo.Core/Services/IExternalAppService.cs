using System;

namespace ManageGo.Core.Services
{
	public interface IExternalAppService
	{
		void CallPhoneNumber(string phoneNumber);
		void Open(Uri uri);
	}
}
