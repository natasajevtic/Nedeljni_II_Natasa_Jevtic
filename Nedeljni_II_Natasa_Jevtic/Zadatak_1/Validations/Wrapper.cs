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

        public static readonly DependencyProperty OldDoctorNumberProperty =
        DependencyProperty.Register("OldDoctorNumber", typeof(string),
        typeof(Wrapper), new PropertyMetadata(string.Empty));

        public string OldDoctorNumber
        {
            get { return (string)GetValue(OldDoctorNumberProperty); }
            set { SetValue(OldDoctorNumberProperty, value); }
        }

        public static readonly DependencyProperty OldBankAccountNumberProperty =
        DependencyProperty.Register("OldBankAccountNumber", typeof(string),
        typeof(Wrapper), new PropertyMetadata(string.Empty));

        public string OldBankAccountNumber
        {
            get { return (string)GetValue(OldBankAccountNumberProperty); }
            set { SetValue(OldBankAccountNumberProperty, value); }
        }

        public static readonly DependencyProperty OldHealthInsuranceProperty =
        DependencyProperty.Register("OldHealthInsurance", typeof(string),
        typeof(Wrapper), new PropertyMetadata(string.Empty));

        public string OldHealthInsurance
        {
            get { return (string)GetValue(OldHealthInsuranceProperty); }
            set { SetValue(OldHealthInsuranceProperty, value); }
        }
    }
}
