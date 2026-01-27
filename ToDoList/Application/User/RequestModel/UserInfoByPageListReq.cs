using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.RequestModel
{
    public class UserInfoByPageListReq
    {
        public string Id { get; set; }

        public string NickName { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
