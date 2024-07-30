using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingHandler : MonoBehaviour
{
    private void Awake()
    {
        PortalsCollection.Initialize();
        ExtraEffectsCollection.Initialize();
    }
    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
