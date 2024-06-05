using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndGame : GameCTRL
{
    [SerializeField] GameObject Fade;
    [SerializeField] GameObject BadCinematic;

    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Player;
    [SerializeField] Animator BossA;
    [SerializeField] Animator PlayerA;

    [SerializeField] GameObject tryAgain;
    // Start is called before the first frame update
    void Start()
    {
        Fade.SetActive(false);
        BadCinematic.SetActive(false);
        BossA = Boss.GetComponent<Animator>();
        PlayerA = Player.GetComponent<Animator>();
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
        BadCinematic.SetActive(true);
        tryAgain.SetActive(true);
        yield return new WaitForSeconds(14); // Espera unos segundos
        SceneManager.LoadScene(1);
    }
}