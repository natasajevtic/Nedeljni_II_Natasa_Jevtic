using System.Windows;

namespace Zadatak_1.Validations
{
    class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty OldValueProperty =
        DependencyProperty.Register("OldValue", typeof(string),
        typeof(Wrapper), new PropertyMetadata(string.Empty));

        public string OldValue
        {
            get { return (string)GetValue(OldValueProperty); }
            set { SetValue(OldValueProperty, value); }
        }

        public static readonly DependencyProperty OldIdCardNumberProperty =
        DependencyProperty.Register("OldIdCardNumber", typeof(string),
        typeof(Wrapper), new PropertyMetadata(string.Empty));

        public string OldIdCardNumber
        {
            get { return (string)GetValue(OldIdCardNumberProperty); }
            set { SetValue(OldIdCardNumberProperty, value); }
        }

        public static readonly DependencyProperty OldNumberOfAmbulanceCarsProperty =
        DependencyProperty.Register("OldNumberOfAmbulanceCars", typeof(int),
        typeof(Wrapper), new PropertyMetadata(int.MinValue));

        public int OldNumberOfAmbulanceCars
        {
            get { return (int)GetValue(OldNumberOfAmbulanceCarsProperty); }
            set { SetValue(OldNumberOfAmbulanceCarsProperty, value); }
        }

        public static readonly DependencyProperty OldNumberOfInvalidsProperty =
        DependencyProperty.Register("OldNumberOfInvalids", typeof(int),
        typeof(Wrapper), new PropertyMetadata(int.MinValue));

        public int OldNumberOfInvalids
        {
            get { return (int)GetValue(OldNumberOfInvalidsProperty); }
            set { SetValue(OldNumberOfInvalidsProperty, value); }
        }
    }
}
