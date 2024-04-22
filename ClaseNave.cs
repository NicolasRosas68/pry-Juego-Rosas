using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_Juego_Rosas
{
    internal class ClaseNave
    {
        //declaracion de variables y listas

        public int vida;
        public string nombre;
        int puntosDeDaños;
        public PictureBox imgNave;
        public List<Proyectil> Proyectiles { get; set; } = new List<Proyectil>();

        //funcion crear jugador
        public void Crearjuegador()
        {
            vida = 100;
            nombre = "Jugador1";
            puntosDeDaños = 1;
            imgNave = new PictureBox();
            imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNave.ImageLocation = "https://i.gifer.com/origin/5a/5aa3c0ec7271a798f94423e19d94f056_w200.gif";
        }
        //funcion disparar
        public void Disparar(PictureBox l)
        {
            Proyectil proyectil = new Proyectil();
            proyectil.Imagen.Location = new Point(imgNave.Location.X + imgNave.Width / 2, imgNave.Location.Y); // Posición inicial del proyectil (centrado en la nave jugador)
            l.Controls.Add(proyectil.Imagen); // Agregar el proyectil al formulario
            Proyectiles.Add(proyectil); // Agregar el proyectil a la lista de proyectiles
        }

    }
}
