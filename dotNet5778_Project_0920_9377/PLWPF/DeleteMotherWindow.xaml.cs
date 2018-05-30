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
    /// Interaction logic for DeleteMotherWindow.xaml
    /// </summary>
    public partial class DeleteMotherWindow : Window
    {
        Mother mother;
        IBL myBL;
        public DeleteMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            DataContext = mother;
            myBL = BL.FactoryBL.GetInstance;
            this.iDComboBox.ItemsSource = from mothers in myBL.GetMothersList()
                                          select mothers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DeleteMother(mother);
                mother = new Mother();
                DataContext = mother;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Mother> Mothers = myBL.GetMothersList();
            mother = Mothers.Find(m => m.ID == ((Mother)iDComboBox.SelectedItem).ID as string);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
