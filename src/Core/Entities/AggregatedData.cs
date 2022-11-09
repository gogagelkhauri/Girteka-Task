using Core.Interfaces;

namespace Core.Entities
{
    public class AggregatedData : BaseEntity, IAggregateRoot
    {
        public string TINKLAS { get; set; }
        public string OBT_PAVADINIMAS { get; set; }
        public string ElectricityDataUsed { get; set; }

        public AggregatedData(string tINKLAS, 
            string oBT_PAVADINIMAS, 
            string electricityDataUsed)
        {
            TINKLAS = tINKLAS;
            OBT_PAVADINIMAS = oBT_PAVADINIMAS;
            ElectricityDataUsed = electricityDataUsed;
        }
    }
}
