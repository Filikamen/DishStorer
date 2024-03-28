using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;


namespace DishStorer.View.UserControls
{
    /// <summary>
    /// Interaction logic for ClearableTextBox.xaml
    /// </summary>
    public partial class ClearableTextBox : UserControl, INotifyPropertyChanged
    {
        public ClearableTextBox()
        {
            InitializeComponent();
        }
        private string placeholder;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                tbPlaceholder.Text = placeholder;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Placeholder"));
            }
        }
        private string contentTextBox;
        public string ContentTextBox
        {
            get { return contentTextBox; }
            set
            {

            }
        }
        private string textBoxName;
        public string TextBoxName
        {
            get { return textBoxName; }
            set
            {
                textBoxName = value;

            }
        }




        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else
                tbPlaceholder.Visibility = Visibility.Hidden;
        }
    }
}
