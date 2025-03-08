using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "PipeData", menuName = "ScriptableObjects/PipeData", order = 1)]
public class PipeData : ScriptableObject
{
    [SerializeField] private List<PipeItem> _pipeItems;
    
    public List<PipeItem> PipeItems => _pipeItems;
    
    public PipeItem GetPipeItem(PipeType pipeType)
    {
        return _pipeItems.Single(q => q.type == pipeType);
    }
}

[System.Serializable]
public class PipeItem
{
    public string name;
    public PipeType type;
}