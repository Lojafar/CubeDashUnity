using UnityEngine;

public class EffectPanel : MonoBehaviour
{
    [SerializeField] ExtraEffectType effectType;
    [SerializeField] Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            ExtraEffectsCollection.GetExtraEffectCache(effectType).Use(player);
            animator.SetTrigger("use");
        }
    }
}
