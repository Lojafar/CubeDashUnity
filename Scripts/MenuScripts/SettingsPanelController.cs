using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPanelController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI versionText;
    [SerializeField] Image VolumeSwitcherImage;
    [SerializeField] Sprite soundOnSprite, soundOffSprite;
    bool isSoundOn;
    void Start()
    {
        isSoundOn = GameSavesController.instance.GameSaves.IsSoundOn;
        versionText.text = GameSavesController.version;
        if (isSoundOn)
        {
            AudioListener.volume = 1;
            VolumeSwitcherImage.sprite = soundOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            VolumeSwitcherImage.sprite = soundOffSprite;
        }
    }

    public void OnVolumeSwitcherClick()
    {
        isSoundOn = !isSoundOn;
        if (isSoundOn)
        {
            AudioListener.volume = 1;
            VolumeSwitcherImage.sprite = soundOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            VolumeSwitcherImage.sprite = soundOffSprite;
        }
        GameSavesController.instance.GameSaves.IsSoundOn = isSoundOn;
    }
    public void OnClosePanelClick()
    {
        GameSavesController.instance.Save();
    }
    public void OnClearProgressClick()
    {
        GameSavesController.instance.ClearSaves();
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameConstants.MenuSceneIndexs);
    }
}
