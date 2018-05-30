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
    /// Interaction logic for GetContractsListWindow.xaml
    /// </summary>
    public partial class GetContractsListWindow : Window
    {
        IBL myBL;
        public GetContractsListWindow()
        {
            InitializeComponent();
            myBL = BL.FactoryBL.GetInstance;
            this.getcontractslist.ItemsSource = myBL.GetContractsList();
            
        }
    }
}
