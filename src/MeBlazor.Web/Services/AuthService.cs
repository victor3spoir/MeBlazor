using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Web.Services
{
    public class AuthService
    {
        List<UserInfo> users = new()
        {
            new UserInfo(){Username="victor3spoir", Password="P@55w0rd!"},
            new UserInfo(){Username="admin", Password="P@55w0rd!"},
         };

        public bool VerifyUser(string username, string password)
        {
            var _user = users.FirstOrDefault(u => u.Username == username);
            if (_user != null)
            {
                return _user.Password == password;
            }
            return false;
        }
    }
}