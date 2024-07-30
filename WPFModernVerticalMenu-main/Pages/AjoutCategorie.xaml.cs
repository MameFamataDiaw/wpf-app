﻿using System;
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
using WPFModernVerticalMenu.Model;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Interaction logic for AjoutCategorie.xaml
    /// </summary>
    public partial class AjoutCategorie : Window
    {
        private bdVenteEntities db;
        public AjoutCategorie()
        {
            InitializeComponent();
            db = new bdVenteEntities();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string code = txtCodeCategorie.Text;
            string libelle = txtlibelleCategorie.Text;
            if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(libelle))
            {
                // Ajoute la nouvelle catégorie à la base de données
                Categorie categorie = new Categorie { 
                    CodeCategorie = code ,
                    LibelleCategorie = libelle
                };
                
                db.Categories.Add(categorie);
                db.SaveChanges();

                // Ferme la fenêtre de dialogue et renvoie un résultat positif
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