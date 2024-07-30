using UnityEngine;

public class EffectSphere : MonoBehaviour
{
    [SerializeField] ExtraEffectType effectType;
    [SerializeField] Animator animator;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            if (collision.gameObject.TryGetComponent<Player>(out Player player))
            {
                ExtraEffectsCollection.GetExtraEffectCache(effectType).Use(player);
                animator.SetTrigger("use");
            }
        }
    } 
}