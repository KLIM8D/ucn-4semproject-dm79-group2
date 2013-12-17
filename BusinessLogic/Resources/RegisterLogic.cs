using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;

namespace BusinessLogic.Resources
{
    public class RegisterLogic
    {
        public bool InsertTravel(DataStream value)
        {
            var registerRepository = new RegisterRepository();
            registerRepository.InsertRegisterTravel(value.ToDataObj());

            return true;
        }

        public List<register_travel> GetAllTravelsByUserId(int value)
        {
            var registerRepository = new RegisterRepository();
            return registerRepository.GetRegisterTravelByUserId(value).ToList();
        }

        public bool InsertTravelType(register_date_type registerDateType)
        {
            var registerRepository = new RegisterRepository();
            registerRepository.InsertRegisterDateType(registerDateType);

            return true;
        }
    }

    public class DataStream
    {
        public int CardId { get; set; }
        public int StationId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Type { get; set; }

        public register_travel ToDataObj()
        {
            var transitLogic = new TransitLogic();
            var userLogic = new UserLogic();

            var obj = new register_travel
            {
                tra_loc_id = transitLogic.GetLocationIdFromArea(StationId),
                usr_det_id = userLogic.GetUserIdByCardNo(CardId),
                reg_tra_timestamp = TimeStamp,
                reg_dat_typ_id = Type
            };

            return obj;
        }
    }
}