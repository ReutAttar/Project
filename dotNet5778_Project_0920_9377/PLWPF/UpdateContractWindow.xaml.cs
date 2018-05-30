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
    /// Interaction logic for UpdateContractWindow.xaml
    /// </summary>
    public partial class UpdateContractWindow : Window
    {
        Contract contract;
        IBL myBL;

        public UpdateContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            DataContext = contract;
            myBL = BL.FactoryBL.GetInstance;
            this.ContractNumberComboBox.ItemsSource = from contractnums in myBL.GetContractsList()
                                                      select contractnums.ContractNumber;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (monthCheckBox.IsChecked == true)
                    contract.Payment = true;
                else contract.Payment = false;
                myBL.UpdateContract(contract);
                MessageBox.Show(contract.ToString());
                contract = new Contract();
                DataContext = contract;
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
            updateSchedule.startSunday.Text = contract.EmploymentHours[DayOfWeek.Sunday].Key.ToString();
            updateSchedule.endSunday.Text = contract.EmploymentHours[DayOfWeek.Sunday].Value.ToString();
            updateSchedule.startMonday.Text = contract.EmploymentHours[DayOfWeek.Monday].Key.ToString();
            updateSchedule.endMonday.Text = contract.EmploymentHours[DayOfWeek.Monday].Value.ToString();
            updateSchedule.startTuesday.Text = contract.EmploymentHours[DayOfWeek.Tuesday].Key.ToString();
            updateSchedule.endTuesday.Text = contract.EmploymentHours[DayOfWeek.Tuesday].Value.ToString();
            updateSchedule.startWednesday.Text = contract.EmploymentHours[DayOfWeek.Wednesday].Key.ToString();
            updateSchedule.endWednesday.Text = contract.EmploymentHours[DayOfWeek.Wednesday].Value.ToString();
            updateSchedule.startThursday.Text = contract.EmploymentHours[DayOfWeek.Thursday].Key.ToString();
            updateSchedule.endThursday.Text = contract.EmploymentHours[DayOfWeek.Thursday].Value.ToString();

            bool? result = updateSchedule.ShowDialog();
            if (result != false)
            {
                contract.EmploymentHours = updateSchedule.MyDictionary;
            }
        }

        private void ContractNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Contract> contracts = myBL.GetContractsList();
            contract = contracts.Find(c =>c.ContractNumber.ToString() == ContractNumberComboBox.SelectedItem.ToString());
            if (contract.Payment == true)
            {
                this.monthCheckBox.IsChecked = true;
            }
            else
            {
                this.hourCheckBox.IsChecked = true;
            }
            this.DataContext = contract;
        }

        private void monthCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.hourCheckBox.IsChecked = false;
        }

        private void hourCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.monthCheckBox.IsChecked = false;
        }
    }
}
