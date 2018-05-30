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
    /// Interaction logic for UpdateSchedule.xaml
    /// </summary>
    public partial class UpdateSchedule : Window
    {
        private Dictionary<DayOfWeek, KeyValuePair<int, int>> mystuff;

        public Dictionary<DayOfWeek, KeyValuePair<int, int>> MyDictionary
        {
            get { return mystuff; }
        }
        public UpdateSchedule()
        {
            InitializeComponent();
            mystuff = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mystuff[DayOfWeek.Sunday] = new KeyValuePair<int, int>(Int32.Parse(startSunday.Text), Int32.Parse(endSunday.Text));
            mystuff[DayOfWeek.Monday] = new KeyValuePair<int, int>(Int32.Parse(startMonday.Text), Int32.Parse(endMonday.Text));
            mystuff[DayOfWeek.Tuesday] = new KeyValuePair<int, int>(Int32.Parse(startTuesday.Text), Int32.Parse(endTuesday.Text));
            mystuff[DayOfWeek.Wednesday] = new KeyValuePair<int, int>(Int32.Parse(startWednesday.Text), Int32.Parse(endWednesday.Text));
            mystuff[DayOfWeek.Thursday] = new KeyValuePair<int, int>(Int32.Parse(startThursday.Text), Int32.Parse(endThursday.Text));
            this.DialogResult = true;
            this.Close();
        }

        public bool checkHours(int value)
        {
            return ((value / 100) > 25 || (value % 100) > 59);
        }

        private void startSunday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((startSunday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(startSunday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    startSunday.Clear();
                }
            }

        }

        private void endSunday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((endSunday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(endSunday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    endSunday.Clear();
                }
            }
        }

        private void startMonday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((startMonday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(startMonday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    startMonday.Clear();
                }
            }
        }

        private void endMonday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((endMonday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(endMonday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    endMonday.Clear();
                }
            }
        }

        private void startTuesday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((startTuesday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(startTuesday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    startTuesday.Clear();
                }
            }
        }

        private void endTuesday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((endTuesday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(endTuesday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    endTuesday.Clear();
                }
            }
        }

        private void startWednesday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((startWednesday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(startWednesday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    startWednesday.Clear();
                }
            }
        }

        private void endWednesday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((endWednesday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(endWednesday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    endWednesday.Clear();
                }
            }
        }

        private void startThursday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((startThursday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(startThursday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    startThursday.Clear();
                }
            }
        }

        private void endThursday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((endThursday.Text).Length == 4)
            {
                if (checkHours(Int32.Parse(endThursday.Text)))
                {
                    MessageBox.Show("Hours must be legal!");
                    endThursday.Clear();
                }
            }
        }
    }
}
