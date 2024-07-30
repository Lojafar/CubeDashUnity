using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform playerTransform;
    [SerializeField] PolygonCollider2D playerPolColl;
    [SerializeField] Animator animator;
    [SerializeField] SkinChanger skinChanger;
    [SerializeField] LevelController levelController;
    [SerializeField] SoundController soundController;
    [SerializeField] AudioClip explosionSound;
    public ParticleSystem DashParticles;
    public TrailRenderer BackTrail;
    public ParticleSystem LooseParticles;
    public Transform PlayerTransform => playerTransform;
    public SkinChanger SkinChanger => skinChanger;
    public Rigidbody2D rb { get; private set; }
    [SerializeField] float JumpForceModifier;
    [SerializeField] float speed;
    public float Speed => speed;

    Vector2 startPos;

    bool isRestarting;

    Dictionary<Type, MovableBase> MovableStates = new Dictionary<Type, MovableBase>();
    public MovableBase CurrentMovable { get; private set; }
    public Action OnPlayerRestartedAction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        InitMovableStates();
        soundController.PlayBackGroundMusic();
        Restart();
    }
    void InitMovableStates()
    {
        MovableStates.Add(typeof(CubeMovable), new CubeMovable(this));
        MovableStates.Add(typeof(ShipMovable), new ShipMovable(this));
        MovableStates.Add(typeof(ArrowMovable), new ArrowMovable(this));
        MovableStates.Add(typeof(UFOMovable), new UFOMovable(this));
        SetNewMovableState(typeof(CubeMovable));
    }
    public void SetNewMovableState(Type key )
    {
        if (MovableStates.TryGetValue(key, out MovableBase newMovable))
        {
            if (CurrentMovable != null)
            {
                CurrentMovable.OnFinishUsing();
            }
            CurrentMovable = newMovable;
            CurrentMovable.OnStartUsing();

        }
        else
        {
            Debug.LogWarning("Movable is not setted. Type: " + key);
        }
    }
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);
        if(rb.velocity.x <= 1)
        {
            Loose();
        }
        if (CurrentMovable != null) CurrentMovable.Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Loose();
            return;
        }
        else if (collision.gameObject.tag == "Finish")
        {
            CurrentMovable.OnFinishUsing();
            CurrentMovable = null;
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            isRestarting = true;
            LooseParticles.Play();
            levelController.Win();
        } 
        if (CurrentMovable != null)
        CurrentMovable.OnCollionEnt(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CurrentMovable != null)
            CurrentMovable.OnCollionExt(collision);
    }
    public void Loose()
    {
        if (isRestarting) return;
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
        isRestarting = true;
        animator.SetTrigger("Loose");
        CurrentMovable.OnFinishUsing();
        CurrentMovable = null;
        soundController.StopBackGroundMusic();
        LooseParticles.Play();
        soundController.PlaySound(explosionSound);
        StartCoroutine(RestartRoutine());
    }
    IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Restart();
    }
    public void Restart()
    {
        OnPlayerRestartedAction?.Invoke();
        rb.isKinematic = false;
        transform.position = startPos;
        soundController.PlayBackGroundMusic();
        SetNewMovableState(typeof(CubeMovable));
        isRestarting = false;
    }
    
   
}
