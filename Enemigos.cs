using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_Juego_Rosas
{
    internal class Enemigos
    {

        //declaracion de variables  y lista
        public int vida;
        public string nombre;
        int puntosDeDaños;
        public PictureBox imgNaveEnemiga;
        Random Random = new Random();
        proyectilenemigo pe = new proyectilenemigo();
        public List<PictureBox> Proyectilesenemigos { get; set; } = new List<PictureBox>();
        //funcion crear enemigos
        public void CrearEnemigo()
        {

            vida = 30;
            nombre = "Enemigo1";
            puntosDeDaños = 1;
            imgNaveEnemiga = new PictureBox();
            imgNaveEnemiga.SizeMode = PictureBoxSizeMode.StretchImage;

            //random foto de respawn //cambiar url a web 

            int imagen = Random.Next(1, 4);
            if (imagen == 1)
            {
                imgNaveEnemiga.ImageLocation = "https://i.gifer.com/origin/cf/cf75a94995efd5a532afe5b4f08f6007_w200.gif";
            }
            else if (imagen == 2)
            {
                imgNaveEnemiga.ImageLocation = "https://i.gifer.com/f3R.gif";
            }
            else
            {
                imgNaveEnemiga.ImageLocation = "https://i.gifer.com/origin/dc/dcf6c5064d5dda12912e94af2ac4b8f4_w200.gif";
            }
        }

        // disparo enemigo 
        public void DisparoEnemigo(List<PictureBox> dispararenemigos, PictureBox l)
        {
            foreach (PictureBox enemigo in dispararenemigos)
            {
                PictureBox proyectil = pe.crearenemigos();
                proyectil.Location = new Point(enemigo.Location.X + enemigo.Width / 2, enemigo.Location.Y); // Posición inicial del proyectil (centrado en la nave jugador)
                l.Controls.Add(proyectil); // Agregar el proyectil al formulario
                Proyectilesenemigos.Add(proyectil); // Agregar el proyectil a la lista de proyectiles

            }

        }

    }
}
