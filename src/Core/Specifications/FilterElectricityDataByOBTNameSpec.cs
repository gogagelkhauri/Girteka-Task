using Ardalis.Specification;
using Core.Entities;


namespace Core.Specifications
{
    public class FilterElectricityDataByOBTNameSpec : Specification<AggregatedData>
    {
        public FilterElectricityDataByOBTNameSpec(string appartmentType)
        {
            Query.Where(o => o.OBT_PAVADINIMAS == appartmentType);
        }
    }
}
