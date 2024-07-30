using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] SpriteRenderer skinRenderer1, skinRenderer2;

    private void Start()
    {
        skinRenderer1.color = GameContainer.Instance.ColorListSO.Colors[GameSavesController.instance.GameSaves.SkinColorNumber1];
        skinRenderer2.color = GameContainer.Instance.ColorListSO.Colors[GameSavesController.instance.GameSaves.SkinColorNumber2];
        SetNewSkin(SkinType.CubeSkin);
    }
    public void SetNewSkin(SkinType skinType)
    {
        PlayerSkin newSkin = GameContainer.Instance.GetSkinsListByType(skinType).Skins[GameSavesController.instance.GameSaves.ActiveSkins[skinType]];
        skinRenderer1.sprite = newSkin.sprite1;
        skinRenderer2.sprite = newSkin.sprite2;
    }
}
