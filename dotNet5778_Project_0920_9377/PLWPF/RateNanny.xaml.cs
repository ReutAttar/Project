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
    /// Interaction logic for RateNanny.xaml
    /// </summary>
    public partial class RateNanny : Window
    {
        IBL myBL;
        Contract contract;
        bool star1 = false;
        bool star2 = false;
        bool star3 = false;
        bool star4 = false;
        bool star5 = false;
        BitmapImage bitmapWhite;
        BitmapImage bitmapYellow;
        static int counter = 0;
        String nannyid;
        Nanny nanny;

        public RateNanny()
        {
            InitializeComponent();
            myBL = BL.FactoryBL.GetInstance;
            contract = new Contract();
            DataContext = contract;
            this.ContractComboBox.ItemsSource = from contract in myBL.GetContractsList()
                                                select contract;
            Uri uri = new Uri("C:/Users/owner/Documents/Reut/c#/פרוייקט/dotNet5778_Project_0920_9377/PLWPF/image/yellowStar.png");
            bitmapYellow = new BitmapImage(uri);
            Uri uri2 = new Uri("C:/Users/owner/Documents/Reut/c#/פרוייקט/dotNet5778_Project_0920_9377/PLWPF/image/whiteStar.png");
            bitmapWhite = new BitmapImage(uri2);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            star1 = true;
            if (star5)
            {
                star5 = false;
                Image5.Source = bitmapWhite;
                Image4.Source = bitmapWhite;
                Image3.Source = bitmapWhite;
                Image2.Source = bitmapWhite;
                Image1.Source = bitmapYellow;
            }
            else if (star4)
            {
                star4 = false;
                Image4.Source = bitmapWhite;
                Image3.Source = bitmapWhite;
                Image2.Source = bitmapWhite;
                Image1.Source = bitmapYellow;
            }
            else if (star3)
            {
                star3 = false;
                Image3.Source = bitmapWhite;
                Image2.Source = bitmapWhite;
                Image1.Source = bitmapYellow;
            }
            else if (star2)
            {
                star2 = false;
                Image2.Source = bitmapWhite;
                Image1.Source = bitmapYellow;
            }
            else Image1.Source = bitmapYellow;
            star5 = false; star2 = false; star3 = false; star4 = false;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            star2 = true; 
            if (star5)
            {
                star5 = false;
                Image5.Source = bitmapWhite;
                Image4.Source = bitmapWhite;
                Image3.Source = bitmapWhite;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            else if (star4)
            {
                star4 = false;
                Image4.Source = bitmapWhite;
                Image3.Source = bitmapWhite;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            else if (star3)
            {
                star3 = false;
                Image3.Source = bitmapWhite;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            else
            {
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            star1 = false; star5 = false; star3 = false; star4 = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            star3 = true; 
            if (star5)
            {
                star5 = false;
                Image5.Source = bitmapWhite;
                Image4.Source = bitmapWhite;
                Image3.Source = bitmapYellow;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            else if (star4)
            {
                star4 = false;
                Image4.Source = bitmapWhite;
                Image3.Source = bitmapYellow;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            else
            {
                Image3.Source = bitmapYellow;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            star1 = false; star2 = false; star5 = false; star4 = false;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            star4 = true; 
            if (star5)
            {
                star5 = false;
                Image5.Source = bitmapWhite;
                Image4.Source = bitmapYellow;
                Image3.Source = bitmapYellow;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            else
            {
                Image4.Source = bitmapYellow;
                Image3.Source = bitmapYellow;
                Image2.Source = bitmapYellow;
                Image1.Source = bitmapYellow;
            }
            star1 = false; star2 = false; star3 = false; star5 = false;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            star5 = true; star1 = false; star2 = false; star3 = false; star4 = false;
            Image5.Source = bitmapYellow;
            Image4.Source = bitmapYellow;
            Image3.Source = bitmapYellow;
            Image2.Source = bitmapYellow;
            Image1.Source = bitmapYellow;
        }

        private void rateButton_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            nannyid = ((Contract)this.ContractComboBox.SelectedItem).NannyID;
            nanny = myBL.GetNannysList().Find(item => item.ID == nannyid);
            if (star1)
            {            
                myBL.calcAvarege(nanny, counter, 1);
            }
            else if (star2)
            {
                myBL.calcAvarege(nanny, counter, 2);
            }
            else if (star3)
            {
                myBL.calcAvarege(nanny, counter, 3);
            }
            else if (star4)
            {
                myBL.calcAvarege(nanny, counter, 4);
            }
            else if (star5)
            {
                myBL.calcAvarege(nanny, counter, 5);
            }
            this.Close();
        }
    }
}
