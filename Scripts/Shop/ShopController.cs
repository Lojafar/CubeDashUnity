using System;
using UnityEngine;
public class ShopController : MonoBehaviour
{
    [SerializeField] SoundController soundController;
    [SerializeField] MenuAdvHandler advHandler;
    [SerializeField] ShopSkinChanger shopSkinChanger;
    [SerializeField] ColorsListScriptObj colorsListScriptObj;
    [SerializeField] GameObject ShowRewardButton;
    [SerializeField] GameObject ClickedSwitchSkinTypeButt;

    [SerializeField] AudioClip useSkinAudio;

    ProductButtonBase lastClickedProductButton;

    public Action<SkinType, int> SkinChangedAction; 
    public Action<int, int> ColorChangedAction; // first arg - SkinPartNum, second arg - index at list
    private void Start()
    {
        ShowRewardButton.SetActive(false);
    }
    public void OpenShop()
    {
        ColorChangedAction?.Invoke(1, GameSavesController.instance.GameSaves.SkinColorNumber1);
        ColorChangedAction?.Invoke(2, GameSavesController.instance.GameSaves.SkinColorNumber2);
        SkinChangedAction?.Invoke(SkinType.ArrowSkin, GameSavesController.instance.GameSaves.ActiveSkins[SkinType.ArrowSkin]);
        SkinChangedAction?.Invoke(SkinType.UFOSkin, GameSavesController.instance.GameSaves.ActiveSkins[SkinType.UFOSkin]);
        SkinChangedAction?.Invoke(SkinType.ShipSkin, GameSavesController.instance.GameSaves.ActiveSkins[SkinType.ShipSkin]);
        SkinChangedAction?.Invoke(SkinType.CubeSkin, GameSavesController.instance.GameSaves.ActiveSkins[SkinType.CubeSkin]);
       
        if (ClickedSwitchSkinTypeButt != null) OnClickSwitchSkinType(ClickedSwitchSkinTypeButt);
        else Debug.LogWarning("Please, set start switch skin type button");
        if (lastClickedProductButton != null) lastClickedProductButton.OnClick();
    }
    public void SetNewColor(ColorProductButton clickedButton)
    {
        if (lastClickedProductButton != null && !lastClickedProductButton.Purchased()) return;
        ColorChangedAction?.Invoke(clickedButton.ColorNumber, clickedButton.ProductInListNumber); 
        lastClickedProductButton = clickedButton;
        SaveOrShowAdvButton();
    }
    public void SetNewSkin(SkinProductButton clickedButton)
    {
        SkinChangedAction?.Invoke(clickedButton.SkinType, clickedButton.ProductInListNumber);
        lastClickedProductButton = clickedButton;
        SaveOrShowAdvButton();
    }
    void SaveOrShowAdvButton()
    {
        if (lastClickedProductButton.Purchased())
        {
            lastClickedProductButton.Equip();
            ShowRewardButton.SetActive(false);
            soundController.PlaySound(useSkinAudio);
        }
        else
        {
             ShowRewardButton.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameSavesController.instance.ClearSaves();
        }
    }
    public void OnClickBackToMenu()
    {
        GameSavesController.instance.Save();
    }
    public void OnClickShowAdvForProduct()
    {
        advHandler.ShowRewAdv(RewardType.UnlockProduct);
    }
    public void UnlockLastOpenedSkin()
    {
        ShowRewardButton.SetActive(false);
        lastClickedProductButton.Unlock();
    }
    public void OnClickSwitchSkinType(GameObject clickedButtonObj)
    {
        ClickedSwitchSkinTypeButt.transform.SetAsFirstSibling();
        ClickedSwitchSkinTypeButt = clickedButtonObj;
        ClickedSwitchSkinTypeButt.transform.SetAsLastSibling();
    }
}
