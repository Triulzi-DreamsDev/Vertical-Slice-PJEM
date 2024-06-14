using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndGame : GameCTRL
{
    [SerializeField] GameObject Fade;
    [SerializeField] GameObject BadCinematic;

    [SerializeField] Animator BossA;
    [SerializeField] Animator PlayerA;

    [SerializeField] GameObject PlayerB;
    [SerializeField] GameObject tryAgain;
    // Start is called before the first frame update
    void Start()
    {
        Fade.SetActive(false);
        BadCinematic.SetActive(false);
        BossA = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        PlayerA = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        tryAgain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (questState == 5)
        {
            StartCoroutine(PlayBadSequence());
        }
    }

    IEnumerator PlayBadSequence()
    {
        Fade.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        PlayerB.SetActive(true);
        BadCinematic.SetActive(true);
        tryAgain.SetActive(true);
        yield return new WaitForSeconds(14); // Espera unos segundos
        SceneManager.LoadScene(1);
    }
}
