using ManageGo.Core.Managers.Enumerations;

namespace ManageGo.Core.Managers.Models
{
    public class BaseResponse 
    {
        public ResponseStatus Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Result { get; set; }
    }
}


