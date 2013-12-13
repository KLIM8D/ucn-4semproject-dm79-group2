using System;
using Repository.Models;
using Repository.Resources;
using Utils.ExtensionMethods;
using Utils.Security;

namespace BusinessLogic.Resources
{
    public class UserLogic
    {
        private UserRepository _userRepo;
        private SecurityGroupRepository _securityGroupRepo;
        private CityRepository _cityRepository;
        public UserLogic()
        {
            _userRepo = new UserRepository();
            _securityGroupRepo = new SecurityGroupRepository();
            _cityRepository = new CityRepository();
        }

        public bool SaveUser(User user)
        {
            var role = _securityGroupRepo.GetGroupByTitle(user.sec_group);
            if (role != null)
            {

                var userSec = new security_credentials
                              {
                                  sec_cre_active = user.is_active.TryParseBool(),
                                  sec_cre_timestamp = user.created_timestamp.TryParseDateTime(),
                                  sec_cre_uname = user.uname,
                                  sec_gro_id = role.sec_gro_id,
                                  sec_cre_passwd = new Hashing().SHA512(user.passwd)
                              };
                userSec = _userRepo.InsertSecurityCred(userSec);

                byte[] key = new Hashing().MD5(userSec.sec_cre_uname + userSec.sec_cre_timestamp);
                var userDetails = new user_details
                                  {
                                      usr_det_active = user.is_active.TryParseBool(),
                                      usr_det_email = user.email,
                                      usr_det_fname = user.fname,
                                      usr_det_lname = user.lname,
                                      usr_det_ssn = Encryption.EncryptString(user.ssn.ToString(), key),
                                      usr_det_phoneno = user.phoneno.TryParseInt(),
                                      usr_det_timestamp = user.created_timestamp.TryParseDateTime(),
                                      sec_cre_id = userSec.sec_cre_id
                                  };
                
                userDetails = _userRepo.InsertDetails(userDetails);

                var city = _cityRepository.GetCity(user.zipcode.TryParseInt());
                var userAddress = new user_address
                                  {
                                      usr_adr_street = user.street,
                                      geo_zip_id = city.geo_zip_id,
                                      usr_det_id = userDetails.usr_det_id
                                  };

                _cityRepository.InsertUserAddress(userAddress);

                new TravelCardLogic().OrderNewCard(user);

                return true;
            }



            return false;
        }

        public bool LoginUser(string userName, string password)
        {
            if(String.IsNullOrEmpty(userName))
                throw new Exception("userName cannot be null or empty");
            if (String.IsNullOrEmpty(password))
                throw new Exception("password cannot be null or empty");

            string hashedPassword = new Hashing().SHA512(password);

            return new UserRepository().ValidateCred(userName, hashedPassword);
        }

        public int GetUserIdByCardNo(int value)
        {
            var userRepository = new UserRepository();
            return userRepository.GetUidByCardNo(value);
        }
    }
}