using Repository.Models;

namespace EndpointService.Services.Interfaces
{
    interface IRegisterService
    {
        register_travel CreateRegisterTravel(register_travel registerTravel);
    }
}
