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
    /// Interaction logic for GetChildsListByMotherWindow.xaml
    /// </summary>
    public partial class GetChildsListByMotherWindow : Window
    {
        IBL myBL;
        Mother mother;
        public GetChildsListByMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            myBL = BL.FactoryBL.GetInstance;
            this.MotherIDComboBox.ItemsSource = from motherid in myBL.GetMothersList()
                                          select motherid.ID;
        }

        private void MotherIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Mother> Mothers = myBL.GetMothersList();
            mother = Mothers.Find(m => m.ID == MotherIDComboBox.SelectedItem as string);
            this.getbymother.ItemsSource=myBL.GetChildsListByMother(mother);
        }
    }
}
