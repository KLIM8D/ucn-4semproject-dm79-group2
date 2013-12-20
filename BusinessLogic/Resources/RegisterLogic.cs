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
            var transitLogic = new TransitLogic();
            var withdrawRepo = new WithdrawRepository();
            var fareCollectionRepo = new FareCollectionRepository();
            var obj = value.ToDataObj();
            registerRepository.InsertRegisterTravel(obj);
            if (obj.reg_dat_typ_id == 2)
            {
                var latestTravel = registerRepository.GetLatestTravelsByUserId(obj.usr_det_id, 1);

                var zoneId = transitLogic.GetAreaIdFromStationId(obj.tra_loc_id);
                var fare = new GraphService().TravelPrice(obj.usr_det_id, latestTravel.transit_locations.tra_loc_area_id, zoneId);
                if (fare > 0)
                {
                    withdrawRepo.InsertWithdraw(new vault_withdraws()
                                                {
                                                    usr_det_id = obj.usr_det_id,
                                                    vau_wit_amount = fare,
                                                    vau_wit_timestamp = obj.reg_tra_timestamp
                                                });
                    var latestWithdraw = withdrawRepo.GetLatestWithdrawsByUserId(obj.usr_det_id, obj.reg_tra_timestamp);
                    fareCollectionRepo.InsertFareCollection(new collection_fares()
                                                            {
                                                                reg_tra_id = latestTravel.reg_tra_id,
                                                                usr_det_id = obj.usr_det_id,
                                                                vau_wit_id = latestWithdraw.vau_wit_id
                                                            });
                }
            }

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
            var userLogic = new UserLogic();

            var obj = new register_travel
            {
                tra_loc_id = StationId,
                usr_det_id = userLogic.GetUserIdByCardNo(CardId),
                reg_tra_timestamp = TimeStamp,
                reg_dat_typ_id = Type
            };

            return obj;
        }
    }
}