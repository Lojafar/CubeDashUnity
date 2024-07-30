using UnityEngine;
[CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/SkinsList")]
public class SkinsListScriptObj : ScriptableObject
{
   [SerializeField] PlayerSkin[] skins;
   [HideInInspector] public PlayerSkin[] Skins => skins;
}
