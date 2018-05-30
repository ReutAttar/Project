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
    /// Interaction logic for DeleteContractWindow.xaml
    /// </summary>
    public partial class DeleteContractWindow : Window
    {
        Contract contract;
        IBL myBL;

        public DeleteContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            DataContext = contract;
            myBL = BL.FactoryBL.GetInstance;
            this.ContractNumberComboBox.ItemsSource = from Contract in myBL.GetContractsList()
                                          select Contract.ContractNumber;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DeleteContract(contract);
                contract = new Contract();
                DataContext = contract;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void ContractNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Contract> contracts = myBL.GetContractsList();
            contract = contracts.Find(c => c.ContractNumber.ToString() == ContractNumberComboBox.SelectedItem.ToString());
            this.MotherId.Text = contract.MotherID;
            this.NannyId.Text = contract.NannyID;
            this.ChildId.Text = contract.ChildID;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
