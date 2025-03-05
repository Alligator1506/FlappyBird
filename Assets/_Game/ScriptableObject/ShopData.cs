using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum SkinType
{
    Skin1 = PoolType.Skin1,
    Skin2 = PoolType.Skin2,
    Skin3 = PoolType.Skin3,
    Skin4 = PoolType.Skin4,
    Skin5 = PoolType.Skin5,
    Skin6 = PoolType.Skin6,
    Skin7 = PoolType.Skin7,
}

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/Shop Data", order = 1)]
public class ShopData : ScriptableObject
{
    [SerializeField] List<SkinItem> skinItems;
    
    public List<SkinItem> SkinItems => skinItems;

    public SkinItem GetSkinItem(SkinType skinType)
    {
        return skinItems.Single(q => q.type == skinType);
    }

    public SkinType NextType(SkinType skinType)
    {
        int index = skinItems.FindIndex(q => q.type == skinType);
        index = index + 1 >= skinItems.Count ? 0 : index + 1;
        return skinItems[index].type;
    }

    public SkinType PrevType(SkinType skinType)
    {
        int index = skinItems.FindIndex(q => q.type == skinType);
        index = index - 1 < 0 ? skinItems.Count -1 : index - 1;
        return skinItems[index].type;
    }
}

[System.Serializable]
public class SkinItem
{
    public string name;
    public SkinType type;
}