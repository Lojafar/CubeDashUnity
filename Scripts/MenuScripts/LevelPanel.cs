using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] Button PlayButton;
    [SerializeField] Image ProgressFillArea;
    [SerializeField] TextMeshProUGUI ProgressText;
    [SerializeField] TextMeshProUGUI NameText;
    
    public void SetStartValues(LevelItem levelItem, MenuLevelsController levelsController)
    {
        NameText.text = levelItem.LevelName;
        PlayButton.onClick.AddListener(levelsController.OnClickPlay);

        int Progress = GameSavesController.instance.GameSaves.LevelsProgresses[levelItem.LevelNumber];
        ProgressFillArea.fillAmount = (float)Progress / 100;
        ProgressText.text = Progress.ToString() + "%";
    }
}
