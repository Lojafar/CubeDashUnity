using UnityEngine;

public class SkinsPanelController : MonoBehaviour
{
    [SerializeField] SkinType skinType;
    [SerializeField] Transform ButtonsParent;
    [SerializeField] Transform ActiveSkinSelection;
    [SerializeField] ShopController shopController;
    [SerializeField] SkinProductButton skinProductButtonPrefab;
    [SerializeField] SkinProductButton[] spawnedSkinsProductButtons;
    private void OnEnable()
    {
        shopController.SkinChangedAction += UpdateSelectionPositon;
    }
    private void OnDisable()
    {
        shopController.SkinChangedAction -= UpdateSelectionPositon;
    }

    void Start()
    {
        SkinsListScriptObj skinsScriptObj = GameContainer.Instance.GetSkinsListByType(skinType);
        spawnedSkinsProductButtons = new SkinProductButton[skinsScriptObj.Skins.Length];
        for (int i = 0; i < skinsScriptObj.Skins.Length; i++)
        {
            SkinProductButton spawnedProductButton = Instantiate(skinProductButtonPrefab, Vector3.zero, Quaternion.identity, ButtonsParent);
            spawnedProductButton.Initialize(skinType, i, shopController);
            spawnedSkinsProductButtons[i] = spawnedProductButton;
        }
        
    }
    void UpdateSelectionPositon(SkinType skinType, int skinIndex)
    {
        if (skinType != this.skinType) return;
        if (!GameSavesController.instance.GameSaves.Purchasings[skinType][skinIndex]) return;

        ActiveSkinSelection.transform.parent = spawnedSkinsProductButtons[skinIndex].transform; 
        ActiveSkinSelection.transform.localPosition = Vector3.zero; 
    }

}
