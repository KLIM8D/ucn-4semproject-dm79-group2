using Repository.Models;

namespace BusinessLogic.Resources
{
    public class UserLogic
    {
        public bool SaveUser(User user)
        {
            //TODO: Add db logic
            //TODO: Handle DB error messages

            new TravelCardLogic().OrderNewCard(user);

            return true;
        }

        public bool LoginUser(string userName, string password)
        {
            return true;
        }
    }
}
