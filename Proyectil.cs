using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_Juego_Rosas
{
    internal class Proyectil
    {
        // declaracion de variables globales y listas
        public List<Proyectil> Proyectiles { get; set; } = new List<Proyectil>();
        public PictureBox Imagen { get; set; }
        public int Velocidad { get; set; } = 20; // Velocidad de movimiento del proyectil

        //crear proyectil
        public Proyectil()
        {
            Imagen = new PictureBox();
            Imagen.BackColor = Color.Yellow; // Color del proyectil
            Imagen.Size = new Size(5, 10); // Tamaño del proyectil
        }

        
        public void Mover(List<Proyectil> n)
        {
            // Mover el proyectil hacia arriba 

            foreach (Proyectil p in n)
            {
                p.Imagen.Location = new Point(p.Imagen.Location.X, p.Imagen.Location.Y - Velocidad);
            }
        }
    }
}
