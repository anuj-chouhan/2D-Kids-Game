using UnityEngine;
using UnityEngine.EventSystems;

public class WordSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Words.Alphabets requiredWord;  // Use the enum from Words script
    [HideInInspector] public bool isWordPlaced;
    [HideInInspector] public bool isPlacedWordRight;

    private Words placedWord;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var wordComponent = eventData.pointerDrag.GetComponent<Words>();

            if (!isWordPlaced)
            {
                if (wordComponent != null)
                {
                    RectTransform draggedWordRect = eventData.pointerDrag.GetComponent<RectTransform>();
                    draggedWordRect.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    draggedWordRect.rotation = Quaternion.Euler(Vector3.zero);


                    placedWord = wordComponent;
                    isWordPlaced = true;
                    placedWord.MakeWordUninteractable();

                    // Check if placed word matches the slot
                    isPlacedWordRight = wordComponent.word == requiredWord;
                }
            }
        }
    }

    public void ResetPlacedWord()
    {
        if (placedWord != null)
        {
            placedWord.ResetWordToItsPosition();
            placedWord = null;
        }

        isWordPlaced = false;
        isPlacedWordRight = false;
    }

    public void MakeWordUninteractable()
    {
        if (placedWord != null)
        {
            placedWord.MakeWordUninteractable();
            placedWord = null;
        }

        isWordPlaced = false;
    }
}
