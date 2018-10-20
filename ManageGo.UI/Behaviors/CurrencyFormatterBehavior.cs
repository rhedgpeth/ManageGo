using Xamarin.Forms;

namespace ManageGo.UI.Behaviors
{
    public class CurrencyFormatterBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;

            base.OnDetachingFrom(bindable);
        }

        void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            entry.Text = FormatCurrency(entry.Text);
        }

        string FormatCurrency(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return "$0";
            }

            input.Replace("$", string.Empty);

            return $"${input}";
        }
    }
}
