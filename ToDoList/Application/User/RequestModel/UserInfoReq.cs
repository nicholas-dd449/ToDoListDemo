using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.RequestModel
{
    public class UserInfoReq
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string NickName { get; set; }

        public string HeadPortrait { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }
    }
}
