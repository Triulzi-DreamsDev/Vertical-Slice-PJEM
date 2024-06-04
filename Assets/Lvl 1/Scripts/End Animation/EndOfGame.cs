using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : GameCTRL
{
    [SerializeField] GameObject Background;
    [SerializeField] GameObject EstrellaDerecha;
    [SerializeField] GameObject EstrellaIzquierda;
    [SerializeField] GameObject Trofeo;
    [SerializeField] GameObject Erizo;
    [SerializeField] GameObject Particulas;

    public Animator ErizoAn;
    public Animator TrofeoAn;

    bool yaFue;

    void Start()
    {
        ErizoAn = Erizo.GetComponent<Animator>();
        TrofeoAn = Trofeo.GetComponent<Animator>();

        Background.SetActive(false);
        EstrellaDerecha.SetActive(false);
        EstrellaIzquierda.SetActive(false);
        Trofeo.SetActive(false);
        Erizo.SetActive(false);
        Particulas.SetActive(false);

        yaFue = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !yaFue)
        {
            FinDelJuego();
        }

        if (GameCTRL.questState == 2 && !yaFue)
        {
            yaFue = true;
            StartCoroutine(PlayEndSequence());
        }
    }

    public void FinDelJuego()
    {
        GameCTRL.questState = 2;
    }

    IEnumerator PlayEndSequence()
    {
        Erizo.SetActive(true);
        Particulas.SetActive(true);
        yield return new WaitForSeconds(1);

        ErizoAn.SetBool("LlegoErizo", true);
        yield return new WaitForSeconds(2);

        Background.SetActive(true);
        yield return new WaitForSeconds(1);

        EstrellaDerecha.SetActive(true);
        yield return new WaitForSeconds(2);

        EstrellaIzquierda.SetActive(true);
        yield return new WaitForSeconds(2);

        Trofeo.SetActive(true);
        yield return new WaitForSeconds(2);

        TrofeoAn.SetBool("idle", true);
    }

    public void BtnMenu()
    {
        //SceneManager.LoadScene(0);
        Debug.Log("SceneManager.LoadScene(0);");
    }
}