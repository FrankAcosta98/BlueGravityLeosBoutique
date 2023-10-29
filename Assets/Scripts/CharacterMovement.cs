using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterMovement : MonoBehaviour
{

    [Header("Movement Options")]
    private Rigidbody2D rigidboby;
    private Vector2 move;
    [HideInInspector]
    public bool canMove = true;
    public bool Talk = false;
    private GameObject interactuableObject;
    [SerializeField]
    private float speed = 20.0f;

    [Header("Animation Options")]
    public Animator[] PlayerAnimators;
    private string clipName;
    void Awake()
    {
        rigidboby = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (canMove)
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
        }
        if (move.y == 0 && move.x == 0)
            clipName = "Idle";
        else if (move.y < 0)
            clipName = "WalkDown";
        else
        {
            if (move.x < 0)
                clipName = "WalkLeft";
            else if (move.x > 0)
                clipName = "WalkRight";
            else if (move.x == 0 && move.y > 0)
                clipName = "WalkUp";
        }
        foreach (var PlayerAnimator in PlayerAnimators)
        {
            PlayerAnimator.Play(clipName);
        }
        if (Input.GetKeyDown(KeyCode.E)&& Talk&& canMove)
        {
            canMove = false;
            interactuableObject.GetComponent<interactuableObject>().Exectute();
        }
    }
    void FixedUpdate()
    {
        move = Vector2.ClampMagnitude(move, 1f);
        rigidboby.velocity = new Vector2(move.x * speed, move.y * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "interactuable")
        {
            Talk = true;
            interactuableObject = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Talk = false;
        interactuableObject = null;
    }
}
