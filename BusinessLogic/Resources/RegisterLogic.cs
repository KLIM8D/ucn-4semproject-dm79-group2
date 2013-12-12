using Repository.Models;
using Repository.Resources;

namespace BusinessLogic.Resources
{
    public class RegisterLogic
    {
        public bool InsertTravel(register_travel registerTravel)
        {
            var registerRepository = new RegisterRepository();
            registerRepository.InsertRegisterTravel(registerTravel);

            return true;
        }

        public bool InsertTravelType(register_date_type registerDateType)
        {
            var registerRepository = new RegisterRepository();
            registerRepository.InsertRegisterDateType(registerDateType);

            return true;
        }
    }
}