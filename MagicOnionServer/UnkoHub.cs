using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MagicOnion.Server.Hubs;
using MagicOnionServerDefinition;

namespace MagicOnionServer
{
    public class UnkoHub : StreamingHubBase<IUnkoHub, IUnkoHubReceiver>, IUnkoHub
    {
        IGroup room;
        string me;

        public async Task JoinAsync(string userName)
        {
            //ルームは全員固定
            const string roomName = "SampleRoom";
            //ルームに参加&ルームを保持
            this.room = await this.Group.AddAsync(roomName);
            //自分の名前も保持
            me = userName;
            //参加したことをルームに参加している全メンバーに通知
            this.Broadcast(room).OnJoin(userName);

            Console.WriteLine($"End JoinAsync: {userName}");
        }

        public async Task LeaveAsync()
        {
            //ルーム内のメンバーから自分を削除
            await room.RemoveAsync(this.Context);
            //退室したことを全メンバーに通知
            this.Broadcast(room).OnLeave(me);
        }

        public async Task SendPositionAsync(float x, float y, float z)
        {
            this.Broadcast(room).OnSendPosition(me, x, y, z);
        }

        public async Task ShootAsync()
        {
            this.Broadcast(room).OnShoot();
            Console.WriteLine("Shoot");
        }

        protected override ValueTask OnDisconnected()
        {
            //nop
            return CompletedTask;
        }
    }
}
