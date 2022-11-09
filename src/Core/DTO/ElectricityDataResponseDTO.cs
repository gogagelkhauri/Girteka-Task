using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ElectricityDataResponseDTO
    {
        public string TINKLAS { get; set; }
        public string OBT_PAVADINIMAS { get; set; }
        public string ElectricityUsed { get; set; }

        public ElectricityDataResponseDTO(string tinklas, string obt_PAVADINIMAS,string electricityDataUsed)
        {
            TINKLAS = tinklas;
            OBT_PAVADINIMAS = obt_PAVADINIMAS;
            ElectricityUsed = electricityDataUsed;
        }

    }
}
