using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace DataLayer
{
    public class TransAvion: AbstractTrans<Avion>, IAvion
    {
        public TransAvion(Avion persistent_object)
            : base(persistent_object)
        {
            List<PlantaAvion> _plantas = DALAvion.GetPlantaAvionFromAvion(this.ID);

            foreach (PlantaAvion planta in _plantas)
            {
                plantas[planta.Piso] = new TransPlantaAvion(planta);
            }
        }

        public TransAvion(SerieAvion serie)
            : base(null)
        {
            persistent = new Avion();
            Serie = serie;
            plantas = new TransPlantaAvion[0];
        }

        public ReadOnlyCollection<TransPlantaAvion> Plantas
        {
            get { return new ReadOnlyCollection<TransPlantaAvion>(plantas); }
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

        public void Create()
        {
            persistent.idAvion = DALAvion.Create(persistent);
        }

        // @returns El numero de piso en que se agrego esta planta
        public int AddPlanta(byte[] imagen)
        {
            // Create object in database
            PlantaAvion planta = new PlantaAvion();
            planta.idAvion = ID;
            planta.ImagenPlanta = imagen;
            planta.Piso = plantas.Length;
            DALAvion.CreatePlantaAvion(planta);

            // Create new array with +1 elements
            TransPlantaAvion[] old_plantas = plantas;
            plantas = new TransPlantaAvion[plantas.Length + 1];
            Array.Copy(old_plantas, plantas, old_plantas.Length);

            // Assign new planta to last index
            plantas[old_plantas.Length] = new TransPlantaAvion(planta, false);
            return old_plantas.Length; // return index of nivel de planta
        }
    }
}
