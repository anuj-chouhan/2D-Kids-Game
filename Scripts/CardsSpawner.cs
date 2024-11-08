using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Sprite[] images;
    private List<Sprite> cardImages;

    private void Start()
    {
        SetupCards();
    }

    private void SetupCards()
    {
        cardImages = new List<Sprite>(images);
        cardImages.AddRange(images); // Duplicate images for pairs
        cardImages = cardImages.OrderBy(x => Random.value).ToList(); // Shuffle

        for (int i = 0; i < cardImages.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, transform);
            Card memoryCard = card.GetComponent<Card>();
            memoryCard.frontImage = cardImages[i];
        }
    }

}
