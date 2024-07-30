using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] SoundController soundController;

    [SerializeField] Player player;
    [SerializeField] Transform FinishLine;
    [SerializeField] GameObject WinPanel;
    float FinishPosX;
    const float StartPosX = 0;

    [SerializeField] AudioClip winAudio;
    public int Attempts { get; private set; }

    private void Start()
    {
        LevelItem levelItem = GameContainer.Instance.GetLevelItemByIndex(GameContainer.Instance.CurrentLevelIndex);
        Instantiate(levelItem.LevelPrefab, Vector3.zero, Quaternion.identity);
        FinishPosX = levelItem.Length;
        FinishLine.position = new Vector3(FinishPosX, FinishLine.position.y, FinishLine.position.z);
        soundController.SetBGMusic(levelItem.LevelSound);
        WinPanel.SetActive(false);
        player.OnPlayerRestartedAction += PlayerRestarted;
    }
    public void PlayerRestarted()
    {
        int CurrentProgressPercent = GetCurrentProgressPercent();
        if(GameSavesController.instance.GameSaves.LevelsProgresses[GameContainer.Instance.CurrentLevelIndex] < CurrentProgressPercent)
        {
            GameSavesController.instance.GameSaves.LevelsProgresses[GameContainer.Instance.CurrentLevelIndex] = CurrentProgressPercent;
            GameSavesController.instance.Save();
        }
    }
    public void Win()
    {
        soundController.PlaySound(winAudio);
        WinPanel.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(GameConstants.LevelSceneIndex);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(GameConstants.MenuSceneIndexs);
    }
    public int GetCurrentProgressPercent()
    {
        int progressPercent = (int)(GetCurrentProgress() * 100);
        return progressPercent;
    }
    public float GetCurrentProgress()
    {
        float Offset = FinishLine.localScale.x / 2; 
        float progress = (player.transform.position.x - StartPosX) / (FinishPosX - StartPosX  - Offset);
        if (progress > 1) progress = 1;
        return progress;
    }
}
