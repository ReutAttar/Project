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
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        Mother mother;
        IBL myBL;

        public UpdateMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            DataContext = mother;
            myBL = BL.FactoryBL.GetInstance;
            this.bankNameComboBox.ItemsSource = Enum.GetValues(typeof(BankName));
            this.MotherIDComboBox.ItemsSource= from motherid in myBL.GetMothersList()
                                         select motherid.ID;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mother.PersonAddress = new Address() { City = this.cityTextBox.Text, Country = countryTextBox.Text, Number = Int32.Parse(numberTextBox.Text), Street = streetTextBox.Text };
                mother.GoalAddress = new Address() { City = this.cityTextBox1.Text, Country = countryTextBox1.Text, Number = Int32.Parse(numberTextBox1.Text), Street = streetTextBox1.Text };
                myBL.UpdateMother(mother);
                MessageBox.Show(mother.ToString());
                mother = new Mother();
                DataContext = mother;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
        private void UpdateSchedule(object sender, RoutedEventArgs e)
        {
            UpdateSchedule updateSchedule = new UpdateSchedule();
            updateSchedule.startSunday.Text= mother.HoursNeed[DayOfWeek.Sunday].Key.ToString();
            updateSchedule.endSunday.Text = mother.HoursNeed[DayOfWeek.Sunday].Value.ToString();
            updateSchedule.startMonday.Text = mother.HoursNeed[DayOfWeek.Monday].Key.ToString();
            updateSchedule.endMonday.Text = mother.HoursNeed[DayOfWeek.Monday].Value.ToString();
            updateSchedule.startTuesday.Text = mother.HoursNeed[DayOfWeek.Tuesday].Key.ToString();
            updateSchedule.endTuesday.Text = mother.HoursNeed[DayOfWeek.Tuesday].Value.ToString();
            updateSchedule.startWednesday.Text = mother.HoursNeed[DayOfWeek.Wednesday].Key.ToString();
            updateSchedule.endWednesday.Text = mother.HoursNeed[DayOfWeek.Wednesday].Value.ToString();
            updateSchedule.startThursday.Text = mother.HoursNeed[DayOfWeek.Thursday].Key.ToString();
            updateSchedule.endThursday.Text = mother.HoursNeed[DayOfWeek.Thursday].Value.ToString();

            bool? result = updateSchedule.ShowDialog();
            if (result != false)
            {
                mother.HoursNeed = updateSchedule.MyDictionary;
            }
        }
        private void MotherIDcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Mother> Mothers = myBL.GetMothersList();
            mother = Mothers.Find(m => m.ID == MotherIDComboBox.SelectedItem as string);
            this.cityTextBox.Text = mother.PersonAddress.City;
            this.streetTextBox.Text = mother.PersonAddress.Street;
            this.countryTextBox.Text = mother.PersonAddress.Country;
            this.numberTextBox.Text = mother.PersonAddress.Number.ToString();
            this.cityTextBox1.Text = mother.GoalAddress.City;
            this.streetTextBox1.Text = mother.GoalAddress.Street;
            this.countryTextBox1.Text = mother.GoalAddress.Country;
            this.numberTextBox1.Text = mother.GoalAddress.Number.ToString();
            this.grid1.DataContext = mother;
        }
    }
}
