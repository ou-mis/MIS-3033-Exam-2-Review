/**
 * Using the Employees.txt file, read in the file and show a list of all the employees that make over 70,000 in salary.  
 * 
 * In a separate list, display all of the employees that have an email address at dropbox.com.  
 * 
 * When reading in the file, save the values in a class that has constructors as well as an overridden ToString method.  
 * 
 * Output the average salary for all of the employees as well.  
 * 
 * @author Adam ackerman
 */

using System;
using System.Collections.Generic;
using System.IO;
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

namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Employee> emps = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //string downloadsDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads";
            dlg.InitialDirectory = @"C:\Users\Adam\Downloads\";
            var result = dlg.ShowDialog();

            if(result == true)
            {
                txtFilePath.Text = dlg.FileName;
            }

        }

        private void BtnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists(txtFilePath.Text) == true)
            {
                var lines = File.ReadAllLines(txtFilePath.Text);

                int count = 0;

                foreach (var line in lines)
                {
                    if(count != 0)
                    {
                        var linePiece = line.Split('|');
                        string firstName, lastName, email, gender;
                        double salary;

                        firstName = linePiece[0];
                        lastName = linePiece[1]  ;
                        email =    linePiece[2]  ;
                        gender =   linePiece[3]  ;
                        salary =   Convert.ToDouble(linePiece[4].Replace("$", ""))  ;

                        Employee emp = new Employee(firstName, lastName, email, gender, salary);
                        emps.Add(emp);
                    }

                    count++;
                }

                //EmployeesWithGreaterThanSeventyK();
                //EmployeesWithEmailFromDropbox();
                PopulateListBoxes();
            }
        }

        private void PopulateListBoxes()
        {
            foreach (var emp in emps)
            {
                if (emp.MakesOverCertainAmount(70000))
                {
                    lstSalaries.Items.Add(emp);
                }

                if (emp.HasEmailFromDomain("@dropbox.com"))
                {
                    lstEmails.Items.Add(emp);
                }
            }
        }

        private void EmployeesWithEmailFromDropbox()
        {
            foreach (var emp in emps)
            {
                if (emp.Email.Contains("@dropbox.com"))
                {
                    lstEmails.Items.Add(emp);
                }
            }
        }

        private void EmployeesWithGreaterThanSeventyK()
        {
            foreach (var emp in emps)
            {
                if (emp.Salary > 70000)
                {
                    lstSalaries.Items.Add(emp);
                }
            }
        }
    }
}
