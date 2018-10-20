using Xamarin.Forms;

namespace ManageGo.Triggers
{
    public class NumericLimitValidationTrigger : TriggerAction<Entry>
    {
        public string DefaultValue { get; set; }

        public int MaxValue { get; set; }

        protected override void Invoke(Entry sender)
        {
            var isNumeric = int.TryParse(sender.Text, out int n);

            if (!string.IsNullOrWhiteSpace(sender.Text) && (sender.Text.Length > MaxValue || !isNumeric))
            {
                sender.Text = DefaultValue;
                return;
            }

            DefaultValue = sender.Text;
        }
    }
}
