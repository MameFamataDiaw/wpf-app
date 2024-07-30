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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using WPFModernVerticalMenu.Model;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Interaction logic for ModifierCategorie.xaml
    /// </summary>
    public partial class ModifierCategorie : Window
    {
       // private bdVenteEntities db;
        private Categorie categorie;
        public ModifierCategorie(Categorie categorie)
        {
            InitializeComponent();
            //db = new bdVenteEntities();
            this.categorie = categorie;
            this.DataContext = categorie;
        }

        private void saveBtnModifier_Click(object sender, RoutedEventArgs e)
        {
            // Valide et sauvegarde les modifications
            if (!string.IsNullOrEmpty(txtCodeCategorie.Text) || !string.IsNullOrEmpty(txtLibelleCategorie.Text))
            {
                categorie.CodeCategorie = txtCodeCategorie.Text;
                categorie.LibelleCategorie = txtLibelleCategorie.Text;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires.");
            }
        }
    }
}
