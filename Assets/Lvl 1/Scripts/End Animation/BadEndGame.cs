using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndGame : GameCTRL
{
    [SerializeField] GameObject Fade;
    [SerializeField] GameObject BadCinematic;

    // Start is called before the first frame update
    void Start()
    {
        Fade.SetActive(false);
        BadCinematic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PlayBadSequence());
        }
    }

    IEnumerator PlayBadSequence()
    {
        Fade.SetActive(true);
        BadCinematic.SetActive(true);
        yield return new WaitForSeconds(15); // Espera unos segundos
        SceneManager.LoadScene(1);
    }
}
