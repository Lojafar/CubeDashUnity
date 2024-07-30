using UnityEngine;
using UnityEngine.UI;

public class ShopSkinChanger : MonoBehaviour
{
    [SerializeField] ShopController shopController;
    [SerializeField] Image playerImage1, playerImage2;
   
    private void OnEnable()
    {
        shopController.SkinChangedAction += SetNewSkin;
        shopController.ColorChangedAction += SetNewColor;
    }
    private void OnDisable()
    {
        shopController.SkinChangedAction -= SetNewSkin;
        shopController.ColorChangedAction -= SetNewColor;
    }
    public void SetNewColor(int colorNumber, int colorIndex)
    {
        Color newColor = GameContainer.Instance.ColorListSO.Colors[colorIndex];
        if (colorNumber == 1)
        {
            playerImage1.color = newColor;
        }
        else
        {
            playerImage2.color = newColor;
        }
    }
    public void SetNewSkin(SkinType skinType, int skinIndex)
    {
        PlayerSkin skin = GameContainer.Instance.GetSkinsListByType(skinType).Skins[skinIndex];
        playerImage1.sprite = skin.sprite1;
        playerImage2.sprite = skin.sprite2;
    }
}
