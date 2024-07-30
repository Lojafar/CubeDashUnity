using UnityEngine;
[CreateAssetMenu(fileName = "Colors", menuName = "ScriptableObjects/ColorsList")]
public class ColorsListScriptObj : ScriptableObject
{
    [SerializeField] Color[] colors;
    [HideInInspector] public Color[] Colors => colors;
}