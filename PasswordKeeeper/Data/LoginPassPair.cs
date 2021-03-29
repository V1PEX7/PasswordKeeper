using System;
using System.Text;
using System.Collections.Generic;
namespace PasswordKeeeper.Data
{
    public class LoginPassDesc
    {
        public string Resource { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int id { get; set; }
    }

    public static class LogPassDescList
    {
        public static List<LoginPassDesc> list = new List<LoginPassDesc>();
    }
}
