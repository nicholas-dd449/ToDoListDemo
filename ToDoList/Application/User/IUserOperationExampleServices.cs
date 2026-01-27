using Application.User.RequestModel;
using Repository.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public interface IUserOperationExampleServices
    {
        Task<IEnumerable<UserInfo>> GetAllUserInfos();

        Task<IEnumerable<UserInfo>> GetUserInfoByPageList(UserInfoByPageListReq userInfoByPageListReq);

        Task<UserInfo> GetUserInfoById(string id);

        Task<UserInfo> AddUserInfo(UserInfoReq userInfo);

        Task<UserInfo> AddUserInfoTransactions(UserInfoReq userInfo);

        Task<UserInfo> UpdateUserInfo(string id, UserInfoReq userInfo);

        Task<bool> Delete(string id);
    }
}
