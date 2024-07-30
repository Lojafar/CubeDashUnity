using UnityEngine;
using UnityEngine.UI;

public class SkinProductButton : ProductButtonBase
{
    ShopController shopController;
    [SerializeField] Button buttonComponent;
    [SerializeField] Image SkinPart1, SkinPart2;
    [SerializeField] GameObject LockImageGameObj;


    int skinInListNumber;
    SkinType skinType;
    public SkinType SkinType => skinType;

    public override int ProductInListNumber => skinInListNumber;
    public void Initialize(SkinType skinType, int productInListNumber, ShopController shopController)
    {
        this.skinType = skinType;
        if (productInListNumber < 0)
        {
            Debug.LogWarning("Skin index cannot be less than 0. Index is " + productInListNumber.ToString() + ". SkinType: " + productInListNumber);
            productInListNumber = 0;
        }
        skinInListNumber = productInListNumber;
        buttonComponent.onClick.AddListener(OnClick);
        this.shopController = shopController;
        SkinsListScriptObj skinsList = GameContainer.Instance.GetSkinsListByType(skinType);
        SkinPart1.sprite = skinsList.Skins[skinInListNumber].sprite1;
        SkinPart2.sprite = skinsList.Skins[skinInListNumber].sprite2;
        UpdateLockImage();
    }
    public override void OnClick()
    {
        shopController.SetNewSkin(this);
    }
    public override bool Purchased()
    {
        return GameSavesController.instance.GameSaves.Purchasings[SkinType][ProductInListNumber];
    }

    public override void Unlock()
    {
        GameSavesController.instance.GameSaves.Purchasings[SkinType][ProductInListNumber] = true;
        UpdateLockImage();
    }
    public override void Equip()
    {
        GameSavesController.instance.GameSaves.ActiveSkins[SkinType] = ProductInListNumber;
    }
    public override void UpdateLockImage()
    {
        LockImageGameObj.SetActive(!Purchased());
    }
}
