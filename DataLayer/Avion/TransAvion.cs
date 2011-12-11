using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransAvion: AbstractTrans<Avion>, IAvion
    {
        internal TransAvion(Avion persistent_object)
            : base(persistent_object)
        {
            List<PlantaAvion> _plantas = DALAvion.GetPlantaAvionFromAvion(this.ID);
            plantas = new TransPlantaAvion[_plantas.Count];

            foreach (PlantaAvion planta in _plantas)
            {
                plantas[planta.Piso] = new TransPlantaAvion(planta);
            }
        }

        public SerieAvion Serie
        {
            get { return persistent.SerieAvion; }
            set { persistent.SerieAvion = value; }
        }

        public int ID
        {
            get { return persistent.idAvion; }
        }

        private TransPlantaAvion[] plantas;

        public void Flush()
        {
            base.Flush(DALAvion.UpdateAvion);
        }
    }
}
