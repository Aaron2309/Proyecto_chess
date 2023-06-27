using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_chess
{
    internal class Tablero
    {
        public int tamaño;
        public Celda[,] celda;
        public bool turno = true;
        public int numero_Turno = 1;
        public bool DefSiciliana = false;
        public bool DefEslava = false;
        public bool AperItaliana = false;
        public bool AperRuyLopez = false;
        public bool DefFrancesa = false;
        public bool JM = false;
        public List<string> Lista_Capturada1 = new List<string>();
        public List<string> Lista_Capturada2 = new List<string>();
        public List<string> Lista_Movimientos1 = new List<string>();
        public List<string> Lista_Movimientos2 = new List<string>();

        public Tablero()
        {
            tamaño = 8;

            celda = new Celda[tamaño, tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    if (i == 6 || i == 1)
                    {
                        Pieza pieza = new Pieza("Peon");
                        celda[i, j] = new Celda(i, j, pieza);

                        if (i == 1)
                        {
                            celda[i, j].pieza.equipo = "2";
                            celda[i, j].pieza.imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\GoombaPeon.png";
                        }

                    }
                    else if (i == 7 && j == 0 || i == 7 && j == 7 || i == 0 && j == 0 || i == 0 && j == 7)
                    {

                        Pieza pieza = new Pieza("Torre");
                        celda[i, j] = new Celda(i, j, pieza);

                        if (i == 0 && j == 0 || i == 0 && j == 7)
                        {
                            celda[i, j].pieza.equipo = "2";
                            celda[i, j].pieza.imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\BooTorre.png";
                        }

                    }
                    else if (i == 7 && j == 1 || i == 7 && j == 6 || i == 0 && j == 1 || i == 0 && j == 6)
                    {
                        Pieza pieza = new Pieza("Caballo");
                        celda[i, j] = new Celda(i, j, pieza);

                        if (i == 0 && j == 1 || i == 0 && j == 6)
                        {
                            celda[i, j].pieza.equipo = "2";
                            celda[i, j].pieza.imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\KoopaCaballo.png";
                        }

                    }
                    else if (i == 7 && j == 2 || i == 7 && j == 5 || i == 0 && j == 2 || i == 0 && j == 5)
                    {
                        Pieza pieza = new Pieza("Alfil");
                        celda[i, j] = new Celda(i, j, pieza);

                        if (i == 0 && j == 2 || i == 0 && j == 5)
                        {
                            celda[i, j].pieza.equipo = "2";
                            celda[i, j].pieza.imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\MartilloAlfil.png";
                        }

                    }
                    else if (i == 7 && j == 3 || i == 0 && j == 3)
                    {
                        Pieza pieza = new Pieza("Rey");
                        celda[i, j] = new Celda(i, j, pieza);

                        if (i == 0 && j == 3)
                        {
                            celda[i, j].pieza.equipo = "2";
                            celda[i, j].pieza.imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\BowserRey.png";
                        }

                    }
                    else if (i == 7 && j == 4 || i == 0 && j == 4)
                    {
                        Pieza pieza = new Pieza("Reina");
                        celda[i, j] = new Celda(i, j, pieza);

                        if (i == 0 && j == 4)
                        {
                            celda[i, j].pieza.equipo = "2";
                            celda[i, j].pieza.imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\DaisyReina.png";
                        }
                    }
                    else
                    {
                        Pieza pieza = new Pieza("0");
                        celda[i, j] = new Celda(i, j, pieza);
                        celda[i, j].pieza.equipo = "0";
                    }
                }
            }

        }

        public void imprimirTablero()
        {
            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    Console.Write(celda[i, j].pieza.simbolo);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


        public void actualizarTablero()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (celda[i, j].pieza.simbolo.Equals("X"))
                    {
                        celda[i, j].pieza.simbolo = "0";
                    }

                    if (celda[i, j].pieza.capturada == true)
                    {
                        celda[i, j].pieza.capturada = false;
                    }
                }
            }
        }

        public void MovimientoRey(int x, int y)
        {
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    Console.WriteLine(i + "," + j);
                    if (i.Equals(x) && j.Equals(y))
                    {
                    }
                    else if (i >= 0 && i <= 7 && j >= 0 && j <= 7 && celda[i, j].pieza.simbolo.Equals("0"))
                    {
                        celda[i, j].pieza.simbolo = "X";
                    }
                    else if (i >= 0 && i <= 7 && j >= 0 && j <= 7 && celda[i, j].pieza.simbolo != "0" && celda[i, j].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[i, j].pieza.capturada = true;
                    }
                }
            }
        }
        public void MovimientoPeon(int x, int y)
        {
            int g = y;
            int j = x;
            bool CortarPaso = false;
            switch (celda[x, y].pieza.equipo)
            {
                case "1":
                    j = x;
                    CortarPaso = false;
                    //Movimiento hacia adelante
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0 || i == 1 && celda[x, y].pieza.PrimerMov == true)
                        {
                            j--;
                            if (j >= 0 && celda[j, y].pieza.simbolo == "0" && CortarPaso == false)
                            {

                                celda[j, y].pieza.simbolo = "X";
                            }
                            else if (j >= 0 && celda[j, y].pieza.simbolo != "0")
                            {
                                CortarPaso = true;
                            }
                        }
                    }
                    //Comer en diagonal
                    j = x;
                    j--;
                    g--;
                    if (j >= 0 && g >= 0 && celda[j, g].pieza.simbolo != "0" && celda[j, g].pieza.simbolo != "X" && celda[j, g].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[j, g].pieza.capturada = true;
                    }
                    g = y;
                    g++;
                    if (j >= 0 && g <= 7 && celda[j, g].pieza.simbolo != "0" && celda[j, g].pieza.simbolo != "X" && celda[j, g].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[j, g].pieza.capturada = true;
                    }


                    break;
                case "2":
                    j = x;
                    CortarPaso = false;
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0 || i == 1 && celda[x, y].pieza.PrimerMov == true)
                        {
                            j++;
                            if (j <= 7 && celda[j, y].pieza.simbolo == "0" && CortarPaso == false)
                            {
                                celda[j, y].pieza.simbolo = "X";
                            }
                            else if (j <= 7 && celda[j, y].pieza.simbolo != "0")
                            {
                                CortarPaso = true;
                            }
                        }
                    }
                    //Comer Diagonal
                    j = x;
                    j++;
                    g--;
                    if (j <= 7 && g >= 0 && celda[j, g].pieza.simbolo != "0" && celda[j, g].pieza.simbolo != "X" && celda[j, g].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[j, g].pieza.capturada = true;
                    }
                    g = y;
                    g++;
                    if (j <= 7 && g <= 7 && celda[j, g].pieza.simbolo != "0" && celda[j, g].pieza.simbolo != "X" && celda[j, g].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[j, g].pieza.capturada = true;
                    }
                    break;


            }

        }

        public void MovimientoTorre(int x, int y)
        {
            int derecha = y;
            int arriba = x;
            int abajo = x;
            int izq = y;
            bool CortarPasoderecha = false;
            bool CortarPasoizq = false;
            bool CortarPasoarriba = false;
            bool CortarPasoabajo = false;
            bool cortarCiclo = false;

            for (int i = 0; i <= 8; i++)
            {

                if (derecha + 1 <= 7 && celda[x, derecha + 1].pieza.simbolo.Equals("0") && CortarPasoderecha == false)
                {
                    ++derecha;
                    Console.WriteLine(derecha);
                    celda[x, derecha].pieza.simbolo = "X";

                }
                else if (derecha + 1 <= 7 && celda[x, derecha + 1].pieza.simbolo != "0" && CortarPasoderecha == false && derecha + 1 <= 7 && celda[x, derecha + 1].pieza.equipo != celda[x, y].pieza.equipo)
                {

                    celda[x, derecha + 1].pieza.capturada = true;
                    CortarPasoderecha = true;
                    cortarCiclo = true;

                }

                cortarCiclo = false;

                if (abajo + 1 <= 7 && celda[abajo + 1, y].pieza.simbolo == "0" && CortarPasoabajo == false)
                {
                    ++abajo;
                    celda[abajo, y].pieza.simbolo = "X";

                }
                else if (abajo + 1 <= 7 && celda[abajo + 1, y].pieza.simbolo != "0" && CortarPasoabajo == false && celda[abajo + 1, y].pieza.equipo != celda[x, y].pieza.equipo)
                {
                    celda[++abajo, y].pieza.capturada = true;
                    CortarPasoabajo = true;
                    cortarCiclo = true;

                }
                cortarCiclo = false;

                if (arriba - 1 >= 0 && celda[arriba - 1, y].pieza.simbolo == "0" && CortarPasoarriba == false)
                {
                    --arriba;
                    celda[arriba, y].pieza.simbolo = "X";

                }
                else if (arriba - 1 >= 0 && celda[arriba - 1, y].pieza.simbolo != "0" && CortarPasoarriba == false && celda[arriba - 1, y].pieza.equipo != celda[x, y].pieza.equipo)
                {
                    celda[--arriba, y].pieza.capturada = true;
                    CortarPasoarriba = true;
                    cortarCiclo = true;

                }

                cortarCiclo = false;

                if (izq - 1 >= 0 && celda[x, izq - 1].pieza.simbolo == "0" && CortarPasoizq == false)
                {
                    --izq;
                    celda[x, izq].pieza.simbolo = "X";
                }
                else if (izq - 1 >= 0 && celda[x, izq - 1].pieza.simbolo != "0" && CortarPasoizq == false && celda[x, izq - 1].pieza.equipo != celda[x, y].pieza.equipo)
                {
                    celda[x, izq - 1].pieza.capturada = true;
                    CortarPasoizq = true;
                    cortarCiclo = true;

                }
            }
        }

        public void movimientoCaballo(int x, int y)
        {
            //Equina superior izquierda(1)

            if (x - 2 >= 0 && y - 1 >= 0 && celda[x - 2, y - 1].pieza.simbolo.Equals("0"))
            {
                celda[x - 2, y - 1].pieza.simbolo = "X";

            }
            else if (x - 2 >= 0 && y - 1 >= 0 && celda[x - 2, y - 1].pieza.simbolo != "0" && celda[x - 2, y - 1].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x - 2, y - 1].pieza.capturada = true;
            }

            // Equina superior izquierda(2)

            if (x - 1 >= 0 && y - 2 >= 0 && celda[x - 1, y - 2].pieza.simbolo.Equals("0"))
            {
                celda[x - 1, y - 2].pieza.simbolo = "X";
            }
            else if (x - 1 >= 0 && y - 2 >= 0 && celda[x - 1, y - 2].pieza.simbolo != "0" && celda[x - 1, y - 2].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x - 1, y - 2].pieza.capturada = true;
            }

            //Esquina supereior Derecha(1)
            if (x - 2 >= 0 && y + 1 <= 7 && celda[x - 2, y + 1].pieza.simbolo.Equals("0"))
            {
                celda[x - 2, y + 1].pieza.simbolo = "X";
            }
            else if (x - 2 >= 0 && y + 1 <= 7 && celda[x - 2, y + 1].pieza.simbolo != "0" && celda[x - 2, y + 1].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x - 2, y + 1].pieza.capturada = true;
            }

            //Esquina supereior Derecha(2)
            if (x - 1 >= 0 && y + 2 <= 7 && celda[x - 1, y + 2].pieza.simbolo.Equals("0"))
            {
                celda[x - 1, y + 2].pieza.simbolo = "X";
            }
            else if (x - 1 >= 0 && y + 2 <= 7 && celda[x - 1, y + 2].pieza.simbolo != "0" && celda[x - 1, y + 2].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x - 1, y + 2].pieza.capturada = true;
            }

            //Esquina inferior Derecha(1)
            if (x + 2 <= 7 && y + 1 <= 7 && celda[x + 2, y + 1].pieza.simbolo.Equals("0"))
            {
                celda[x + 2, y + 1].pieza.simbolo = "X";
            }
            else if (x + 2 <= 7 && y + 1 <= 7 && celda[x + 2, y + 1].pieza.simbolo != "0" && celda[x + 2, y + 1].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x + 2, y + 1].pieza.capturada = true;
            }

            //Esquina inferior Derecha(2)
            if (x + 1 <= 7 && y + 2 <= 7 && celda[x + 1, y + 2].pieza.simbolo.Equals("0"))
            {
                celda[x + 1, y + 2].pieza.simbolo = "X";
            }
            else if (x + 1 <= 0 && y + 2 <= 7 && celda[x + 1, y + 2].pieza.simbolo != "0" && celda[x + 1, y + 2].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x + 1, y + 2].pieza.capturada = true;
            }


            //Esquina inferior izquierda(1)
            if (x + 2 <= 7 && y - 1 >= 0 && celda[x + 2, y - 1].pieza.simbolo.Equals("0"))
            {
                celda[x + 2, y - 1].pieza.simbolo = "X";
            }
            else if (x + 2 <= 7 && y - 1 >= 0 && celda[x + 2, y - 1].pieza.simbolo != "0" && celda[x + 2, y - 1].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x + 2, y - 1].pieza.capturada = true;
            }

            //Esquina inferior izquierda(1)
            if (x + 1 <= 7 && y - 2 >= 0 && celda[x + 1, y - 2].pieza.simbolo.Equals("0"))
            {
                celda[x + 1, y - 2].pieza.simbolo = "X";
            }
            else if (x + 1 <= 7 && y - 2 >= 0 && celda[x + 1, y - 2].pieza.simbolo != "0" && celda[x + 1, y - 2].pieza.equipo != celda[x, y].pieza.equipo)
            {
                celda[x + 1, y - 2].pieza.capturada = true;
            }

        }

        public void movimientoAlfil(int x, int y)
        {
            //Esquina superior izquierda
            int a = x;
            int b = y;
            bool CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                a--;
                b--;
                if (a >= 0 && b >= 0 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a >= 0 && b >= 0 && celda[a, b].pieza.simbolo != "0" && CortarPaso == false)
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }

            //Esquina inferior derecha
            a = x;
            b = y;
            CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                ++a;
                ++b;
                if (a <= 7 && b <= 7 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a <= 7 && b <= 7 && celda[a, b].pieza.simbolo != "0" && CortarPaso == false)
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }

            //Esquina inferior izquierda
            a = x;
            b = y;
            CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                ++a;
                --b;
                if (a <= 7 && b >= 0 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a <= 7 && b >= 0 && celda[a, b].pieza.simbolo != "0" && CortarPaso == false)
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }

            //Esquina superior dercha
            a = x;
            b = y;
            CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                --a;
                ++b;
                if (a >= 0 && b <= 7 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a >= 0 && b <= 7 && celda[a, b].pieza.simbolo != "0" && CortarPaso == false)
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }
        }

        public void movimientoReina(int x, int y)
        {
            int derecha = y;
            int arriba = x;
            int abajo = x;
            int izq = y;
            bool CortarPasoderecha = false;
            bool CortarPasoizq = false;
            bool CortarPasoarriba = false;
            bool CortarPasoabajo = false;
            bool cortarCiclo = false;

            for (int i = 0; i <= 8; i++)
            {

                if (derecha + 1 <= 7 && celda[x, derecha + 1].pieza.simbolo.Equals("0") && CortarPasoderecha == false)
                {
                    ++derecha;
                    Console.WriteLine(derecha);
                    celda[x, derecha].pieza.simbolo = "X";

                }
                else if (derecha + 1 <= 7 && celda[x, derecha + 1].pieza.simbolo != "0" && CortarPasoderecha == false && derecha + 1 <= 7 && celda[x, derecha + 1].pieza.equipo != celda[x, y].pieza.equipo)
                {

                    celda[x, derecha + 1].pieza.capturada = true;
                    CortarPasoderecha = true;
                    cortarCiclo = true;

                }

                cortarCiclo = false;

                if (abajo + 1 <= 7 && celda[abajo + 1, y].pieza.simbolo == "0" && CortarPasoabajo == false)
                {
                    ++abajo;
                    celda[abajo, y].pieza.simbolo = "X";

                }
                else if (abajo + 1 <= 7 && celda[abajo + 1, y].pieza.simbolo != "0" && CortarPasoabajo == false && celda[abajo + 1, y].pieza.equipo != celda[x, y].pieza.equipo)
                {
                    celda[++abajo, y].pieza.capturada = true;
                    CortarPasoabajo = true;
                    cortarCiclo = true;

                }
                cortarCiclo = false;

                if (arriba - 1 >= 0 && celda[arriba - 1, y].pieza.simbolo == "0" && CortarPasoarriba == false)
                {
                    --arriba;
                    celda[arriba, y].pieza.simbolo = "X";

                }
                else if (arriba - 1 >= 0 && celda[arriba - 1, y].pieza.simbolo != "0" && CortarPasoarriba == false && celda[arriba - 1, y].pieza.equipo != celda[x, y].pieza.equipo)
                {
                    celda[--arriba, y].pieza.capturada = true;
                    CortarPasoarriba = true;
                    cortarCiclo = true;

                }

                cortarCiclo = false;

                if (izq - 1 >= 0 && celda[x, izq - 1].pieza.simbolo == "0" && CortarPasoizq == false)
                {
                    --izq;
                    celda[x, izq].pieza.simbolo = "X";
                }
                else if (izq - 1 >= 0 && celda[x, izq - 1].pieza.simbolo != "0" && CortarPasoizq == false && celda[x, izq - 1].pieza.equipo != celda[x, y].pieza.equipo)
                {
                    celda[x, izq - 1].pieza.capturada = true;
                    CortarPasoizq = true;
                    cortarCiclo = true;

                }
            }

            //Esquina superior izquierda
            int a = x;
            int b = y;
            bool CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                a--;
                b--;
                if (a >= 0 && b >= 0 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a >= 0 && b >= 0 && celda[a, b].pieza.simbolo != "0")
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }

            //Esquina inferior derecha
            a = x;
            b = y;
            CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                ++a;
                ++b;
                if (a <= 7 && b <= 7 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a <= 7 && b <= 7 && celda[a, b].pieza.simbolo != "0")
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }

            //Esquina inferior izquierda
            a = x;
            b = y;
            CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                ++a;
                --b;
                if (a <= 7 && b >= 0 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a <= 7 && b >= 0 && celda[a, b].pieza.simbolo != "0")
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }

            //Esquina superior dercha
            a = x;
            b = y;
            CortarPaso = false;
            for (int i = 0; i < 7; i++)
            {
                --a;
                ++b;
                if (a >= 0 && b <= 7 && celda[a, b].pieza.simbolo.Equals("0") && CortarPaso == false)
                {
                    celda[a, b].pieza.simbolo = "X";

                }
                else if (a >= 0 && b <= 7 && celda[a, b].pieza.simbolo != "0")
                {
                    if (celda[a, b].pieza.equipo == celda[x, y].pieza.equipo)
                    {
                        CortarPaso = true;
                        break;
                    }
                    else if (celda[a, b].pieza.equipo != celda[x, y].pieza.equipo)
                    {
                        celda[a, b].pieza.capturada = true;
                        CortarPaso = true;
                        break;
                    }
                }
            }
        }

        public void MovimientoDisponibles(int x, int y)
        {

            if (celda[x, y].pieza.nombre.Equals("Rey"))//Rey
            {
                MovimientoRey(x, y);

            }
            else if (celda[x, y].pieza.nombre.Equals("Peon")) //Peon
            {
                MovimientoPeon(x, y);

            }
            else if (celda[x, y].pieza.nombre.Equals("Torre")) //Torre
            {
                MovimientoTorre(x, y);
            }
            else if (celda[x, y].pieza.nombre.Equals("Caballo"))//Caballo
            {

                movimientoCaballo(x, y);

            }
            else if (celda[x, y].pieza.nombre.Equals("Alfil")) //Alfil
            {
                movimientoAlfil(x, y);

            }
            else if (celda[x, y].pieza.nombre.Equals("Reina"))//Reina
            {

                movimientoReina(x, y);

            }

            //imprimirTablero();

        }

        public void movimiento(int x, int y, int xDes, int yDes)
        {

            if (celda[xDes, yDes].pieza.simbolo.Equals("X") || celda[xDes, yDes].pieza.capturada == true && celda[xDes, yDes].pieza.equipo != celda[x, y].pieza.equipo)
            {

                if (celda[x, y].pieza.equipo == "1" && turno == true || celda[x, y].pieza.equipo == "2" && turno == false)
                {
                    ListaCapturas(xDes, yDes);
                    celda[xDes, yDes].pieza.simbolo = celda[x, y].pieza.simbolo;
                    celda[xDes, yDes].pieza.nombre = celda[x, y].pieza.nombre;
                    celda[xDes, yDes].pieza.equipo = celda[x, y].pieza.equipo;
                    celda[xDes, yDes].pieza.imagen = celda[x, y].pieza.imagen;
                    cambioTurno();
                    celda[x, y].pieza.simbolo = "0";
                    //celda[x, y].pieza.equipo = "0";
                    celda[x, y].pieza.nombre = "0";
                    celda[x, y].pieza.capturada = false;
                    actualizarTablero();
                    celda[xDes, yDes].pieza.PrimerMov = false;


                    ListaMovimientos(x.ToString(), y, xDes.ToString(), yDes);

                    jaqueMate();


                }
                else
                {
                    Console.WriteLine("No es tu turno");
                }

            }
            else
            {
                Console.WriteLine("No se puede desplazar a esa posicion");
            }

            imprimirTablero();

        }

        public void MostrarEquipo(int x, int y)
        {
            Console.WriteLine(celda[x, y].pieza.equipo);
        }

        public void cambioTurno()
        {
            if (turno == true)
            {
                turno = false;
            }
            else if (turno == false)
            {
                turno = true;
            }
        }

        public string jaque()
        {
            if (turno)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (celda[i, j].pieza.equipo == "1")
                        {
                            MovimientoDisponibles(i, j);
                            actualizarTablero();
                        }

                        if (celda[ubicarRey(turno)[0], ubicarRey(turno)[1]].pieza.capturada == true)
                        {
                            return "El rey esta en peligro";
                            celda[ubicarRey(turno)[0], ubicarRey(turno)[1]].pieza.capturada = false;
                        }
                        else
                        {
                            return "El rey no esta en peligro";
                        }
                    }
                }

            }
            else if (!turno)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (celda[i, j].pieza.equipo == "2")
                        {
                            MovimientoDisponibles(i, j);
                            actualizarTablero();
                        }

                        if (celda[ubicarRey(turno)[0], ubicarRey(turno)[1]].pieza.capturada == true)
                        {
                            return "El rey esta en peligro";
                            celda[ubicarRey(turno)[0], ubicarRey(turno)[1]].pieza.capturada = false;
                        }
                        else
                        {
                            return "El rey no esta en peligro";
                        }
                    }
                }
            }

            return "OK";
        }

        public void jaqueMate()
        {
            string advertencia = jaque();

            if (advertencia.Equals("El rey esta en peligro"))
            {
                if (SimularRecorrido())
                {
                    JM = true;
                }
            }
        }

        public bool SimularRecorrido()
        {
            MovimientoRey(ubicarRey(true)[0], ubicarRey(true)[1]);

            int[] aux = new int[2];

            aux[0] = ubicarRey(true)[0];
            aux[1] = ubicarRey(true)[1];

            bool condicion = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (celda[i, j].pieza.simbolo.Equals("X"))
                    {
                        celda[i, j].pieza.simbolo = celda[aux[0], aux[1]].pieza.simbolo;
                        celda[i, j].pieza.nombre = celda[aux[0], aux[1]].pieza.nombre;
                        celda[i, j].pieza.equipo = celda[aux[0], aux[1]].pieza.equipo;
                        celda[i, j].pieza.imagen = celda[aux[0], aux[1]].pieza.imagen;
                        //
                        celda[aux[0], aux[1]].pieza.simbolo = "0";
                        //celda[x, y].pieza.equipo = "0";
                        celda[aux[0], aux[1]].pieza.nombre = "0";
                        celda[aux[0], aux[1]].pieza.capturada = false;

                        if (jaque().Equals("El rey esta en peligro"))
                        {
                            condicion = true;
                        }
                        else if (jaque().Equals("El rey no esta en peligro"))
                        {
                            condicion = false;
                            break;
                        }

                        celda[aux[0], aux[1]].pieza.simbolo = celda[i, j].pieza.simbolo;
                        celda[aux[0], aux[1]].pieza.nombre = celda[i, j].pieza.nombre;
                        celda[aux[0], aux[1]].pieza.equipo = celda[i, j].pieza.equipo;
                        celda[aux[0], aux[1]].pieza.imagen = celda[i, j].pieza.imagen;

                        celda[i, j].pieza.simbolo = "0";
                        //celda[x, y].pieza.equipo = "0";
                        celda[i, j].pieza.nombre = "0";
                        celda[i, j].pieza.capturada = false;
                    }


                }
            }

            return condicion;
        }
        public int[] ubicarRey(bool a)
        {
            int[] ubicar = new int[2];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (celda[i, j].pieza.nombre == "Rey" && celda[i, j].pieza.equipo == "2" && a == true)
                    {
                        ubicar[0] = i;
                        ubicar[1] = j;
                    }
                    else if (celda[i, j].pieza.nombre == "Rey" && celda[i, j].pieza.equipo == "1" && a == false)
                    {
                        ubicar[0] = i;
                        ubicar[1] = j;
                    }

                }
            }

            return ubicar;
        }

        public void ListaCapturas(int a, int b)
        {
            if (celda[a, b].pieza.simbolo != "X" && celda[a, b].pieza.equipo == "1")
            {
                Lista_Capturada1.Add(celda[a, b].pieza.nombre);
            }
            else if (celda[a, b].pieza.simbolo != "X" && celda[a, b].pieza.equipo == "2")
            {

                Lista_Capturada2.Add(celda[a, b].pieza.nombre);
            }


        }

        public void ListaMovimientos(string x, int y, string xDes, int yDes)
        {
            if (celda[int.Parse(x), y].pieza.equipo == "1")
            {
                Lista_Movimientos1.Add(Letras(x) + "" + y.ToString() + "------" + Letras(xDes) + "" + yDes.ToString() + "----" + celda[Int32.Parse(xDes),yDes].pieza.nombre);

            }
            else if (celda[int.Parse(x), y].pieza.equipo == "2")
            {
                Lista_Movimientos2.Add(Letras(x) + "" + y.ToString() + "------" + Letras(xDes) + "" + yDes.ToString() + "----" + celda[Int32.Parse(xDes), yDes].pieza.nombre);
            }
        }

        public string Letras(string a)
        {

            switch (a)
            {
                case "0":
                    a = "a";
                    return a;
                case "1":
                    a = "b";
                    return a;
                case "2":
                    a = "c";
                    return a;
                case "3":
                    a = "d";
                    return a;
                case "4":
                    a = "e";
                    return a;
                case "5":
                    a = "f";
                    return a;
                case "6":
                    a = "g";
                    return a;
                case "7":
                    a = "h";
                    return a;
            }

            return a;

        }

        public void AperturaItaliana()
        {
            AperItaliana = true;
            if (numero_Turno == 1 && turno == true)
            {
                MovimientoDisponibles(6, 4);
                movimiento(6, 4, 4, 4);
                numero_Turno += 2;

            }
            else if (numero_Turno == 3 && turno == true && celda[3, 4].pieza.nombre == "Peon")
            {
                MovimientoDisponibles(7, 6);
                movimiento(7, 6, 5, 5);
                numero_Turno += 2;
            }
            else if (numero_Turno == 5 && turno == true && celda[2, 2].pieza.nombre == "Caballo" && celda[0, 1].pieza.simbolo == "0")
            {
                MovimientoDisponibles(7, 5);
                movimiento(7, 5, 4, 2);
                numero_Turno += 2;
                AperItaliana = false;
            }


        }

        public void Defensa_Siciliana()
        {
            DefSiciliana = true;
            if (numero_Turno == 1 && turno == true)
            {
                MovimientoDisponibles(6, 4);
                movimiento(6, 4, 4, 4);
                numero_Turno += 2;

            }
            else if (numero_Turno == 3 && turno == true && celda[3, 2].pieza.nombre == "Peon" && celda[1, 2].pieza.simbolo == "0")
            {
                MovimientoDisponibles(7, 6);
                movimiento(7, 6, 5, 5);
                numero_Turno += 2;
                DefSiciliana = false;
            }
        }

        public void Defensa_Francesa()
        {
            DefFrancesa = true;
            if (numero_Turno == 1 && turno == true)
            {
                MovimientoDisponibles(6, 3);
                movimiento(6, 3, 4, 3);
                numero_Turno += 2;

            }
            else if (numero_Turno == 3 && turno == true && celda[3, 3].pieza.nombre == "Peon" && celda[1, 3].pieza.simbolo == "0")
            {
                MovimientoDisponibles(6, 4);
                movimiento(6, 4, 4, 4);
                numero_Turno += 2;
            }
            else if (numero_Turno == 5 && turno == true && celda[2, 4].pieza.nombre == "Peon" && celda[1, 4].pieza.simbolo == "0")
            {
                MovimientoDisponibles(7, 1);
                movimiento(7, 1, 5, 2);
                numero_Turno += 2;
            }
            else if (numero_Turno == 7 && turno == true && celda[2, 5].pieza.nombre == "Caballo" && celda[0, 6].pieza.simbolo == "0")
            {
                MovimientoDisponibles(7, 2);
                movimiento(7, 2, 3, 6);
                numero_Turno += 2;
                DefFrancesa = false;
            }
        }


        public void Ruy_Lopez()
        {
            AperRuyLopez = true;
            if (numero_Turno == 1 && turno == true)
            {
                MovimientoDisponibles(6, 4);
                movimiento(6, 4, 4, 4);
                numero_Turno += 2;
            }
            else if (numero_Turno == 3 && turno == true && celda[3, 4].pieza.nombre == "Peon" && celda[1, 4].pieza.simbolo == "0")
            {
                MovimientoDisponibles(7, 6);
                movimiento(7, 6, 5, 5);
                numero_Turno += 2;
            }
            else if (numero_Turno == 7 && turno == true && celda[2, 2].pieza.nombre == "Caballo" && celda[0, 1].pieza.simbolo == "0")
            {
                MovimientoDisponibles(7, 5);
                movimiento(7, 5, 3, 1);
                numero_Turno += 2;
                AperRuyLopez = false;
            }
        }


        public void Defensa_Eslava()
        {
            DefEslava = true;
            if (numero_Turno == 1 && turno == true)
            {
                MovimientoDisponibles(6, 3);
                movimiento(6, 3, 4, 3);
                numero_Turno += 2;
            }
            if (numero_Turno == 3 && turno == true && true && celda[3, 3].pieza.nombre == "Peon" && celda[1, 3].pieza.simbolo == "0")
            {
                MovimientoDisponibles(6, 2);
                movimiento(6, 2, 4, 2);
                numero_Turno += 2;
                DefEslava = false;
            }
        }


    }
}
