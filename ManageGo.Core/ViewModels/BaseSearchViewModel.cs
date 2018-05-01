using System;

namespace ManageGo.Core.ViewModels
{
    public abstract class BaseSearchViewModel : BaseNavigationViewModel
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
