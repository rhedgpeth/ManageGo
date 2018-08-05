using ManageGo.Core.Managers.Enumerations;

namespace ManageGo.Core.Managers.Models
{
    public class BaseResponse<T>
    {
        public ResponseStatus Status { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}


