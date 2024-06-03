using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManagerChoices : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    public bool isDialoguePaused { get; private set; }
    private string savedStoryState;

    // Flags for actions
    private bool action1Completed = false;
    private bool action2Completed = false;

    private static DialogueManagerChoices instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManagerChoices GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        isDialoguePaused = false;
        dialoguePanel.SetActive(false);

        // Get all of the choices text 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        // Return right away if dialogue isn't playing or is paused
        if (!dialogueIsPlaying || isDialoguePaused)
        {
            return;
        }

        // Handle continuing to the next line in the dialogue when submit is pressed
        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.Space)) // Space to continue Dialogue
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // Set text for the current dialogue line
            string text = currentStory.Continue();
            if (text.Contains("<< PAUSA DIALOGO >>"))
            {
                text = text.Replace("<< PAUSA DIALOGO >>", "");
                dialogueText.text = text;
                PauseDialogue();
            }
            else
            {
                dialogueText.text = text;
                // Display choices, if any, for this dialogue line
                DisplayChoices();
            }
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // Defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // Enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // Go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    public void PauseDialogue()
    {
        isDialoguePaused = true;
        dialogueIsPlaying = false;
        if (currentStory != null)
        {
            savedStoryState = currentStory.state.ToJson();
            dialoguePanel.SetActive(false);
            foreach (GameObject choice in choices)
            {
                choice.SetActive(false);
            }
        }
    }

    public void ResumeDialogue()
    {
        // Check if the required actions have been completed before resuming
        if (action1Completed && action2Completed)
        {
            isDialoguePaused = false;
            dialogueIsPlaying = true;
            if (!string.IsNullOrEmpty(savedStoryState) && currentStory != null)
            {
                currentStory.state.LoadJson(savedStoryState);
                dialoguePanel.SetActive(true);
                ContinueStory();
            }
        }
        else
        {
            // If actions are not completed, repeat the last dialogue
            if (!string.IsNullOrEmpty(savedStoryState) && currentStory != null)
            {
                currentStory.state.LoadJson(savedStoryState);
                dialogueText.text = currentStory.Continue();
            }
        }
    }

    public void CompleteAction1()
    {
        action1Completed = true;
        ResumeDialogue();
    }

    public void CompleteAction2()
    {
        action2Completed = true;
        ResumeDialogue();
    }
}

