using BE;
using BL;
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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        Nanny nanny;
        IBL myBL;
        public AddNannyWindow()
        {
            InitializeComponent();
            nanny = new Nanny();
            DataContext = nanny;
            myBL = BL.FactoryBL.GetInstance;
            this.bankNameComboBox.ItemsSource = Enum.GetValues(typeof(BankName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny.PersonAddress = new Address() { City = this.cityTextBox.Text, Country = countryTextBox.Text,Street=this.streetTextBox.Text ,Number = Int32.Parse(numberTextBox.Text) };
                nanny.range = minChildrensAgeTextBox.Text + "-" + maxChildrensAgeTextBox.Text;
                myBL.AddNanny(nanny);
                nanny = new Nanny();
                DataContext = nanny;
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            EditSchedule editSchedule = new EditSchedule();
            bool? result = editSchedule.ShowDialog();
            if (result != false)
            {
                nanny.WorkHours = editSchedule.MyDictionary;
            }
        }
    }
}
