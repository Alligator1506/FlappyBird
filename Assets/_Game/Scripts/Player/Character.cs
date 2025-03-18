using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : AbCharacter
{
    [SerializeField] private Skin currentSkin;

    public bool IsDead { get; protected set; }
    public override void OnInit()
    {
        IsDead = false;
        WearClothes();
    }
    
    public virtual void WearClothes()
    {
        
    }
    
    public override void OnDespawn()
    {
       
    }
    
    public override void OnDeath()
    {
        
    }

    public void ChangeSkin(SkinType skinType)
    {
        currentSkin = SimplePool.Spawn<Skin>((PoolType)skinType, TF);
    }
}
