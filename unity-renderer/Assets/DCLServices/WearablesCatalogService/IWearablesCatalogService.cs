using Cysharp.Threading.Tasks;
using DCL;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DCLServices.WearablesCatalogService
{
    public interface IWearablesCatalogService : IService
    {
        const string BASE_WEARABLES_COLLECTION_ID = "urn:memetaverse:off-chain:base-avatars";

        BaseDictionary<string, WearableItem> WearablesCatalog { get; }

        UniTask<WearableCollectionsAPIData.Collection[]> GetThirdPartyCollectionsAsync(CancellationToken cancellationToken);
        UniTask<(IReadOnlyList<WearableItem> wearables, int totalAmount)> RequestOwnedWearablesAsync(
            string userId, int pageNumber, int pageSize,
            CancellationToken cancellationToken,
            string category = null, NftRarity rarity = NftRarity.None,
            NftCollectionType collectionTypeMask = NftCollectionType.All,
            ICollection<string> thirdPartyCollectionIds = null,
            string name = null, (NftOrderByOperation type, bool directionAscendent)? orderBy = null, string bodyShapeId = null);
        UniTask<(IReadOnlyList<WearableItem> wearables, int totalAmount)> RequestOwnedWearablesAsync(string userId, int pageNumber, int pageSize, bool cleanCachedPages, CancellationToken ct);
        UniTask RequestBaseWearablesAsync(CancellationToken ct);
        UniTask<(IReadOnlyList<WearableItem> wearables, int totalAmount)> RequestThirdPartyWearablesByCollectionAsync(string userId, string collectionId, int pageNumber, int pageSize, bool cleanCachedPages, CancellationToken ct);
        UniTask<WearableItem> RequestWearableAsync(string wearableId, CancellationToken ct);
        UniTask<WearableItem> RequestWearableFromBuilderAsync(string wearableId, CancellationToken ct);
        UniTask<IReadOnlyList<WearableItem>> RequestWearableCollection(IEnumerable<string> collectionIds, CancellationToken cancellationToken, List<WearableItem> collectionBuffer = null);
        UniTask<IReadOnlyList<WearableItem>> RequestWearableCollectionInBuilder(IEnumerable<string> collectionIds, CancellationToken cancellationToken, List<WearableItem> collectionBuffer = null);

        void AddWearablesToCatalog(IEnumerable<WearableItem> wearableItems);
        void RemoveWearablesFromCatalog(IEnumerable<string> wearableIds);
        void RemoveWearableFromCatalog(string wearableId);
        void RemoveWearablesInUse(IEnumerable<string> wearablesInUseToRemove);
        [Obsolete("Will be removed in the future, when emotes are in the content server.")]
        void AddEmbeddedWearablesToCatalog(IEnumerable<WearableItem> wearables);
        void Clear();
        bool IsValidWearable(string wearableId);
    }
}
