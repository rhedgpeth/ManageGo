using System.Windows.Input;

namespace ManageGo.Core.ViewModels
{
    public interface ISupportIncrementalLoading
    {
        int PageSize { get; set; }

        bool HasMoreItems { get; set; }

        bool IsLoadingIncrementally { get; set; }

        ICommand LoadMoreItemsCommand { get; set; }
    }
}


