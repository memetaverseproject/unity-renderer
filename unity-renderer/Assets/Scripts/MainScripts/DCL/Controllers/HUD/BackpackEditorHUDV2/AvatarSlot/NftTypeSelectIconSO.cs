using UnityEngine;

[CreateAssetMenu(fileName = "NftTypeSelectIcons", menuName = "Variables/NftTypeSelectIcons")]
public class NftTypeSelectIconSO : ScriptableObject
{
    [SerializeField] public SerializableKeyValuePair<string, Sprite>[] nftIcons;

    public Sprite GetTypeImage(string nftType)
    {
        foreach (var icon in nftIcons)
        {
            if(icon.key == nftType)
                return icon.value;
        }
        return null;
    }
}
