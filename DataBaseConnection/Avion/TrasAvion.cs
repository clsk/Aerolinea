using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TrasAvion: IAvion
    {

        public TrasAvion(int idAvion)
        {
        }
        private Avion avion;

        private MarcaAvion marca;

        public MarcaAvion Marca { get; set;  }

        private SerieAvion serie;

        public SerieAvion Serie { get; set;  }

        private List<PlantaAvion> plantas;

        public List<PlantaAvion> Plantas { get; set;  }

        public string NombreMarca { get; set;}

        public string NombreSerie { get; set; }

        public int ID { get; set; }

    }
}
