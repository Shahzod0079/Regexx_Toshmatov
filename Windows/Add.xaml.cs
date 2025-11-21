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
            if (string.IsNullOrEmpty(txtIssued.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я0-9\\s\\-,.]{5,200}$", txtIssued.Text))
            {
                MessageBox.Show("Не правильно указано кем выдан паспорт");
                return;
            }

            if (string.IsNullOrEmpty(txtDateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^(0[1-9]|[12][0-9]|3[01])\\.(0[1-9]|1[0-2])\\.(19|20)\\d{2}$", txtDateOfIssued.Text))
            {
                MessageBox.Show("Не правильно указана дата выдачи. Формат: ДД.ММ.ГГГГ ");
                return;
            }

            if (string.IsNullOrEmpty(txtDepartmentCode.Text) || !Classes.Common.CheckRegex.Match("^\\d{3}-\\d{3}$", txtDepartmentCode.Text))
            {
                MessageBox.Show("Не правильно указан код подразделения. Формат: XXX-XXX");
                return;
            }

            if (string.IsNullOrEmpty(txtSeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match("^\\d{4}\\s\\d{6}$", txtSeriesAndNumber.Text))
            {
                MessageBox.Show("Не правильно указаны серия и номер паспорта. Формат: XXXX XXXXXX )");
                return;
            }

            if (string.IsNullOrEmpty(txtDateOfBirth.Text) || !Classes.Common.CheckRegex.Match("^(0[1-9]|[12][0-9]|3[01])\\.(0[1-9]|1[0-2])\\.(19|20)\\d{2}$", txtDateOfBirth.Text))
            {
                MessageBox.Show("Не правильно указана дата рождения. Формат: ДД.ММ.ГГГГ ");
                return;
            }

            if (string.IsNullOrEmpty(txtPlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я0-9\\s\\-,.]{5,200}$", txtPlaceOfBirth.Text))
            {
                MessageBox.Show("Не правильно указано место рождения. ");
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