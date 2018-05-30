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
    /// Interaction logic for UpdateNannyWindow.xaml
    /// </summary>
    public partial class UpdateNannyWindow : Window
    {
        Nanny nanny;
        IBL myBL;

        public UpdateNannyWindow()
        {
            InitializeComponent();
            nanny = new Nanny();
            DataContext = nanny;
            myBL = BL.FactoryBL.GetInstance;

            this.bankNameComboBox.ItemsSource = Enum.GetValues(typeof(BankName));
            this.NannyIDcomboBox.ItemsSource = from nannyid in myBL.GetNannysList()
                                               select nannyid.ID;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny.PersonAddress = new Address() { City = this.cityTextBox.Text, Country = countryTextBox.Text, Number = Int32.Parse(numberTextBox.Text) };
                nanny.range = minChildrensAgeTextBox.Text + "-" + maxChildrensAgeTextBox.Text;
                myBL.UpdateNanny(nanny);
                MessageBox.Show(nanny.ToString());
                nanny = new Nanny();
                DataContext = nanny;

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
            updateSchedule.startSunday.Text = nanny.WorkHours[DayOfWeek.Sunday].Key.ToString();
            updateSchedule.endSunday.Text = nanny.WorkHours[DayOfWeek.Sunday].Value.ToString();
            updateSchedule.startMonday.Text = nanny.WorkHours[DayOfWeek.Monday].Key.ToString();
            updateSchedule.endMonday.Text = nanny.WorkHours[DayOfWeek.Monday].Value.ToString();
            updateSchedule.startTuesday.Text = nanny.WorkHours[DayOfWeek.Tuesday].Key.ToString();
            updateSchedule.endTuesday.Text = nanny.WorkHours[DayOfWeek.Tuesday].Value.ToString();
            updateSchedule.startWednesday.Text = nanny.WorkHours[DayOfWeek.Wednesday].Key.ToString();
            updateSchedule.endWednesday.Text = nanny.WorkHours[DayOfWeek.Wednesday].Value.ToString();
            updateSchedule.startThursday.Text = nanny.WorkHours[DayOfWeek.Thursday].Key.ToString();
            bool? result = updateSchedule.ShowDialog();
            if (result != false)
            {
                nanny.WorkHours = updateSchedule.MyDictionary;
            }
        }

        private void NannyIDcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Nanny> Nannys = myBL.GetNannysList();
            nanny = Nannys.Find(n=> n.ID == NannyIDcomboBox.SelectedItem as string);
            this.cityTextBox.Text = nanny.PersonAddress.City;
            this.streetTextBox.Text = nanny.PersonAddress.Street;
            this.countryTextBox.Text = nanny.PersonAddress.Country;
            this.numberTextBox.Text = nanny.PersonAddress.Number.ToString();
            this.grid1.DataContext = nanny;

        }
    }
}
