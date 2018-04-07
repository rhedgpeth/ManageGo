using System.Threading.Tasks;

namespace ManageGo.Core.ViewModels
{
    public abstract class BaseViewModel : BaseNotify
    {
        public virtual Task InitAsync() => Task.FromResult(true);
    }
}
