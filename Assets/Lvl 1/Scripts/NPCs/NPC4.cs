using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4 : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            animator.SetBool("walk", false);
            animator.SetBool("talk", true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            animator.SetBool("walk", true);
            animator.SetBool("talk", false);
        }
    }
}
