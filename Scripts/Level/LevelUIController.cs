using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    [SerializeField] Player player;
    [Space(10)]
    [SerializeField] Image LevelProgressBar;
    [SerializeField] TextMeshProUGUI LevelProgressText;
    [SerializeField] TextMeshPro AttemptsText;
    void Start()
    {
        player.OnPlayerRestartedAction += UpdateAttemptsText;
    }

    void LateUpdate()
    {
        LevelProgressBar.fillAmount = levelController.GetCurrentProgress();
        LevelProgressText.text = levelController.GetCurrentProgressPercent() + "%";
    }
    void UpdateAttemptsText()
    {
        AttemptsText.text = TranslatorForSomeStrings.GetStringByKey(1) + ":" + levelController.Attempts.ToString();
    }
}
