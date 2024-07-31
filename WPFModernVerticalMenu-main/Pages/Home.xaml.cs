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
using WPFModernVerticalMenu.Model;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private bdVenteEntities db;

        /// <summary>
        /// INITIALISATION DE LA PAGE HOME
        /// </summary>
        public Home()
        {
            InitializeComponent();
            db = new bdVenteEntities();
            LoadCategories();
        }

        /// <summary>
        /// METHODE CHARGEMENT DE LA LISTE DES CATEGORIES
        /// </summary>
        private void LoadCategories()
        {
            // Récupère les catégories à partir de la base de données et les lie au DataGrid
            dgCategorie.ItemsSource = db.Categories.ToList();
        }


        /// <summary>
        /// ACTION DE REDIRECTION ERS LA PAGE D'AJOUT DE CATEGORIES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAjouter_Cick(object sender, RoutedEventArgs e)
        {
            // Ouvre une nouvelle fenêtre ou affiche un formulaire pour ajouter une nouvelle catégorie
            AjoutCategorie add = new AjoutCategorie();
            if (add.ShowDialog() == true)
            {
                // Si une nouvelle catégorie a été ajoutée, recharge les données
                LoadCategories();
            }
        }

        /// <summary>
        /// ACTION DE REDIRECTION ERS LA PAGE DE MODIFICATION DE CATEGORIES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModifier_Cick(object sender, RoutedEventArgs e)
        {
            // Récupère l'ID de la catégorie à partir du bouton Tag
            Button button = sender as Button;
            int idCategorie = (int)button.Tag;

            // Trouve la catégorie dans la base de données
            Categorie categorie = db.Categories.Find(idCategorie);
            if (categorie != null)
            {
                // Ouvre une fenêtre pour modifier la catégorie
                ModifierCategorie modif = new ModifierCategorie(categorie);
                if (modif.ShowDialog() == true)
                {
                    // Si la catégorie a été modifiée, sauvegarde les modifications et recharge les données
                    db.SaveChanges();
                    LoadCategories();
                }
            }
        }

        /// <summary>
        /// ACTION DE SUPPRESSION D'UNE CATEGORIE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            // Récupère l'ID de la catégorie à partir du bouton Tag
            Button button = sender as Button;
            int idCategorie = (int)button.Tag;

            // Trouve la catégorie dans la base de données
            Categorie categorie = db.Categories.Find(idCategorie);
            if (categorie != null)
            {
                MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer la catégorie {categorie.LibelleCategorie} ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Supprime la catégorie et sauvegarde les modifications
                    db.Categories.Remove(categorie);
                    db.SaveChanges();
                    // Recharge les données
                    LoadCategories();
                }
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
