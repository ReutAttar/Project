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
    /// Interaction logic for DeleteChildWindow.xaml
    /// </summary>
    public partial class DeleteChildWindow : Window
    {
        Child child;
        IBL myBL;
        public DeleteChildWindow()
        {
            InitializeComponent();
            child = new Child();
            DataContext = child;
            myBL = BL.FactoryBL.GetInstance; 
            this.iDComboBox.ItemsSource = from childs in myBL.GetChildsList()
                                           select childs;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.DeleteChild(child);
                child = new Child();
                DataContext = child;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Child> Childs = myBL.GetChildsList();
            child = Childs.Find(c => c.ID == ((Child)iDComboBox.SelectedItem).ID as string);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
