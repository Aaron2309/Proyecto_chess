using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_chess
{
    internal class Pieza
    {
        public string nombre;
        public bool capturada;
        public string simbolo;
        public string equipo = "1";
        public string imagen = "";
        public bool PrimerMov = true;

        public Pieza(string a)
        {
            nombre = a;
            capturada = false;

            if (a.Equals("Peon"))
            {
                simbolo = "*";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\HongoPeon.png";
            }
            else if (a.Equals("Rey"))
            {
                simbolo = "-";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\MarioRey.png";
            }
            else if (a.Equals("Torre"))
            {
                simbolo = "?";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\LakituTorre.png";
            }
            else if (a.Equals("Alfil"))
            {
                simbolo = ".";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\LuigiAlfil.png";
            }
            else if (a.Equals("Caballo"))
            {
                simbolo = "%";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\YoshiCaballo.png";
            }
            else if (a.Equals("Reina"))
            {
                simbolo = "+";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\PeachReina.png";
            }
            else
            {
                simbolo = "0";
                imagen = "C:\\Users\\abren\\source\\repos\\Proyecto_chess\\Proyecto_chess\\Imagenes\\Piso.jpg";
            }


        }
    }
}
