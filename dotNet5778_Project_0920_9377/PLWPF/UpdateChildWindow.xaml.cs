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
    /// Interaction logic for UpdateChildWindow.xaml
    /// </summary>
    public partial class UpdateChildWindow : Window
    {
        Child child;
        IBL myBL;

        public UpdateChildWindow()
        {
            InitializeComponent();
            child = new Child();
            DataContext = child;
            myBL = BL.FactoryBL.GetInstance;
            this.iDcomboBox.ItemsSource = from childid in myBL.GetChildsList()
                                          select childid.ID;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (allergyCheckBox.IsChecked == false)
                {
                    myAllergyTextBox.Text = "";
                    child.MyAllergy = "";
                }
                if(specialNeedsCheckBox.IsChecked==false)
                {
                    needsTextBox.Text = "";
                    child.Needs = "";
                }
                myBL.UpdateChild(child);
                MessageBox.Show(child.ToString());
                child = new Child();
                DataContext = child;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void ChildiDcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Child> Childs = myBL.GetChildsList();
            child = Childs.Find(c => c.ID == iDcomboBox.SelectedItem as string);
            
            this.grid1.DataContext = child;
        }
    }
}
