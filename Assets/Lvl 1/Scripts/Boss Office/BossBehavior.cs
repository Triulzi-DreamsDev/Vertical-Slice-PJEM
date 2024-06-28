using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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

    [SerializeField]
    GameObject pb;

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
            if (Vector3.Distance(transform.position, player.position) <= distanciaDelPlayer && !isMessageActive)
            {
                // Asegurate de que el jefe mire al jugador mientras habla
                transform.LookAt(player.position);
                animator.SetBool("idle", false);
                animator.SetBool("walking", false);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", true);
                return;
            }
            
        }
        string Scene = Application.loadedLevelName;

     /*--------------------*/ if (SeFueJefe && Scene=="Vertical Slice")/*--------------------*/
        {
                pb.SetActive(false);
        }

        if (officeQuest)
        {
            //Approach Player
            if (steps == 0)
            {
                ApproachPlayer();
            }
        }

        if (questState == 1 && Input.GetKeyDown(KeyCode.Return))
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
            Vector3 targetVector = DestnationCajon.transform.position;
            transform.LookAt(new Vector3(-2.74f, 1.25f, 4.66f));
            if (Vector3.Distance(transform.position, DestnationCajon.position) >= 2)
            {
                agent.SetDestination(targetVector);

                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", false);
            } else if (Vector3.Distance(transform.position, DestnationCajon.position) < 2)
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
