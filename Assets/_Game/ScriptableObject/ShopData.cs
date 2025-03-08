using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/Shop Data", order = 1)]
public class ShopData : ScriptableObject
{
    [SerializeField] List<SkinItem> _skinItems;
    
    public List<SkinItem> SkinItems => _skinItems;

    public SkinItem GetSkinItem(SkinType skinType)
    {
        return _skinItems.Single(q => q.type == skinType);
    }

    public SkinType NextType(SkinType skinType)
    {
        int index = _skinItems.FindIndex(q => q.type == skinType);
        index = index + 1 >= _skinItems.Count ? 0 : index + 1;
        return _skinItems[index].type;
    }

    public SkinType PrevType(SkinType skinType)
    {
        int index = _skinItems.FindIndex(q => q.type == skinType);
        index = index - 1 < 0 ? _skinItems.Count -1 : index - 1;
        return _skinItems[index].type;
    }
}

[System.Serializable]
public class SkinItem
{
    public string name;
    public SkinType type;
}