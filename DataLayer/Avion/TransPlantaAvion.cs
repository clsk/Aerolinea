using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransPlantaAvion : AbstractTrans<PlantaAvion>
    {
        private List<TransAsiento> asientos;

        public TransPlantaAvion(PlantaAvion persistent_object, bool fetch_asientos = true)
            : base(persistent_object)
        {
            if (fetch_asientos)
                asientos = DALAsiento.GetAsientoFromPisoAvion(persistent.idAvion, persistent.Piso).ConvertAll<TransAsiento>(pers => new TransAsiento(pers));
        }

        public int idAvion
        {
            get { return persistent.idAvion; }
        }

        public ReadOnlyCollection<TransAsiento> Asientos
        {
            get { return asientos.AsReadOnly(); }
        }

        public void AddAsiento(TransAsiento asiento)
        {
            asientos.Add(asiento);
        }

        public byte[] Imagen
        {
            get { return persistent.ImagenPlanta; }
            set { persistent.ImagenPlanta = value; }
        }

        public int Piso
        {
            get { return persistent.Piso; }
            set { persistent.Piso = value; }
        }

    }
}
