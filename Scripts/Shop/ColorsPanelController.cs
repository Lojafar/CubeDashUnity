using UnityEngine;
public class ColorsPanelController : MonoBehaviour
{
    [SerializeField] int ColorNumber;
    [SerializeField] Transform ButtonsParent;
    [SerializeField] Transform ActiveColorSelection;
    [SerializeField] ShopController shopController;
    [SerializeField] ColorProductButton colorProductButtonPrefab;
    [SerializeField] ColorProductButton[] spawnedColorProductButtons;
    private void OnEnable()
    {
        shopController.ColorChangedAction += UpdateSelectionPositon;
    }
    private void OnDisable()
    {
        shopController.ColorChangedAction -= UpdateSelectionPositon;
    }

    void Start()
    {
        ColorsListScriptObj skinsScriptObj = GameContainer.Instance.ColorListSO;
        spawnedColorProductButtons = new ColorProductButton[skinsScriptObj.Colors.Length];
        for (int i = 0; i < skinsScriptObj.Colors.Length; i++)
        {
            ColorProductButton spawnedProductButton = Instantiate(colorProductButtonPrefab, Vector3.zero, Quaternion.identity, ButtonsParent);
            spawnedProductButton.Initialize(ColorNumber, i, shopController);
            spawnedColorProductButtons[i] = spawnedProductButton;
        }

    }
    void UpdateSelectionPositon(int colorNumber, int colorIndex)
    {
        if (colorNumber != ColorNumber) return;

        ActiveColorSelection.transform.parent = spawnedColorProductButtons[colorIndex].transform;
        ActiveColorSelection.transform.localPosition = Vector3.zero;
    }
}
