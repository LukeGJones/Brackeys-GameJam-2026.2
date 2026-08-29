using System.Data.Common;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using UnityEditor.Callbacks;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;
public class player : MonoBehaviour
{
    public float jumpForce = 12;
    public float moveSpeed = 7;
    public bool isDead;
    private bool deathAnimDone;
    public InputAction MoveAction;
    public InputAction JumpAction;
    public FloorDetector floorDetector;
    private Rigidbody2D rb;
    private ParticleSystem deathExplosion;
    private SpriteRenderer sprite;
    private bool audioPlayed;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MoveAction.Enable();
        JumpAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        deathExplosion = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        deathAnimDone = false;
    }
    // Update is called once per frame
    void Update()
    {	
        Move();
        if (JumpAction.WasPressedThisFrame()){
            Jump();
        }
        if(isDead == true)
        {
            if(audioPlayed == false){
                audioSource.PlayOneShot(audioSource.clip, ButtonManager.sfxVolume * 0.25f);
                audioPlayed = true;
            }
            sprite.enabled = false;
            if(deathAnimDone == false){
                deathExplosion.Play();
                deathAnimDone = true;
            }
        }
    }

    void Move()
    {
        if(isDead == true)
        {
            return;
        }
        Vector2 move = MoveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if(floorDetector.isGrounded == false || isDead == true)
        {
            return;
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
