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
    /// Interaction logic for DeleteNannyWindow.xaml
    /// </summary>
    public partial class DeleteNannyWindow : Window
    {
        Nanny nanny;
        IBL myBL;

        public DeleteNannyWindow()
        {
            InitializeComponent();
            nanny = new Nanny();
            DataContext = nanny;
            myBL = BL.FactoryBL.GetInstance;
            this.iDComboBox.ItemsSource = from nannys in myBL.GetNannysList()
                                          select nannys;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DeleteNanny(nanny);
                nanny = new Nanny();
                DataContext = nanny;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Nanny> Nannys = myBL.GetNannysList();
            nanny = Nannys.Find(n => n.ID == ((Nanny)iDComboBox.SelectedItem).ID as string);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
