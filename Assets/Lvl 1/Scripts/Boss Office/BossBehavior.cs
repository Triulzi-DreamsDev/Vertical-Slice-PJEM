using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehavior : GameCTRL
{
    [SerializeField]
    public bool officeQuest;

    [SerializeField]
    bool goBackOffice;

    int steps;

    NavMeshAgent agent;

    Transform player;
    [SerializeField]
    Transform DestinationPuerta;

    [SerializeField]
    Transform DestnationCajon;

    public bool cajon;

    [SerializeField]
    float distanciaDelPlayer = 5f;

    [SerializeField]
    Animator animator;

    Rigidbody rb;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        officeQuest = false;
        goBackOffice = false;
        steps = 0;
        animator.SetBool("idle", true);
        cajon = false;
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (DialogueManager.GetInstance().dialogueIsPlaying && (questState == 0 || questState == 1))
        {
            transform.LookAt(player);
            animator.SetBool("idle", false);
            animator.SetBool("walking", false);
            animator.SetBool("angry", false);
            animator.SetBool("pointing", false);
            animator.SetBool("talking", true);
            return;
        }

        if (officeQuest)
        {
            //Approach Player
            if (steps == 0)
            {
                ApproachPlayer();

            }

        }
        if (questState == 1)
        {
            goBackOffice = true;
        }
        if (goBackOffice)
        {
            steps = 1;

            if (Vector3.Distance(transform.position, new Vector3(25f, 3.7f, 2.65f)) >= .5)
            {
                Vector3 targetVector = DestinationPuerta.transform.position;
                agent.SetDestination(targetVector);
                transform.LookAt(targetVector);


                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", false);
            }
        }

        if ((questState == 2 || questState == 4) && cajon == false)
        {
            transform.LookAt(new Vector3(-5f, 1.6f, 5.38f));
            if (Vector3.Distance(transform.position, new Vector3(-5.09f, 1.53f, 5.5f)) >= .2)
            {
                transform.position += transform.forward * 2f * Time.deltaTime;

                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", false);
            }
        }
        if (cajon)
        {
            transform.LookAt(player);
            animator.SetBool("idle", false);
            animator.SetBool("walking", false);
            animator.SetBool("angry", false);
            animator.SetBool("pointing", false);
            animator.SetBool("talking", true);
        }
        // Sumar el vector a la velocidad del Rigidbody
        Vector3 additionalVelocity = new Vector3(0, 140, 0);
        rb.velocity += additionalVelocity;
    }

    void ApproachPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) > distanciaDelPlayer)
        {
            Vector3 targetVector = player.transform.position;
            agent.SetDestination(targetVector);
            transform.LookAt(targetVector);

            animator.SetBool("idle", false);
            animator.SetBool("walking", true);
            animator.SetBool("angry", false);
            animator.SetBool("pointing", false);
            animator.SetBool("talking", false);
        } else if (Vector3.Distance(transform.position, player.position) <= distanciaDelPlayer)
        {
            animator.SetBool("idle", true);
            animator.SetBool("walking", false);
            animator.SetBool("angry", false);
            animator.SetBool("pointing", false);
            animator.SetBool("talking", false);
        }

    }
}
