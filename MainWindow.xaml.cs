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

namespace Animales
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Animal> Animales { get; set; }
        public Animal AnimalSeleccionado { get; set; }
        public List<string> Habilidades { get; set; } = new List<string> { "Guau", "Correr", "Saltar", "Nadar", "Volar", "Miau", "Muu", "Cuac" }; // Ejemplo de habilidades

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Importante para el DataBinding

            Animales = new List<Animal>
            {
                new Animal("Perro", "Guau"),
                new Animal("Gato", "Miau"),
                new Animal("Vaca", "Muu"),
                new Animal("Pato", "Cuac")
            };

            AnimalSeleccionado = Animales[0]; // Seleccionar el primer animal por defecto
        }

        private void darOrdenButton_Click(object sender, RoutedEventArgs e)
        {
            string nombreAnimal = nombreTextBox.Text;

            if (!string.IsNullOrEmpty(nombreAnimal))
            {
                string mensaje = $"{nombreAnimal} dice {AnimalSeleccionado.Habla}!";
                ordenTextBlock.Text = mensaje;
            }
            else
            {
                ordenTextBlock.Text = "¡Debes ingresar el nombre del animal!";
            }
        }

        private void habilidadComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AnimalSeleccionado != null)
            {
                AnimalSeleccionado.Habilidad = habilidadComboBox.SelectedItem.ToString();
                habilidadTextBox.Text = AnimalSeleccionado.Habilidad; // Actualizar el TextBox
            }
        }
    }

    public class Animal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string NombreEspecie { get; set; }
        public string Habla { get; set; }
        private string habilidad = " ";
        public string Habilidad
        {
            get => habilidad;
            set
            {
                if (habilidad != value)
                {
                    habilidad = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Habilidad)));
                }
            }
        }

        public Animal(string nombreEspecie, string habla)
        {
            NombreEspecie = nombreEspecie;
            Habla = habla;
        }
    }
}