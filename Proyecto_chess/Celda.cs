using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_chess
{
    internal class Celda
    {
        public int PosX = 0;
        public int PosY = 0;
        public Pieza pieza;


        public Celda(int posX, int posY, Pieza pieza)
        {
            PosX = posX;
            PosY = posY;
            this.pieza = pieza;
        }


    }
}
