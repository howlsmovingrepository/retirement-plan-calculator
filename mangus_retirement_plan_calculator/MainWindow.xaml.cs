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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s308_Homework_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_calc_Click(object sender, RoutedEventArgs e)
        {
          
            //input validation salary
            string strSalary = txt_salary.Text;
            double dSalary;
            bool bSalary;
            bSalary = double.TryParse(strSalary, out dSalary);
            if (bSalary == false)
            {
                MessageBox.Show("Please input a valid number.");
                return;

            }
            if (dSalary < 0)
            {
                MessageBox.Show("Please input a valid number:  non-negative.");
                return;
            }

            //input validation rates
            string strContRate = txt_contRate.Text;
            double dContRate;
            bool bContRate;
            bContRate = double.TryParse(strContRate, out dContRate);
            if (bContRate == false)
            {
                MessageBox.Show("Please input a valid number.");
                return;

            }
            if (dContRate < 0)
            {
                MessageBox.Show("Please input a valid number:  non-negative.");
                return;
            }
            if (dContRate > 1)
            {
                MessageBox.Show("Please input a valid number: decimal between 0 and 1.");
                return;
            }


            string strReturnRate = txt_returnRate.Text;
            double dReturnRate;
            bool bReturnRate;
            bReturnRate = double.TryParse(strReturnRate, out dReturnRate);
            if (bReturnRate == false)
            {
                MessageBox.Show("Please input a valid number.");
                return;

            }
            if (dReturnRate < 0)
            {
                MessageBox.Show("Please input a valid number:  non-negative.");
                return;
            }
            if (dReturnRate > 1)
            {
                MessageBox.Show("Please input a valid number: decimal between 0 and 1.");
                return;
            }

            //input validation age

            string strCurrentAge = txt_currentAge.Text;

            double dCurrentAge;
           
            bool bCurrentAge;
            bCurrentAge = double.TryParse(strCurrentAge, out dCurrentAge);
            if (bCurrentAge == false)
            {
                MessageBox.Show("Please input a valid number.");
                return;

            }
            if ( dCurrentAge > 120)
            {
                MessageBox.Show("Please input a valid number:  less than 120.");
                return;
            }
            if (dCurrentAge < 1)
            {
                MessageBox.Show("Please input a valid number:  greater than 1.");
                return;
            }


            string strRetiredAge = txt_retiredAge.Text;
            double dRetiredAge;
            bool bRetiredAge;
            bRetiredAge = double.TryParse(strRetiredAge, out dRetiredAge);
            if (bRetiredAge == false)
            {
                MessageBox.Show("Please input a valid number.");
                return;

            }
            if (dRetiredAge > 120)
            {
                MessageBox.Show("Please input a valid number:  less than 120.");
                return;
            }
            if (dRetiredAge < 1)
            {
                MessageBox.Show("Please input a valid number:  greater than 1.");
                return;
            }

            if (dCurrentAge > dRetiredAge)
            {
                MessageBox.Show("Please input a valid number: current age cannot be greater than retiring age.");
                return;
            }


            //Loop logic
            double dYear = 2020;
            double dAgeDiff = dRetiredAge - dCurrentAge;
            double dRetirementYear;
            dRetirementYear = dAgeDiff + dYear;
            double dAccumulatedPrincipal = 0;
            double dAnnualContribution = dSalary * dContRate;
            double dStartBalance = 0;
            double dEndBalance = 0;
            double dAccumulatedInterest = 0;

            txt_Output.Text = "Year".PadRight(5, ' ') + "\t" + "Age".PadRight(5, ' ') + "\t" +
                         "Accumulated Principal".PadRight(25, ' ') + "\t" + "Start Balance".PadRight(25, ' ') + "\t"
                          + "Accumulated Interest".PadRight(25, ' ') + "\t" + "End Balance".PadRight(25, ' ') +
                          Environment.NewLine;

            for (dYear = 2020;  dYear <= dRetirementYear; dYear++)
            {
             
                dAccumulatedPrincipal = dAccumulatedPrincipal + dAnnualContribution;
                dStartBalance = dEndBalance + dAnnualContribution;
                dAccumulatedInterest = dAccumulatedInterest + (dStartBalance * dReturnRate);
                dEndBalance = dStartBalance * (1 + dReturnRate);

                
                txt_Output.Text += dYear.ToString().PadRight(5, ' ') + "\t" + dCurrentAge.ToString().PadRight(5, ' ') 
                    + "\t" + dAccumulatedPrincipal.ToString("C2").PadRight(25, ' ') + "\t" + dStartBalance.ToString("C2").PadRight(25, ' ') 
                    + "\t" + dAccumulatedInterest.ToString("C2").PadRight(25, ' ') + "\t" + dEndBalance.ToString("C2").PadRight(25, ' ') + Environment.NewLine;
                dCurrentAge++;

            }

            



        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            //Clear data
            txt_salary.Clear();
            txt_contRate.Clear();
            txt_currentAge.Clear();
            txt_retiredAge.Clear();
            txt_returnRate.Clear();
            txt_Output.Clear();

        }
    }
}
