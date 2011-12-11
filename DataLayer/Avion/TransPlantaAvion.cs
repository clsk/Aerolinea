using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class TransPlantaAvion : AbstractTrans<PlantaAvion>
    {
        private List<TransAsiento> asientos;

        public TransPlantaAvion(PlantaAvion persistent_object)
            : base(persistent_object)
        {
            asientos = DALAsiento.GetAsientoFromPisoAvion(persistent.idAvion, persistent.Piso).ConvertAll<TransAsiento>(pers => new TransAsiento(pers));
        }

        public List<TransAsiento> Asientos
        {
            get { return asientos; }
        }

    }
}
