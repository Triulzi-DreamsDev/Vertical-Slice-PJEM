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

    public bool cajon;

    [SerializeField]
    float distanciaDelPlayer = 5f;

    [SerializeField]
    Animator animator;

    Rigidbody rb;
    Transform tr;
    // Start is called before the first frame update

    public bool centro;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        officeQuest = false;
        goBackOffice = false;
        steps = 0;
        animator.SetBool("idle", true);
        cajon = false;
        centro = false;
        rb = this.GetComponent<Rigidbody>();
        tr = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (DialogueManager.GetInstance().dialogueIsPlaying && (questState == 0 || questState == 1))
        {
            // Asegúrate de que el jefe mire al jugador mientras habla
            transform.LookAt(player.position);
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
                Vector3 lookAtPosition = new Vector3(targetVector.x, transform.position.y, targetVector.z); // Mantiene la misma altura
                transform.LookAt(lookAtPosition);

                agent.SetDestination(targetVector);

                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", false);
            }
        }

        if ((questState == 2 || questState == 4) && cajon == false)
        {
            transform.LookAt(new Vector3(-2.74f, 1.25f, 4.66f));
            if (Vector3.Distance(transform.position, new Vector3(-2.74f, 1.25f, 4.66f)) >= 1.7)
            {
                transform.position += transform.forward * 2f * Time.deltaTime;

                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", false);
            } else if (Vector3.Distance(transform.position, new Vector3(-2.74f, 1.25f, 4.66f)) < 2)
            {
                animator.SetBool("idle", false);
                animator.SetBool("walking", false);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", true);
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
        }
        else if (Vector3.Distance(transform.position, player.position) <= distanciaDelPlayer)
        {
            transform.LookAt(player);
            animator.SetBool("idle", true);
            animator.SetBool("walking", false);
            animator.SetBool("angry", false);
            animator.SetBool("pointing", false);
            animator.SetBool("talking", false);
        }
    }
}
