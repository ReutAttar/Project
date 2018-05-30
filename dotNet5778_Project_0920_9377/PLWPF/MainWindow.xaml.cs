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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL mybl;
        public MainWindow()
        {
            InitializeComponent();
            mybl = BL.FactoryBL.GetInstance;
            this.conditionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.contractConditions));
            initFordebugs(); // add entities 
        }
        private void initFordebugs()
        {
            mybl.AddMother(new BE.Mother
            {
                ID = "123",
                Lastname = "choen",
                FirstName = "Sarah",
                Tel = "01233477",
                PersonAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 7, Street = "Beit Ha-Defus" },
                TelHome = "67767678",
                GoalAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 12, Street = "Kiryat Moshe" },
                HoursNeed = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                },
                MotherAccount = new BE.BankAccount
                {
                    AccountNumber = 222,
                    BankAdress = new BE.Address
                    {
                        City = "jer",
                        Country = "dd",
                        Number = 3,
                        Street = "gf",
                    }
                }
            });
            mybl.AddMother(new BE.Mother
            {
                ID = "456",
                Lastname = "garbi",
                FirstName = "inbal",
                Tel = "09934235",
                PersonAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 10, Street = "Beit Ha-Defus" },
                TelHome = "67767678",
                GoalAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 20, Street = "Kiryat Moshe" },
                HoursNeed = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                },
                MotherAccount = new BE.BankAccount
                {
                    AccountNumber = 222,
                    BankAdress = new BE.Address
                    {
                        City = "jer",
                        Country = "dd",
                        Number = 3,
                        Street = "gf",
                    }
                }
            });
            mybl.AddMother(new BE.Mother
            {
                ID = "789",
                Lastname = "kirsh",
                FirstName = "orly",
                Tel = "0794332",
                PersonAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 12, Street = "Beit Ha-Defus" },
                TelHome = "02994853",
                GoalAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 22, Street = "Kiryat Moshe" },
                HoursNeed = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                },
                MotherAccount = new BE.BankAccount
                {
                    AccountNumber = 222,
                    BankAdress = new BE.Address
                    {
                        City = "jer",
                        Country = "dd",
                        Number = 3,
                        Street = "gf",
                    }
                }
            });
            mybl.AddMother(new BE.Mother
            {
                ID = "1954",
                Lastname = "shpiner",
                FirstName = "chani",
                Tel = "02842114",
                PersonAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 24, Street = "Kiryat Moshe" },
                TelHome = "32400",
                GoalAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 18, Street = "Kiryat Moshe" },
                HoursNeed = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                },
                MotherAccount = new BE.BankAccount
                {
                    AccountNumber = 222,
                    BankAdress = new BE.Address
                    {
                        City = "jer",
                        Country = "dd",
                        Number = 3,
                        Street = "gf",
                    }
                }
            });
            mybl.AddNanny(new BE.Nanny
            {
                ID = "208493965",
                Lastname = "bar",
                FirstName = "chaya",
                Tel = "025800856",
                PersonAddress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 12, Street = "Beit Ha-Defus" },
                Birthday = new DateTime(1988, 2, 2),
                Elevator = true,
                Experience = 5,
                MaxChildrens = 2,
                MinChildrensAge = 3,
                MaxChildrensAge = 24,
                RateForHour = 30,
                SalaryForMonth = 5000,
                WorkHours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                    {
                        {DayOfWeek.Sunday,new KeyValuePair<int,int> (0600,1900) },
                        {DayOfWeek.Monday,new KeyValuePair<int,int> (0600,1900) },
                        {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                        {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,2000) },
                        {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                    },
                VacationDays = true,
                MyRecommendations = "good",
                MyBankAccount = new BE.BankAccount
                {
                    AccountNumber = 222,
                    BankAdress = new BE.Address
                    {
                        City = "d",
                        Country = "dd",
                        Number = 3,
                        Street = "gf",
                    }
                },
                Floor = 8,
                range = "3-24"
            });
            mybl.AddChild(new BE.Child
            {
                ID = "6789",
                FirstName = "chanan",
                Birthday = new DateTime(2017, 8, 1),
                MyMotherID = "123",
                Allergy = true,
                MyAllergy = "Peanuts",
                MyNutrition = "Materna",
                SpecialNeeds = true,
                Needs = "Hyperactive",
            });
            mybl.AddChild(new BE.Child
            {
                ID = "770",
                FirstName = "menachem",
                Birthday = new DateTime(2016, 6, 1),
                MyMotherID = "123",
                Allergy = true,
                MyAllergy = "Peanuts",
                MyNutrition = "Materna",
                SpecialNeeds = true,
                Needs = "Hyperactive",
            });
            mybl.AddContract(new BE.Contract
            {
                MotherID = "123",
                NannyID = "208493965",
                ChildID = "6789",
                AnotherChild = true,
                ContractSigned = true,
                Interview = true,
                StartEmployment = new DateTime(2018, 1, 1),
                EndEmployment = new DateTime(2018, 3, 1),
                EmploymentHours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                },
                Payment = false,
            });
            mybl.AddContract(new BE.Contract
            {
                MotherID = "123",
                NannyID = "208493965",
                ChildID = "770",
                AnotherChild = true,
                ContractSigned = true,
                Interview = true,
                StartEmployment = new DateTime(2018, 2, 1),
                EndEmployment = new DateTime(2018, 8, 1),
                EmploymentHours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                },
                Payment = true,
            });
        }
        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window addmotherwindow = new AddMotherWindow();
            addmotherwindow.ShowDialog();
        }

        private void DeleteMotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window deletemotherwindow = new DeleteMotherWindow();
            deletemotherwindow.ShowDialog();
        }

        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window updatemotherwindow = new UpdateMotherWindow();
            updatemotherwindow.ShowDialog();
        }

        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window addnannywindow = new AddNannyWindow();
            addnannywindow.ShowDialog();
        }

        private void DeleteNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window deletenannywindow = new DeleteNannyWindow();
            deletenannywindow.ShowDialog();
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window upnandateywindow = new UpdateNannyWindow();
            upnandateywindow.ShowDialog();
        }

        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window addchildwindow = new AddChildWindow();
            addchildwindow.ShowDialog();
        }

        private void DeleteChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window deletechildwindow = new DeleteChildWindow();
            deletechildwindow.ShowDialog();
        }

        private void UpdateChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window updatechildwindow = new UpdateChildWindow();
            updatechildwindow.ShowDialog();
        }

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window addcontractwindow = new AddContractWindow();
            addcontractwindow.ShowDialog();
        }

        private void DeleteContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window deletecontractwindow = new DeleteContractWindow();
            deletecontractwindow.ShowDialog();
        }

        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window updatecontractwindow = new UpdateContractWindow();
            updatecontractwindow.ShowDialog();
        }
        private void RateNannyButton_Click(object sender, RoutedEventArgs e) // open a window that enables to rating a nanny 
        {
            Window ratenannywindow = new RateNanny();
            ratenannywindow.ShowDialog();
        }

        private void GetChildsListByMother_Click(object sender, RoutedEventArgs e)
        {
            Window getchildslistbymotherwindow = new GetChildsListByMotherWindow();
            getchildslistbymotherwindow.ShowDialog();
        }

        private void GetChildsList_Click(object sender, RoutedEventArgs e)
        {
            Window getchildslistwindow = new GetChildsListWindow();
            getchildslistwindow.ShowDialog();
        }

        private void GetNannysList_Click(object sender, RoutedEventArgs e)
        {
            Window getnannyslistwindow = new GetNannysListWindow();
            getnannyslistwindow.ShowDialog();
        }

        private void GetMothersList_Click(object sender, RoutedEventArgs e)
        {
            Window getmotherslistwindow = new GetMothersListWindow();
            getmotherslistwindow.ShowDialog();
        }

        private void GetContractsList_Click(object sender, RoutedEventArgs e)
        {
            Window getcontractslistwindow = new GetContractsListWindow();
            getcontractslistwindow.ShowDialog();
        }

        private void GroupNannyByChildAge_Click(object sender, RoutedEventArgs e)
        {
            GroupingUserControl group = new GroupingUserControl();
            group.Source = mybl.GroupNannyByChildAge((bool)sortCheckBox.IsChecked);
            this.page.Content = group;
        }

        private void GroupNannyByAddress_Click(object sender, RoutedEventArgs e)
        {
            GroupingUserControl group = new GroupingUserControl();
            group.Source = mybl.GroupNannyByAddress((bool)sortCheckBox.IsChecked);
            this.page.Content = group;
        }

        private void GroupNannyByChildAgeMaxOrMin_Click(object sender, RoutedEventArgs e)
        {
            if (maxCheckBox.IsChecked == false && minCheckBox.IsChecked == false)
                MessageBox.Show("must check maximum or minimum");
            else
            {
                GroupingUserControl group = new GroupingUserControl();
                group.Source = mybl.GroupNannyByChildAgeMaxOrMin((bool)maxCheckBox.IsChecked, (bool)sortCheckBox.IsChecked);
                this.page.Content = group;
            }
        }
        GroupingUserControl group;
        IEnumerable<IGrouping<double, BE.Contract>> GroupContracts;
        bool flagSort;
        private void GroupContractByDistanceBetweenNannyAndChild_Click(object sender, RoutedEventArgs e) //
        {
            flagSort = (bool)sortCheckBox.IsChecked;
            BackgroundWorker work = null;
            work = new BackgroundWorker();
            work.DoWork += W_DoWork;
            work.RunWorkerCompleted += W_RunWorkerCompleted;
            work.RunWorkerAsync();
            group = new GroupingUserControl();

        }
        private void W_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (GroupContracts != null)
            {
                group.Source = GroupContracts;
                this.page.Content = group;
            }
        }

        private void W_DoWork(object sender, DoWorkEventArgs e)
        {
            GroupContracts = mybl.GroupContractByDistanceBetweenNannyAndChild(flagSort);
        }

        private void maxCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.minCheckBox.IsChecked = false;
        }

        private void minCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.maxCheckBox.IsChecked = false;
        }

        private void ChildWithoutNanny_Click(object sender, RoutedEventArgs e)
        {
            conditionsComboBox.Visibility = Visibility.Collapsed;
            conditionsTextBox.Visibility = Visibility.Collapsed;
            goButton.Visibility = Visibility.Collapsed;
            contractsNumTextBox.Visibility = Visibility.Collapsed;
            List<BE.Child> ch = mybl.ChildWithoutNanny();
            if (ch.Count == 0)
                MessageBox.Show("There is no childrens without Nanny ");
            this.list.ItemsSource = ch;
        }

        private void Tamat_Click(object sender, RoutedEventArgs e)
        {
            conditionsComboBox.Visibility = Visibility.Collapsed;
            conditionsTextBox.Visibility = Visibility.Collapsed;
            goButton.Visibility = Visibility.Collapsed;
            contractsNumTextBox.Visibility = Visibility.Collapsed;
            List<BE.Nanny> na = mybl.Tamat();
            if (na.Count == 0)
                MessageBox.Show("There is no nannys that their vacatinos days are by the Tamat ");
            this.list.ItemsSource = na;
        }

        private void SelectedContracts_Click(object sender, RoutedEventArgs e)
        {
            conditionsComboBox.Visibility = Visibility.Visible;
            conditionsTextBox.Visibility = Visibility.Visible;
            goButton.Visibility = Visibility.Visible;
        }

        private void conditionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            conditionsTextBox.Clear();
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            contractsNumTextBox.Text = "Number of contracts: ";
            string cond = conditionsComboBox.SelectedItem.ToString();
            this.contractsNumTextBox.Visibility = Visibility.Visible;

            switch (cond)
            {
                case "MotherID":
                    this.list.ItemsSource = mybl.SelectedContracts(c => c.MotherID == conditionsTextBox.Text);
                    this.contractsNumTextBox.Text += Convert.ToString(mybl.NumOfSelectedContracts(c => c.MotherID == conditionsTextBox.Text));
                    break;
                case "NannyID":
                    this.list.ItemsSource = mybl.SelectedContracts(c => c.NannyID == conditionsTextBox.Text);
                    this.contractsNumTextBox.Text += Convert.ToString(mybl.NumOfSelectedContracts(c => c.NannyID == conditionsTextBox.Text));
                    break;
                case "ChildID":
                    this.list.ItemsSource = mybl.SelectedContracts(c => c.ChildID == conditionsTextBox.Text);
                    this.contractsNumTextBox.Text += Convert.ToString(mybl.NumOfSelectedContracts(c => c.ChildID == conditionsTextBox.Text));
                    break;
                case "TotalPay":
                    this.list.ItemsSource = mybl.SelectedContracts(c => c.TotalPay <= float.Parse(conditionsTextBox.Text));
                    this.contractsNumTextBox.Text += Convert.ToString(mybl.NumOfSelectedContracts(c => c.TotalPay <= float.Parse(conditionsTextBox.Text)));
                    break;
                case "StartEmployment":
                    this.list.ItemsSource = mybl.SelectedContracts(c => c.StartEmployment == Convert.ToDateTime(conditionsTextBox.Text));
                    this.contractsNumTextBox.Text += Convert.ToString(mybl.NumOfSelectedContracts(c => c.StartEmployment == Convert.ToDateTime(conditionsTextBox.Text)));
                    break;
                case "EndEmployment":
                    this.list.ItemsSource = mybl.SelectedContracts(c => c.EndEmployment == Convert.ToDateTime(conditionsTextBox.Text));
                    this.contractsNumTextBox.Text += Convert.ToString(mybl.NumOfSelectedContracts(c => c.EndEmployment == Convert.ToDateTime(conditionsTextBox.Text)));
                    break;
            }
        }
        List<BE.Mother> mothersList;
        string id;
        private void Selectedmothers_Click(object sender, RoutedEventArgs e)//Allows finding the mothers group that close to a particular mother
        {
            id = motherIDTextBox.Text;
            Mother specificMother = mybl.GetMothersList().ToList().Find(m => m.ID == id);
            if (specificMother == null)
            {
                MessageBox.Show("mother's id not exist");
                motherIDTextBox.Clear();
            }
            else
            {
                BackgroundWorker work = null;
                work = new BackgroundWorker();
                work.DoWork += Work_DoWork;
                work.RunWorkerCompleted += Work_RunWorkerCompleted;
                work.RunWorkerAsync();
            }
        }

        private void Work_DoWork(object sender, DoWorkEventArgs e)
        {

            mothersList = mybl.SelectedMothers(id);
        }

        private void Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mothersList.Count != 0)
            {
                this.list.ItemsSource = mothersList;
            }
            else MessageBox.Show("there is no mothers next to you");
        }

    }

}


