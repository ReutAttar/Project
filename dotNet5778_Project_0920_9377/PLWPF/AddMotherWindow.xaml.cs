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
    /// Interaction logic for AddMotherWindow.xaml
    /// </summary>
    public partial class AddMotherWindow : Window
    {
        Mother mother;
        IBL myBL;

        public AddMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            DataContext = mother;
            myBL = BL.FactoryBL.GetInstance;
            this.bankNameComboBox.ItemsSource = Enum.GetValues(typeof(BankName));// Initialize the bank name combobox
        }
        /// <summary>
        /// add mother button
        /// when the button clicked the event call the add mother function
        /// with the mother details that received 
        /// show the mother details 
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mother.PersonAddress = new Address() { City = this.cityTextBox.Text, Country = countryTextBox.Text, Number = Int32.Parse(numberTextBox.Text), Street = streetTextBox.Text };
                mother.GoalAddress = new Address() { City = this.cityTextBox1.Text, Country = countryTextBox1.Text, Number = Int32.Parse(numberTextBox1.Text), Street = streetTextBox1.Text };
                // mother.MotherAccount = new BankAccount() { AccountNumber = Int32.Parse(this.accountNumberTextBox.Text),Balance=Int32.Parse(this.balanceTextBox.Text), BranchNumber = Int32.Parse(this.branchNumberTextBox.Text), BankAdress = new Address { Number = 12, Street = "Hadekel", City = "Eilat", Country = "Israel" } };
                myBL.AddMother(mother);
                MessageBox.Show(mother.ToString());
                mother = new Mother();
                DataContext = mother;
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Enables filling a schedule that the mother wants to hire the nanny

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditSchedule editSchedule = new EditSchedule();
            bool? result = editSchedule.ShowDialog();
            if (result != false)
            {
                mother.HoursNeed = editSchedule.MyDictionary;//read the details to the mother schedule
            }
        }
    }
}