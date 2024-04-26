namespace pry_Juego_Rosas
{
    using static System.Formats.Asn1.AsnWriter;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //instanciar objetos

        ClaseNave ObjNavejuegador;
        proyectilenemigo disparoenemigo = new proyectilenemigo();
        Enemigos Objenemigos = new Enemigos();
        Proyectil Objproyectil = new Proyectil();
        List<PictureBox> Proyectilesenemigos = new List<PictureBox>();
        List<PictureBox> listaenemigos = new List<PictureBox>();
        Random random = new Random();
        int contador = 0;   
        
        int contadordisparp = 0;
        bool finjuego = false;
        private void Form1_Load(object sender, EventArgs e)
        {

            ObjNavejuegador = new ClaseNave();
            //funcion crear enemigos
            crerarenemigos();
            //inicio nave jugador 
            ObjNavejuegador.Crearjuegador();
            pictureBox1.Controls.Add(ObjNavejuegador.imgNave);
            ObjNavejuegador.imgNave.Location = new Point(900, 800);
            //fondo
            pictureBox1.ImageLocation = "https://static.vecteezy.com/system/resources/previews/004/640/503/large_2x/black-sky-with-stars-space-background-free-photo.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
           

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)// Si se presiona la tecla de flecha derecha
            {
                ObjNavejuegador.imgNave.Location = new Point(ObjNavejuegador.imgNave.Location.X + 35, // Mueve la nave 5 píxeles hacia la derecha
                ObjNavejuegador.imgNave.Location.Y);
            }
            if (e.KeyCode == Keys.Left) // Si se presiona la tecla de flecha izquierda
            {
                ObjNavejuegador.imgNave.Location = new Point(ObjNavejuegador.imgNave.Location.X - 35, // Mueve la nave 5 píxeles hacia la izquierda
                ObjNavejuegador.imgNave.Location.Y);
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ObjNavejuegador.Disparar(pictureBox1);
                timer1.Start();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (finjuego == false)
            {
                disparoenemigo.MoverProyectilemigo(Objenemigos.Proyectilesenemigos);
                Objproyectil.Mover(ObjNavejuegador.Proyectiles);
                foreach (PictureBox enemigos in listaenemigos)
                {
                    enemigos.Location = new Point(enemigos.Location.X, enemigos.Location.Y + 3);
                    if (enemigos.Location.Y > pictureBox1.Size.Height)
                    {
                        enemigos.Location = new Point(enemigos.Location.X, 0);
                    }
                }



                if (contadordisparp == 10)
                {

                    Objenemigos.DisparoEnemigo(listaenemigos, pictureBox1);
                    contadordisparp = 0;
                }
                contadordisparp++;


                timer1.Start();

                colicion();

                if (listaenemigos.Count == 4)
                {
                    crerarenemigos();
                }
                choque();

                disparoaminave();

            }
            else
            {
                // Objenemigos.Proyectilesenemigos.Remove(proyectilEnemigo);
                // mostrar el mensaje de pérdida y reiniciar el juego
                timer1.Stop();
                reiniciojuego();


                pictureBox1.Controls.Remove(ObjNavejuegador.imgNave);


                ObjNavejuegador.imgNave.Location = new Point(900, 800);
                pictureBox1.Controls.Add(ObjNavejuegador.imgNave);

                if (MessageBox.Show("perdiste,queres continuar", "mensaje", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    contador = 0;
                    reiniciojuego();
                    crerarenemigos();
                    timer1.Start();
                }
                else
                {
                    this.Close();
                }
            }

        }
        private void colicion()
        {
            List<PictureBox> enemigosCopia = new List<PictureBox>(listaenemigos);
            
            foreach (PictureBox enemigo in enemigosCopia)
            {
                foreach (Proyectil bala in ObjNavejuegador.Proyectiles)
                {
                    if (bala.Imagen.Bounds.IntersectsWith(enemigo.Bounds))
                    {
                        enemigo.Dispose();
                        listaenemigos.Remove(enemigo);
                        bala.Imagen.Dispose();
                        ObjNavejuegador.Proyectiles.Remove(bala);
                        contador = contador + 10;
                        break;
                    }
                }
            }
            label2.Text = contador.ToString();
        }


        private void choque()
        {
            List<PictureBox> enemigosCopia = new List<PictureBox>(listaenemigos);

            foreach (PictureBox enemigo in enemigosCopia)
            {
                if (ObjNavejuegador.imgNave.Bounds.IntersectsWith(enemigo.Bounds) )
                {
                    timer1.Stop();
                    MessageBox.Show("¡Perdiste!");
                    contador = 0;
                    // Eliminar las naves enemigas
                    foreach (PictureBox enemigoAEliminar in listaenemigos)
                    {

                        enemigoAEliminar.Dispose();
                    }
                    listaenemigos.Clear();

                    // Reiniciar juego
                    for (int i = 0; i < 10; i++)
                    {
                        int x = random.Next(10, 1750);
                        int y = random.Next(10, 200);

                        // Crear nuevas naves enemigas
                        Objenemigos.CrearEnemigo();
                        pictureBox1.Controls.Add(Objenemigos.imgNaveEnemiga);
                        Objenemigos.imgNaveEnemiga.Location = new Point(x, y);
                        listaenemigos.Add(Objenemigos.imgNaveEnemiga);
                    }
                    ObjNavejuegador.imgNave.Location = new Point(900, 800);
                    timer1.Start();
                
                    break;
                }
            }
        }
        private void crerarenemigos()
        {
            int numEnemigos = 10;
            int espacioEntreEnemigos = 175; // Espacio fijo entre cada enemigo
            int xInicial = 100; // Posición inicial en el eje X

            for (int i = 0; i < numEnemigos; i++)
            {
                int x = xInicial + (i * espacioEntreEnemigos);
                int y = random.Next(175, 175); // Genera una posición aleatoria en la parte superior del PictureBox

                // Crear el enemigo
                Objenemigos.CrearEnemigo();
                pictureBox1.Controls.Add(Objenemigos.imgNaveEnemiga);
                Objenemigos.imgNaveEnemiga.Location = new Point(x, y);
                listaenemigos.Add(Objenemigos.imgNaveEnemiga);
            }
        }


        private void disparoaminave()
        {
            List<PictureBox> enemigosCopia = new List<PictureBox>(Objenemigos.Proyectilesenemigos);

            foreach (PictureBox proyectilEnemigo in enemigosCopia)
            {


                if (ObjNavejuegador.imgNave.Bounds.IntersectsWith(proyectilEnemigo.Bounds))
                {

                    finjuego = true;
                }
            }
        }

        public void reiniciojuego()
        {
            foreach (PictureBox enemigos in listaenemigos)
            {
                pictureBox1.Controls.Remove(enemigos);
            }
            foreach (PictureBox balas in Objenemigos.Proyectilesenemigos)
            {
                pictureBox1.Controls.Remove(balas);

            }
            listaenemigos.Clear();
            Objenemigos.Proyectilesenemigos.Clear();
            finjuego = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}