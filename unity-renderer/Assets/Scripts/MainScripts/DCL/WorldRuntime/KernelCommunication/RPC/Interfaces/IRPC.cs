﻿using Cysharp.Threading.Tasks;
using Memetaverse.Renderer.KernelServices;

namespace DCL
{
    public interface IRPC : IService
    {
        public UniTask EnsureRpc();

        public ClientEmotesKernelService Emotes();
        public ClientFriendRequestKernelService FriendRequests();
        public ClientFriendsKernelService Friends();
        public ClientSignRequestKernelService SignRequestKernelService();
    }
}
