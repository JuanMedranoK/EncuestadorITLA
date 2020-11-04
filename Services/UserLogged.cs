using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class UserLogged
    {
        public User user { get; set; } = null;

        public static UserLogged Instance { get; } = new UserLogged();

        public void logOut()
        {
        }
        private UserLogged()
        {

        }

    }
}
