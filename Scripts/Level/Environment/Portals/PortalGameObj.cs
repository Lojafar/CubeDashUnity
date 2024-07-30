using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGameObj : MonoBehaviour
{
    [SerializeField] PortalType portalType;
    IPortal Portal;
    void Start()
    {
        Portal = PortalsCollection.GetPortalCache(portalType);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            Portal.OnPlayerEnter(player);
        }
    }
}
