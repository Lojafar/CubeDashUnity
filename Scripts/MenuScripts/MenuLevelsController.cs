using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevelsController : MonoBehaviour
{
    [SerializeField] LevelPanel levelPanelPrefab;

    [SerializeField] Button NextLevelButton;
    [SerializeField] Button PeviousLevelButton;
    [SerializeField] RectTransform lvlsGroup;
    [SerializeField] int lengthBetweenLvlPanels;
    [SerializeField] int MovementSpeed;
    int currenLevel;
    int currentLvlPanelsPosition;
    int neededLvlPanelsPosition;

    bool isPanelsSetted;
    private void Start()
    {
        lvlsGroup.localPosition = new Vector3(0, lvlsGroup.localPosition.y, lvlsGroup.localPosition.z);
    }
    public void OpenLevelsPanels()
    {
        if (!isPanelsSetted)
        {
            for (int i = 0; i < GameContainer.Instance.LevelsCount; i++)
            {
                LevelPanel levelPanel = Instantiate(levelPanelPrefab, Vector3.zero, Quaternion.identity, lvlsGroup);
                levelPanel.SetStartValues(GameContainer.Instance.GetLevelItemByIndex(i), this);
            }

            isPanelsSetted = true;
        }
        SetInteractableToMoveButts();
    }
    public void NextLevel()
    {
        currenLevel++;
        neededLvlPanelsPosition = -currenLevel * lengthBetweenLvlPanels;
        StartCoroutine(MoveLvlsPanelRoutine(-1));
        SetInteractableToMoveButts();
    }
    public void PeviousLevel()
    {
        currenLevel--;
        neededLvlPanelsPosition = -currenLevel * lengthBetweenLvlPanels;
        StartCoroutine(MoveLvlsPanelRoutine(1));
        SetInteractableToMoveButts();
    }
    void SetInteractableToMoveButts()
    {
        if (currenLevel == GameContainer.Instance.LevelsCount - 1) NextLevelButton.interactable = false;
        else NextLevelButton.interactable = true;
        if (currenLevel == 0) PeviousLevelButton.interactable = false;
        else PeviousLevelButton.interactable = true;
    }
    IEnumerator MoveLvlsPanelRoutine(int direction)
    {
        int dirWithMovement = direction * MovementSpeed;
        while(currentLvlPanelsPosition != neededLvlPanelsPosition)
        {
            currentLvlPanelsPosition += dirWithMovement;
            if (direction == 1 && currentLvlPanelsPosition > neededLvlPanelsPosition || direction == -1 && currentLvlPanelsPosition < neededLvlPanelsPosition)
            {
                currentLvlPanelsPosition = neededLvlPanelsPosition;
            }
            yield return new WaitForSeconds(0.001f);
            lvlsGroup.localPosition = new Vector3(currentLvlPanelsPosition, lvlsGroup.localPosition.y, lvlsGroup.localPosition.z);
        }
    }
    public void OnClickPlay()
    {
        GameContainer.Instance.CurrentLevelIndex = currenLevel;
        SceneManager.LoadScene(GameConstants.LevelSceneIndex);
    }
}
