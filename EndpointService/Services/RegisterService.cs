using System;
using EndpointService.Services.Interfaces;
using Repository.Models;

namespace EndpointService.Services
{
    class RegisterService : IRegisterService
    {
        public register_travel CreateRegisterTravel(register_travel registerTravel)
        {
            try
            {
                // some fancy data should be placed here...
            }
            catch (Exception ex)
            {               
                throw;
            }
        }
    }
}
