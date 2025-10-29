using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace PR77777
{
    public partial class MainWindow : Window
    {
        public Doctor CurrentDoctor { get; set; } = new Doctor();
        public Patient CurrentPatient { get; set; } = new Patient();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            CountDifUsers();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            CurrentDoctor.Id = CurrentDoctor.DoctorID();
            CurrentDoctor.SaveToFile();
            MessageBox.Show($"Врач ID: {CurrentDoctor.Id}");
            CountDifUsers();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var patient = CurrentPatient.LoadFromFIle(Convert.ToInt32(Search.Text));

            if (patient != null)
            {
                CurrentPatient.Id = patient.Id;
                CurrentPatient.Name = patient.Name;
                CurrentPatient.LastName = patient.LastName;
                CurrentPatient.MiddleName = patient.MiddleName;
                CurrentPatient.Birthday = patient.Birthday;
                CurrentPatient.LastAppointment = patient.LastAppointment;
                CurrentPatient.LastDoctor = patient.LastDoctor;
                CurrentPatient.Diagnosis = patient.Diagnosis;
                CurrentPatient.Recomendations = patient.Recomendations;
                MessageBox.Show($"Пациент {CurrentPatient.FullName} найден");
            }
            CountDifUsers();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            CurrentPatient.Id = CurrentPatient.PatientID();
            CurrentPatient.SaveToFile();
            MessageBox.Show($"Пациент ID: {CurrentPatient.Id}");
            CountDifUsers();
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            CurrentPatient.LastDoctor = CurrentDoctor.Id;
            CurrentPatient.LastAppointment = DateTime.Now;
            CurrentPatient.SaveToFile();
            MessageBox.Show("Данные о приёме записаны!");
            CountDifUsers();
        }

        private void CountDifUsers()
        {
            DocCount.Content = Directory.GetFiles(Directory.GetCurrentDirectory())
                .Count(file => Path.GetFileName(file).StartsWith("D_"));

            PatientCount.Content = Directory.GetFiles(Directory.GetCurrentDirectory())
                .Count(file => Path.GetFileName(file).StartsWith("P_"));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            CurrentPatient.SaveToFile();
            MessageBox.Show("Информация о пациенте обновлена");
            CountDifUsers();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var load = CurrentDoctor.LoadFromFIle(Convert.ToInt32(InputID.Text));

            if (load != null)
            {
                CurrentDoctor.Id = load.Id;
                CurrentDoctor.Name = load.Name;
                CurrentDoctor.LastName = load.LastName;
                CurrentDoctor.MiddleName = load.MiddleName;
                CurrentDoctor.Specialisation = load.Specialisation;
                CurrentDoctor.Password = load.Password;
                MessageBox.Show($"Здравствуйте, {CurrentDoctor.FullName}");
            }
            CountDifUsers();
        }
    }
}