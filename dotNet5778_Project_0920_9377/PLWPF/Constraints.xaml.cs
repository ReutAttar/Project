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
    /// Interaction logic for Constraints.xaml
    /// </summary>
    public partial class Constraints : Window
    {
        IBL myBL;
        Mother mother;
        Address Goaladdress;
        int dis;
        int NannyAge;
        Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed;
        float MaxPayment;
        int experience;
        int MaxChilds;
        float ChildAge;
        AddContractWindow addcontractwindow;

        private List<Nanny> TmpNannys;

        private List<Nanny> Nannys;

        public List<Nanny> nannys
        {
            get { return Nannys; }
        }

        public Constraints()
        {
            InitializeComponent();

        }

        public Constraints(AddContractWindow window,Mother m)//constructor that get the mother from the AddContractWindow
        {
            InitializeComponent();
            myBL = BL.FactoryBL.GetInstance;
            Nannys = new List<Nanny>();
            mother = m;
            this.startSunday.Text = this.startSunday1.Text = m.HoursNeed[DayOfWeek.Sunday].Key.ToString();
            this.endSunday.Text = this.endSunday1.Text = m.HoursNeed[DayOfWeek.Sunday].Value.ToString();
            this.startMonday.Text = this.startMonday1.Text = m.HoursNeed[DayOfWeek.Monday].Key.ToString();
            this.endMonday.Text = this.endMonday1.Text = m.HoursNeed[DayOfWeek.Monday].Value.ToString();
            this.startTuesday.Text = this.startTuesday1.Text = m.HoursNeed[DayOfWeek.Tuesday].Key.ToString();
            this.endTuesday.Text = this.endTuesday1.Text = m.HoursNeed[DayOfWeek.Tuesday].Value.ToString();
            this.startWednesday.Text = this.startWednesday1.Text = m.HoursNeed[DayOfWeek.Wednesday].Key.ToString();
            this.endWednesday.Text = this.endWednesday1.Text = m.HoursNeed[DayOfWeek.Wednesday].Value.ToString();
            this.startThursday.Text = this.startThursday1.Text = m.HoursNeed[DayOfWeek.Thursday].Key.ToString();
            this.endThursday.Text = this.endThursday1.Text = m.HoursNeed[DayOfWeek.Thursday].Value.ToString();
            addcontractwindow = window;
        }

        private void FindByAddress_Click(object sender, RoutedEventArgs e)
        {
            Goaladdress = mother.GoalAddress;// new Address() { Country = CountryTextBox1.Text, City = CityTextBox1.Text, Street = StreetTextBox1.Text, Number = Int32.Parse(NumberTextBox1.Text) };
            BackgroundWorker work = null;
            dis = Int32.Parse(DistanceTextBox1.Text);
            NannyAge = Int32.Parse(NannyAgeTextBox1.Text);
            HoursNeed = mother.HoursNeed;
            MaxPayment = float.Parse(MaxpaymentTextBox1.Text);
            experience = Int32.Parse(experienceTextBox1.Text);
            MaxChilds = Int32.Parse(MaxChildsTextBox1.Text);
            ChildAge = float.Parse(ChildAgeTextBox1.Text);
            work = new BackgroundWorker();
            work.DoWork += W_DoWork;
            work.RunWorkerCompleted += W_RunWorkerCompleted;
            work.RunWorkerAsync();
        }

        private void W_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (TmpNannys.Count != 0)
            {
                Nannys = TmpNannys;
                addcontractwindow.nannyIDComboBox.ItemsSource = Nannys;
                this.Close();
            }
            else
            {
                MessageBox.Show("we could not find any nanny, please chenge your constraints");
            }
            
        }

        private void W_DoWork(object sender, DoWorkEventArgs e)
        {
            TmpNannys = myBL.SelectedNannysByAddress(Goaladdress, dis, NannyAge, HoursNeed, MaxPayment, experience, MaxChilds, ChildAge);
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Nannys = myBL.SelectedNannys(Int32.Parse(NannyAgeTextBox.Text), mother.HoursNeed, float.Parse(MaxpaymentTextBox.Text), Int32.Parse(experienceTextBox.Text), Int32.Parse(MaxChildsTextBox.Text), float.Parse(ChildAgeTextBox.Text));
            if(Nannys.Count!=0)
            {
                addcontractwindow.nannyIDComboBox.ItemsSource = Nannys;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("we could not find any nanny, please chenge your constraints");
            }
        }

    }
}
