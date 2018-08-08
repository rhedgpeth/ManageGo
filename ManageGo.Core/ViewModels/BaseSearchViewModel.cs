using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;

namespace ManageGo.Core.ViewModels
{
    public abstract class BaseSearchViewModel<T> : BaseCollectionViewModel<T>
    {
        public BaseSearchViewModel()
        { }

		protected  Random random = new Random();

        protected double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }
    }
}
