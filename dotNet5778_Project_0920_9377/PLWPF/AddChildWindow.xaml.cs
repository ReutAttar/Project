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
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>
    public partial class AddChildWindow : Window
    {
        Child child;
        IBL myBL;
        public AddChildWindow()
        {
            InitializeComponent();
            child = new Child();
            DataContext = child;
            myBL = BL.FactoryBL.GetInstance;
            this.myMotherIDcombobox.ItemsSource = from motherid in myBL.GetMothersList()  //intialize the mothers id combobox
                                                  select motherid;
        }

        /// <summary>
        /// add child button
        /// when the button clicked the event call the add child function 
        /// with the child details that received   
        /// </summary>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myBL.AddChild(child);
                MessageBox.Show(child.ToString());
                child = new Child();
                DataContext = child;
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void myMotherIDcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e) // get and save the mother id that has been choosen
        {
            child.MyMotherID = ((Mother)myMotherIDcombobox.SelectedItem).ID as string;
        }
    }

}
