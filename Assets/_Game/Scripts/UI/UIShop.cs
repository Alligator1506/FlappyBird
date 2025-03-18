using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIShop : UICanvas
{
    //[SerializeField] private Transform skinPoint;
    
    [SerializeField] ShopData shopData;
    //SerializeField] ButtonState buttonState;

    private Skin _currentSkin;
    private SkinType _skinType;
    
    public override void Setup()
    {
        base.Setup();
        ChangeSkin(UserData.Ins.playerSkin);
    }
    
    public override void CloseDirectly()
    {
        base.CloseDirectly();

        if (_currentSkin != null)
        {
            SimplePool.Despawn(_currentSkin);
            _currentSkin = null;
        }

        UIManager.Ins.OpenUI<UIMainMenu>();
    }

    public void NextButton()
    {
        ChangeSkin(shopData.NextType(_skinType));
    }
    
    public void PrevButton()
    {
        ChangeSkin(shopData.PrevType(_skinType));
    }

    public void ChangeSkin(SkinType skinType)
    {
        this._skinType = skinType;
        
        if (_currentSkin != null )
        {
            SimplePool.Despawn(_currentSkin);
        }

        _currentSkin = SimplePool.Spawn<Skin>((PoolType)skinType, Vector3.zero, Quaternion.identity);
        
        // ButtonState.State state = (ButtonState.State)UserData.Ins.GetDataState(weaponType.ToString(), 0);
        // buttonState.SetState(state);

        SkinItem item = shopData.GetSkinItem(skinType);
    }
}
