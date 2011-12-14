using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
namespace BusinessLogic
{
    public class LAvion
    {
        SerieAvion idSerie;
        public LAvion()
        {
            plantas = new List<Byte[]>();
            asientos = new List<LAsiento>();
        }
        public SerieAvion IdSerie
        {
            get { return idSerie; }
            set { idSerie = value; }
        }

        int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        List<Byte[]> plantas;

        List<LAsiento> asientos;

        public void addPlanta(byte[] imagen)
        {
            plantas.Add(imagen);
        }

        public void addAsiento(int X, int Y, TipoClase IdClase, string Numero, int Fila, int Piso)
        {
            LAsiento unAsiento = new LAsiento(X,  Y, IdClase, Numero, Fila, Piso);
            asientos.Add(unAsiento);
        }

        public void Flush()
        {
            TransAvion unAvion = new TransAvion(IdSerie);
            unAvion.Create();
            for(int i=0; i<plantas.Count; i++)
                unAvion.AddPlanta(plantas[i]);
            for(int j=0; j<asientos.Count; j++)
            {
                TransAsiento unAsiento = new TransAsiento(unAvion, asientos[j].Clase, asientos[j].Numero, asientos[j].Fila, asientos[j].X, asientos[j].Y, asientos[j].Piso);
                unAsiento.Create();
            }
        }
    }

    public class LAsiento
    {
        int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int piso;

        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }
        int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        TipoClase idClase;

        public TipoClase Clase
        {
            get { return idClase; }
            set { idClase = value; }
        }
        string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        int fila;

        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }
        public LAsiento(int X, int Y, TipoClase IdClase, string Numero, int Fila, int Piso)
        {
            x=X;
            y=Y;
            idClase = IdClase;
            numero = Numero;
            fila = Fila;
            piso = Piso;
        }

    }
}
