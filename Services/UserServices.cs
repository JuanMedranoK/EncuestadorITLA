using Services.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices
    {
        User user = new User();
        UserRepository userRepository = new UserRepository();
        public bool addUser(User user)
        {
            return userRepository.Add(user);
        }
        public DataTable getSpecific(string query)
        {
            return userRepository.GetSpecific(query);
        }
    }
}
