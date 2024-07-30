using UnityEngine;
using UnityEngine.UI;

public class ColorProductButton : ProductButtonBase
{
    ShopController shopController;
    [SerializeField] Button buttonComponent;
    [SerializeField] Image ColorImage;
    int colorInListNumber;
    int colorNumber;

    public override int ProductInListNumber => colorInListNumber;
    public int ColorNumber => colorNumber;


    public void Initialize(int colorNumber, int productInListNumber, ShopController shopController)
    {
        if (productInListNumber < 0)
        {
            Debug.LogWarning("Color index cannot be less than 0. Index is " + productInListNumber.ToString() + ". ColorType: " + colorNumber);
            productInListNumber = 0;
        }
        this.colorInListNumber = productInListNumber;
        this.colorNumber = colorNumber;
        ColorImage.color = GameContainer.Instance.ColorListSO.Colors[ProductInListNumber];
        this.shopController = shopController;
        buttonComponent.onClick.AddListener(OnClick);

        UpdateLockImage();
    }
    public override void OnClick()
    {
        shopController.SetNewColor(this);
    }

    public override bool Purchased()
    {
        return true;
    }
    public override void Unlock() {}
    public override void Equip()
    {
        if (ColorNumber == 1)
        {
            GameSavesController.instance.GameSaves.SkinColorNumber1 = ProductInListNumber;
        }
        else
        {
            GameSavesController.instance.GameSaves.SkinColorNumber2 = ProductInListNumber;
        }
    }
}
