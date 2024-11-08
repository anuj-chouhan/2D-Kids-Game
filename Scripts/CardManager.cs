using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    private Card firstFlippedCard;
    private Card secondFlippedCard;
    [HideInInspector] public bool isChecking;

    public static CardManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Singleton Error Here");
        }

        instance = this;

        mainMenuButton.onClick.AddListener(() => Loader.LoadScene(Loader.scenes.MenuScene));
    }

    public void OnCardFlipped(Card card) //Public as memory card uses it
    {
        if (!isChecking)
        {
            if (firstFlippedCard == null)
            {
                firstFlippedCard = card;
            }
            else if (secondFlippedCard == null)
            {
                secondFlippedCard = card;
                StartCoroutine(CheckMatch());
            }
        }
    }
    private IEnumerator CheckMatch()
    {
        isChecking = true;

        yield return new WaitForSeconds(1f);

        if (firstFlippedCard.frontImage == secondFlippedCard.frontImage)
        {
            //Making Buttons Uninteractable
            firstFlippedCard.GetComponent<Button>().interactable = false;
            secondFlippedCard.GetComponent<Button>().interactable = false;

            //Changing buttons color to black
            firstFlippedCard.GetComponent<Image>().color = Color.black;
            secondFlippedCard.GetComponent<Image>().color = Color.black;
        }
        else
        {
            // No match, flip back
            firstFlippedCard.ShowBack();
            secondFlippedCard.ShowBack();
        }

        firstFlippedCard = null;
        secondFlippedCard = null;

        isChecking = false;
    }
}
