using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class SpellingGameManager : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private WordSlot[] bearSlots;
    [SerializeField] private WordSlot[] iceSlots;
    [SerializeField] private WordSlot[] rockSlots;

    [ReadOnly][Required] public Canvas canvas;
    public static SpellingGameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Singleton Error Here");
            return;
        }

        instance = this;

        mainMenuButton.onClick.AddListener(() => Loader.LoadScene(Loader.scenes.MenuScene));
    }

    private void CheckSpelling(WordSlot[] slots)
    {
        int wordCount = 0;
        int countCorrectWords = 0;


        foreach (var slot in slots)
        {
            if (slot.isWordPlaced)
            {
                wordCount++;
            }
        }

        if (wordCount == slots.Length)
        {
            // All words placed correctly, make words uninteractable
            foreach (var slot in slots)
            {
                if (!slot.isPlacedWordRight)
                {
                    foreach (var slot2 in slots)
                    {
                        slot2.ResetPlacedWord();
                        wordCount = 0;
                    }
                }

                if (slot.isPlacedWordRight)
                {
                    countCorrectWords++;

                    if (countCorrectWords == slots.Length)
                    {
                        foreach (var slot2 in slots)
                        {
                            slot2.MakeWordUninteractable();
                        }
                    }
                }
            }
        }
    }

    private void Update()
    {
        CheckSpelling(bearSlots);
        CheckSpelling(iceSlots);
        CheckSpelling(rockSlots);
    }
}
