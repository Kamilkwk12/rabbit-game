using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Kuba : MonoBehaviour
{
    public enum KubaDialogueType
    {
        Start = 0, 
        Idle = 1,
        Quest = 2,
        QuestCompleted = 3,
        Agressive = 4,
        End = 5,
    }


    [SerializeField] private float typingSpeed;

    private UIDocument computerUI;
    private VisualElement kubaUi;
    private QuestManager questManager;
    public KubaDialogues[] kubaDialogues;


    private void Start()
    {
        computerUI = GameObject.FindGameObjectWithTag("ComputerUI").GetComponent<UIDocument>();
        kubaUi = computerUI.rootVisualElement.Q("Kuba");
        questManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
        StartCoroutine(TypeLine(KubaDialogueType.Start, 0));
    }

    public IEnumerator TypeLine(KubaDialogueType type, int dialogueIndex)
    {
        kubaUi.Q<Label>("Dialogue").text = "";

        if (type == KubaDialogueType.QuestCompleted)
        {
            string[] dialogues = questManager.currentQuest.kubaDialogueLines;

            foreach (char letter in dialogues[dialogueIndex])
            {
                kubaUi.Q<Label>("Dialogue").text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

        }

        foreach (char letter in kubaDialogues[((int)type)].DialogueLines[dialogueIndex])
        {
            kubaUi.Q<Label>("Dialogue").text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
