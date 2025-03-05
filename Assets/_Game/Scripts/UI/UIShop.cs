using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIShop : UICanvas
{
    public Transform skinPoint;
    
    [SerializeField] ShopData shopData;
    //SerializeField] ButtonState buttonState;

    private Skin currentSkin;
    private SkinType skinType;

    public override void Setup()
    {
        base.Setup();
        ChangeSkin(UserData.Ins.playerSkin);
    }
    
    public override void CloseDirectly()
    {
        base.CloseDirectly();

        // if (currentWeapon != null)
        // {
        //     SimplePool.Despawn(currentWeapon);
        //     currentWeapon = null;
        // }

        UIManager.Ins.OpenUI<UIMainMenu>();
    }

    public void NextButton()
    {
        ChangeSkin(shopData.NextType(skinType));
    }
    
    public void PrevButton()
    {
        ChangeSkin(shopData.PrevType(skinType));
    }

    public void ChangeSkin(SkinType skinType)
    {
        this.skinType = skinType;
        
        if (currentSkin != null )
        {
            SimplePool.Despawn(currentSkin);
        }

        currentSkin = SimplePool.Spawn<Skin>((PoolType)skinType);
        
        // ButtonState.State state = (ButtonState.State)UserData.Ins.GetDataState(weaponType.ToString(), 0);
        // buttonState.SetState(state);

        SkinItem item = shopData.GetSkinItem(skinType);
    }
}
