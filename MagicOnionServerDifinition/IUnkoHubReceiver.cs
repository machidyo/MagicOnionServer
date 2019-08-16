namespace MagicOnionServerDefinition
{
    /// <summary>
    /// Server -> ClientのAPI
    /// </summary>
    public interface IUnkoHubReceiver
    {
        /// <summary>
        /// 誰かがチャットに参加したことをクライアントに伝える。
        /// </summary>
        /// <param name="name">参加した人の名前</param>
        void OnJoin(string name);

        /// <summary>
        /// 誰かがチャットから退室したことをクライアントに伝える。
        /// </summary>
        /// <param name="name">退室した人の名前</param>
        void OnLeave(string name);

        void OnSendPosition(string name, float x, float y, float z);

        void OnShoot();
    }
}
