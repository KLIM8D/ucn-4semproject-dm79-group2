using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool InsTravel()
        {
            var dataStream = new DataStream();
            var registerRepository = new RegisterRepository();

            //registerRepository.InsertRegisterTravel(dataStream);

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

        //public register_travel ToDataObj()
        //{
        //    register_travel obj = new register_travel
        //    {
        //        reg_tra_timestamp = TimeStamp           
        //    }
        //}
    }
}