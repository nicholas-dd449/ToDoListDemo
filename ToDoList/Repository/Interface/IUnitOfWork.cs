using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// 提交保存更改
        /// </summary>
        /// <param name="session">MongoDB 会话（session）对象</param>
        /// <returns></returns>
        Task<bool> Commit(IClientSessionHandle session);

        /// <summary>
        /// 初始化MongoDB会话对象session
        /// </summary>
        /// <returns></returns>
        Task<IClientSessionHandle> InitTransaction();
    }
}
