using BE;
using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        IBL myBL;
        Contract contract;
        Mother mother;

        public AddContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            DataContext = contract;
            myBL = BL.FactoryBL.GetInstance;
            this.motherIDComboBox.ItemsSource = from mothers in myBL.GetMothersList()
                                                select mothers;
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.EmploymentHours = mother.HoursNeed;
                if (monthCheckBox.IsChecked == true)
                    contract.Payment = true;
                else contract.Payment = false;
                
                myBL.AddContract(contract);
                MessageBox.Show(contract.ToString());
                contract = new Contract();
                DataContext = contract;
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void motherIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Mother> Mothers = myBL.GetMothersList();
            mother = Mothers.Find(m => m.ID == ((Mother)motherIDComboBox.SelectedItem).ID as string);
            contract.MotherID = ((Mother)motherIDComboBox.SelectedItem).ID.ToString();
            this.childIDComboBox.ItemsSource = from child in myBL.GetChildsListByMother(mother)
                                               select child;
        }
        private void childIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contract.ChildID = ((Child)childIDComboBox.SelectedItem).ID.ToString();
        }

        private void constraintsButton_Click(object sender, RoutedEventArgs e)
        {
            Constraints constraints = new Constraints(this, mother);
            constraints.ShowDialog();
        }

        private void nannyIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contract.NannyID = ((Nanny)nannyIDComboBox.SelectedItem).ID.ToString();
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
