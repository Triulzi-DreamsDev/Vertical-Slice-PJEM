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
    float distanciaDelPlayer = 5f;

    [SerializeField]
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        officeQuest = false;
        goBackOffice = false;
        steps = 0;
        animator.SetBool("idle", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (DialogueManager.GetInstance().dialogueIsPlaying)
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
           

            //agent.SetDestination(new Vector3(9.54f, 2.63f, 2.76f));

            transform.LookAt(new Vector3(25f, 3.5f, 2.65f));
            if (Vector3.Distance(transform.position, new Vector3(25f, 3.7f, 2.65f)) >= .5)
            {
               transform.position += transform.forward * 2f * Time.deltaTime;
               

                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("angry", false);
                animator.SetBool("pointing", false);
                animator.SetBool("talking", false);
            }
        }

    }

    

    void ApproachPlayer()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= distanciaDelPlayer)
        {
            transform.position += transform.forward * 2f * Time.deltaTime;
           // agent.SetDestination(player.position);

            animator.SetBool("idle", false);
            animator.SetBool("walking", true);
            animator.SetBool("angry", false);
            animator.SetBool("pointing", false);
            animator.SetBool("talking", false);
        }

    }

}
