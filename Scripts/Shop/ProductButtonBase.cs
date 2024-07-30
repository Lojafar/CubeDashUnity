using UnityEngine;

public abstract class ProductButtonBase : MonoBehaviour
{
    [SerializeField] ProductType productType;
    [SerializeField]
    public abstract int ProductInListNumber { get; }
    public ProductType ProductType => productType;
    public abstract void OnClick();
    public abstract bool Purchased();
    public abstract void Unlock();
    public abstract void Equip();
    public virtual void UpdateLockImage()
    {
    }
}
