using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_Juego_Rosas
{
    internal class proyectilenemigo
    {
        //declracion de variables globales y listas 
        public List<PictureBox> Proyectilesenemigos { get; set; } = new List<PictureBox>();
        public PictureBox Imagenes { get; set; }
        public int Velocidad { get; set; } = 10; // Velocidad de movimiento del proyectil

        //crear proyectil
        public PictureBox crearenemigos()
        {
            Imagenes = new PictureBox();
            Imagenes.BackColor = Color.Red; // Color del proyectil
            Imagenes.Size = new Size(5, 10); // Tamaño del proyectil
            return Imagenes;
        }

        //mover el proyectil
        public void MoverProyectilemigo(List<PictureBox> n)
        {

            // Mover el proyectil hacia abajo
            foreach (PictureBox p in n)
            {
                p.Location = new Point(p.Location.X, p.Location.Y + Velocidad);
            }
        }
    }
}
