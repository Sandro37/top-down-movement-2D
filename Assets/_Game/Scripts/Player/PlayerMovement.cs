using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D rig;
    private Vector2 moveInput;
    private Animator anim;
    private float moveX;
    private float moveY;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        SetAnimation();
    }
    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + speed * Time.fixedDeltaTime * moveInput);
    }
    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    private void SetAnimation()
    {
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
    }
}
