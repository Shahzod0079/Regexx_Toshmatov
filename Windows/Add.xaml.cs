using System.Windows;

namespace Regexx_Toshmatov.Windows
{
    public partial class Add : Window
    {
        /// <summary> Паспорт для изменения </summary>
        public Classes.Passport EditPassports;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>


        public Add()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор окна добавления/изменения
        /// </summary>
        /// <param name="EditPassports">Паспорт для изменения</param>
        public Add(Classes.Passport EditPassports) : this()
        {

            if (EditPassports != null)
            {

                txtName.Text = EditPassports.Name;

                txtFirstName.Text = EditPassports.FirstName;

                txtLastName.Text = EditPassports.LastName;

                txtIssued.Text = EditPassports.Issued;
                txtDateOfIssued.Text = EditPassports.DateOfIssued;
                txtDepartmentCode.Text = EditPassports.DepartmentCode;
                txtSeriesAndNumber.Text = EditPassports.SeriesAndNumber;
                txtDateOfBirth.Text = EditPassports.DateOfBirth;
                txtPlaceOfBirth.Text = EditPassports.PlaceOfBirth;

                this.EditPassports = EditPassports;
                BtnAdd.Content = "Изменить";
            }
        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", txtName.Text))
            {

                MessageBox.Show("Не правильно указано имя пользователя");
                return;
            }


            if (string.IsNullOrEmpty(txtFirstName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", txtFirstName.Text))
            {

                MessageBox.Show("Не правильно указано фамилия пользователя");
                return;
            }

 
            if (string.IsNullOrEmpty(txtLastName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", txtLastName.Text))
            {

                MessageBox.Show("Не правильно указано отчество пользователя");
                return;
            }


            if (EditPassports == null)
            {

                EditPassports = new Classes.Passport();

                MainWindow.init.Passports.Add(EditPassports);

            }


            EditPassports.Name = txtName.Text;

            EditPassports.FirstName = txtFirstName.Text;
            EditPassports.LastName = txtLastName.Text;
            EditPassports.Issued = txtIssued.Text;
            EditPassports.DateOfIssued = txtDateOfIssued.Text;
            EditPassports.DepartmentCode = txtDepartmentCode.Text;
            EditPassports.SeriesAndNumber = txtSeriesAndNumber.Text;
            EditPassports.DateOfBirth = txtDateOfBirth.Text;
            EditPassports.PlaceOfBirth = txtPlaceOfBirth.Text;

            MainWindow.init.LoadPassport();

            this.Close();
        }
    }
}