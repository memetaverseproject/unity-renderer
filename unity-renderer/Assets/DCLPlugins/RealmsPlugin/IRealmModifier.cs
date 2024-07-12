using System;
using static Memetaverse.Bff.AboutResponse.Types;

namespace DCLPlugins.RealmPlugin
{
    public interface IRealmModifier : IDisposable
    {
        void OnEnteredRealm(bool isWorld, AboutConfiguration realmConfiguration);
    }
}
