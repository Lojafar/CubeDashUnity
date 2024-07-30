using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelItem")]
public class LevelItem : ScriptableObject
{
    [SerializeField] string levelName;
    public string LevelName => levelName;
    [SerializeField] int levelNumber;
    public int LevelNumber => levelNumber;
    [SerializeField] float length;
    public float Length => length;

    [SerializeField] GameObject levelPrefab;
    public GameObject LevelPrefab => levelPrefab;

    [SerializeField] AudioClip levelSound;
    public AudioClip LevelSound => levelSound;
}
