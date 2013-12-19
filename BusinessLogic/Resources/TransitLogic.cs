
using Repository.Resources;

namespace BusinessLogic.Resources
{
    public class TransitLogic
    {
        private TransitRepository _repo;

        public TransitLogic()
        {
            _repo = new TransitRepository();
        }
        public int GetLocationIdFromArea(int value)
        {
            return _repo.GetAreaFromStationId(value).tra_loc_area_id;
        }

        public int GetAreaIdFromStationId(int value)
        {
            return _repo.GetAreaFromStationId(value).tra_loc_area_id;
        }
    }
}
