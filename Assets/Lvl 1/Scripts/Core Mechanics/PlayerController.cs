using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameCTRL
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;

    [SerializeField]
    Animator maleAnimator;
    [SerializeField]
    Animator femaleAnimator;

    Animator animator;

    Transform boss;

    private void Start()
    {
        if (esHombre)
        {
            animator = maleAnimator;
        }
        if (!esHombre)
        {
            animator = femaleAnimator;
        }
        
        animator.SetBool("idle", true);
        animator.SetBool("walking", false);
        animator.SetBool("talking", false);
    }

    private void Update()
    {
        boss = GameObject.FindGameObjectWithTag("Player").transform;

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("idle", false);
            animator.SetBool("talking", true);
            animator.SetBool("walking", false);
            if(questState == 2)
            {
                transform.LookAt(boss.transform);
            }
            return;
        }
        GatherInput();
        Look();
        HandleAnimations();
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("idle", false);
            animator.SetBool("talking", true);
            animator.SetBool("walking", false);
            return;
        }
        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }

    private void HandleAnimations()
    {
        if (_input == Vector3.zero && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("idle", true);
            animator.SetBool("walking", false);
            animator.SetBool("talking", false);
        }
        else
        {
            animator.SetBool("idle", false);
            animator.SetBool("walking", true);
            animator.SetBool("talking", false);
        }
    }
}
