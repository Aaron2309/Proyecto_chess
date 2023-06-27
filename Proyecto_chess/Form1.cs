using Microsoft.VisualBasic.ApplicationServices;
using System.Media;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Proyecto_chess
{
    public partial class Form1 : Form
    {
        public Button[,] btnG = new Button[8, 8];
        Tablero tablero;
        public System.Drawing.Image? Image { get; set; }
        int xG;
        int yG;
        int xD;
        int yD;
        public Form1()
        {
            InitializeComponent();
            tablero = new Tablero();
            llenarTablero();
            panel2.BackColor = Color.FromArgb(58, 71, 80);
            
        }


        public void llenarTablero()
        {
            int TamañoBtn = panel1.Width / 8;

            panel1.Height = panel1.Width;

            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero.celda[j, i].pieza.simbolo != "0")
                    {
                        btnG[j, i] = new Button();
                        btnG[j, i].Height = TamañoBtn;
                        btnG[j, i].Width = TamañoBtn;
                        panel1.Controls.Add(btnG[j, i]);
                        btnG[j, i].Location = new Point(i * TamañoBtn, j * TamañoBtn);
                        btnG[j, i].MouseHover += Prueba2;
                        btnG[j, i].MouseClick += Accion_Presionar;
                        btnG[j, i].BackColor = Color.LightGreen;
                        btnG[j, i].Tag = new Point(i, j);
                        btnG[j, i].Image = Image.FromFile(tablero.celda[j, i].pieza.imagen);
                        btnG[j, i].BackColor = Color.FromArgb(250, 234, 177);
                        btnG[j, i].FlatStyle = FlatStyle.Flat;
                        btnG[j, i].FlatAppearance.BorderColor = Color.Black;
                    }
                    else
                    {
                        btnG[j, i] = new Button();
                        btnG[j, i].Height = TamañoBtn;
                        btnG[j, i].Width = TamañoBtn;
                        panel1.Controls.Add(btnG[j, i]);
                        btnG[j, i].Location = new Point(i * TamañoBtn, j * TamañoBtn);
                        btnG[j, i].MouseHover += Prueba2;
                        btnG[j, i].MouseClick += Accion_Presionar;
                        btnG[j, i].Tag = new Point(i, j);
                        btnG[j, i].FlatStyle = FlatStyle.Flat;
                        btnG[j, i].BackColor = Color.FromArgb(229, 186, 115);
                    }

                }
            }
        }

        private void Prueba2(object? sender, EventArgs e)
        {
            tablero.actualizarTablero();
            ActualizarBootones();

            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            xG = location.X;
            yG = location.Y;

            tablero.MovimientoDisponibles(yG, xG);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero.celda[j, i].pieza.simbolo.Equals("X"))
                    {
                        btnG[j, i].BackColor = Color.FromArgb(248, 157, 19);
                    }

                    if (tablero.celda[j, i].pieza.capturada == true)
                    {
                        btnG[j, i].BackColor = Color.Red;
                    }
                }
            }

        }

        private void Prueba(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Right click");
            }
            else if(e.Button == MouseButtons.Left)
            {
                tablero.actualizarTablero();
                Button clickedButton = (Button)sender;
                Point location = (Point)clickedButton.Tag;

                xG = location.X;
                yG = location.Y;

                tablero.MovimientoDisponibles(yG, xG);

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (tablero.celda[j, i].pieza.simbolo.Equals("X"))
                        {
                            btnG[j, i].BackColor = Color.Black;
                        }
                        else if (tablero.celda[j, i].pieza.simbolo.Equals("0"))
                        {
                            btnG[j, i].BackColor = Color.SlateGray;
                        }

                        if (tablero.celda[j, i].pieza.capturada == true)
                        {
                            btnG[j, i].BackColor = Color.Black;
                        }
                    }
                }
            }
        }

        public void ActualizarBootones()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero.celda[j,i].pieza.simbolo != "0" && tablero.celda[j, i].pieza.simbolo != "X")
                    {
                        btnG[j, i].Image = Image.FromFile(tablero.celda[j, i].pieza.imagen);
                        btnG[j, i].BackColor = Color.FromArgb(250, 234, 177);
                    }
                    else
                    {
                        btnG[j, i].BackColor = Color.FromArgb(229, 186, 115);
                        btnG[j, i].Image = null;
                    }

                    if (btnG[j,i].BackColor == Color.Red)
                    {
                        btnG[j, i].BackColor = Color.FromArgb(229, 186, 115);
                    }
                }
            }
        }

        private void Accion_DobleClick(object? sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            xD = location.X;
            yD = location.Y;

            tablero.movimiento(yG, xG, yD, xD);

            if (tablero.celda[yD, xD].pieza.simbolo != "X" && tablero.celda[yD, xD].pieza.simbolo != "0")
            {
                btnG[yD, xD].BackColor = Color.Yellow;
                btnG[yD,xD].Image = Image.FromFile("C:\\Users\\abren\\source\\repos\\ProyectoFinal\\ProyectoFinal\\peon1.jpg");
            }

        }

        public void Accion_Presionar(object? sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            xD = location.X;
            yD = location.Y;

            tablero.movimiento(yG, xG, yD, xD);



            tablero.actualizarTablero();
            ActualizarBootones();
            
            if(tablero.Lista_Capturada1.Count != 0)
            {
                listBox1.Items.Clear();
                foreach(string i in tablero.Lista_Capturada1)
                {
                    listBox1.Items.Add(i);
                    
                }
            }

            if (tablero.Lista_Capturada2.Count != 0)
            {
                listBox2.Items.Clear();
                foreach (string i in tablero.Lista_Capturada2)
                {
                    listBox2.Items.Add(i);

                }
            }


            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach(string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }


            CambioTurno();
            if (tablero.AperItaliana == true)
            {
                button1_Click(sender, e);
            }else if(tablero.DefSiciliana== true)
            {
                button2_Click(sender, e);
            }else if(tablero.DefFrancesa == true)
            {
                button3_Click(sender, e);
            }else if(tablero.AperRuyLopez == true)
            {
                button4_Click(sender, e);
            }else if(tablero.DefEslava == true)
            {
                button5_Click(sender, e);
            }

            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }


        }

        private void CambioTurno()
        {
            if(tablero.turno == true)
            {
                label1.Text = "Turno Equipo Mario";

            }
            else
            {
                label1.Text = "Turno Equipo Bowser";
            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablero.AperturaItaliana();
            ActualizarBootones();
            CambioTurno();

            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablero.Defensa_Siciliana();
            ActualizarBootones();
            CambioTurno();

            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablero.Defensa_Francesa();
            ActualizarBootones();
            CambioTurno();

            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tablero.Ruy_Lopez();
            ActualizarBootones();
            CambioTurno();

            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tablero.Defensa_Eslava();
            ActualizarBootones();
            CambioTurno();

            listBox3.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos1)
            {
                listBox3.Items.Add(j);
            }

            listBox4.Items.Clear();
            foreach (string j in tablero.Lista_Movimientos2)
            {
                listBox4.Items.Add(j);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tablero.jaque());
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(txt1.Text);
            int b = Int32.Parse(txt2.Text);
            int c = Int32.Parse(txt3.Text);
            int d = Int32.Parse(txt4.Text);

            tablero.MovimientoDisponibles(a,b);

            tablero.movimiento(a,b,c,d);

            tablero.ListaMovimientos(a.ToString(), b, c.ToString(), d);

            tablero.actualizarTablero();
            ActualizarBootones();


            if (tablero.Lista_Capturada1.Count != 0)
            {
                listBox1.Items.Clear();
                foreach (string i in tablero.Lista_Capturada1)
                {
                    listBox1.Items.Add(i);

                }
            }

            if (tablero.Lista_Capturada2.Count != 0)
            {
                listBox2.Items.Clear();
                foreach (string i in tablero.Lista_Capturada2)
                {
                    listBox2.Items.Add(i);

                }
            }
        }
    }
}