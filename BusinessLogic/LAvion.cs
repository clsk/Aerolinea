using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;

namespace BusinessLogic
{
    /// <summary>
    /// Clase que maneja las transacciones de un avión.
    /// </summary>
    public class LAvion
    {
        //Serie del avion.
        SerieAvion idSerie;

        //Una lista de direcciones (URL) de las plantas.
        List<string> plantas;

        //Una lista de asientos temporales.
        List<LAsiento> asientos;

        //Cantidad de pisos que tendrá el avión
        int cantidad;

        public LAvion()
        {
            plantas = new List<string>();
            asientos = new List<LAsiento>();
        }

        public SerieAvion IdSerie
        {
            get { return idSerie; }
            set { idSerie = value; }
        }

        
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        /// <summary>
        /// Guarda una dirección de la planta a la lista.
        /// </summary>
        /// <param name="imagen"></param>
        public void addPlanta(string imagen)
        {
            plantas.Add(imagen);
        }

        /// <summary>
        /// Copia una imagen para un directorio controlado.
        /// </summary>
        /// <param name="image">El URL actual de la imagen.</param>
        /// <param name="avion_id">ID del avion al cual le pertenece la planta</param>
        /// <param name="piso">Piso de la planta</param>
        /// <returns>El URL completo donde se guardó la imagen </returns>
        private string SaveImageToURL(string image, int avion_id, int piso)
        {
            string url;
            url= Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            url += "\\PlantaImages\\" + avion_id.ToString() + "_" + piso.ToString() + image.Substring(image.LastIndexOf('.') + 1);

            System.IO.File.Copy(image, url);
            return url;
        }

        /// <summary>
        /// Agrega un asiento temporalmente al avión.
        /// </summary>
        /// <param name="X">Coordenada en X del asiento.</param>
        /// <param name="Y">Coordenada en Y del asiento.</param>
        /// <param name="IdClase">Clase del asiento.</param>
        /// <param name="Numero">Numero del asiento.</param>
        /// <param name="Fila">Numero de la fila ubicada.</param>
        /// <param name="Piso">Piso en el cual está ubicado el asiento.</param>
        public void addAsiento(int X, int Y, TipoClase IdClase, string Numero, int Fila, int Piso)
        {
            LAsiento unAsiento = new LAsiento(X,  Y, IdClase, Numero, Fila, Piso);
            asientos.Add(unAsiento);
        }
        /// <summary>
        /// Construye el avión apartir de todos los datos proveeidos.
        /// </summary>
        public void Flush()
        {
            TransAvion unAvion = new TransAvion(IdSerie);
            unAvion.Create();
            for(int i=0; i<plantas.Count; i++)
                unAvion.AddPlanta(SaveImageToURL(plantas[i],unAvion.ID, idSerie.idSerie));
            for(int j=0; j<asientos.Count; j++)
            {
                TransAsiento unAsiento = new TransAsiento(unAvion, asientos[j].Clase, asientos[j].Numero, asientos[j].Fila, asientos[j].X, asientos[j].Y, asientos[j].Piso);
                unAsiento.Create();
            }
        }
    }
    
    /// <summary>
    /// Clase que define un asiento.
    /// </summary>
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
