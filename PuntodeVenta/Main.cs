using PuntodeVenta.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var artists = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name);
                }
            }

            // Adicionar 

            using (var context = new AppDbContext())
            {
                context.Artists.Add(
                    new Artist
                    {
                        Name = "Anberlin",
                        Albums =
                        {
                        new Album { Title = "Cities" },
                        new Album { Title = "New Surrender" }
                        }
                    });
                context.SaveChanges();
            }

           // We can also update and delete existing data like this.

            using (var context = new AppDbContext())
            {
                var police = context.Artists.Single(a => a.Name == "The Police");
                police.Name = "Police, The";

                var avril = context.Artists.Single(a => a.Name == "Avril Lavigne");
                context.Artists.Remove(avril);

                context.SaveChanges();
            }
        }
    }
}
