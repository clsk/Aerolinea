using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using DataLayer;

namespace UI.Administrativo.AdmAvion
{
    class UIAsiento
    {
        public UIAsiento(int x, int y, int Numfila, string num, TipoClase Clase, Button elBoton)
        {
            posX = x;
            posY = y;
            fila = Numfila;
            numero = num;
            idTipoClase = Clase;
            unBoton = elBoton;
        }

        Button unBoton;
        public Button UnBoton
        {
            get { return unBoton; }
            set { unBoton = value; }
        }

        int posX;
        public int PosX
        {
            get { return  posX; }
            set { posX = value; }
        }

        int posY;
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        int fila;
        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }

        string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        TipoClase idTipoClase;
        public TipoClase Clase
        {
            get { return idTipoClase; }
            set { idTipoClase = value; }
        }
    }
}
