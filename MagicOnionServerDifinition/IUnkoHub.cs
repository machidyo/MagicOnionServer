using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MagicOnion;

namespace MagicOnionServerDefinition
{
    /// <summary>
    /// CLient -> ServerのAPI
    /// </summary>
    public interface IUnkoHub : IStreamingHub<IUnkoHub, IUnkoHubReceiver>
    {
        /// <summary>
        /// 参加することをサーバに伝える
        /// </summary>
        /// <param name="userName">参加者の名前</param>
        /// <returns></returns>
        Task JoinAsync(string userName);

        /// <summary>
        /// 退室することをサーバに伝える
        /// </summary>
        /// <returns></returns>
        Task LeaveAsync();

        Task SendPositionAsync(float x, float y, float z);


        Task ShootAsync();
    }
}
