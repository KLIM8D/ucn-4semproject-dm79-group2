
using Repository.Resources;

namespace BusinessLogic.Resources
{
    class TransitLogic
    {
        public int GetLocationIdFromArea(int value)
        {
            var transitRepository = new TransitRepository();
            return transitRepository.GetTransitIdFromAreaId(value);
        }
    }
}
