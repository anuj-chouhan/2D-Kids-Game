using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite backImage;
    [HideInInspector] public Sprite frontImage;
    private bool isFlipped = false;

    [Header("Private Variables")]
    [ReadOnly][SerializeField] private Image _cardImage;
    [ReadOnly][SerializeField] private Animator _memoryCardAnimator;
    [ReadOnly][SerializeField] private string _parametreAnimator = "TriggerAnimation";
    private void OnValidate()
    {
        _memoryCardAnimator = GetComponent<Animator>();
        _cardImage = GetComponent<Image>();
    }
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnCardClicked);
        ShowBackButDontPlayAnimation();
    }

    private void OnCardClicked()
    {
        if (!CardManager.instance.isChecking)
        {
            if (!isFlipped)
            {
                ShowFront();
                CardManager.instance.OnCardFlipped(this);
            }
        }
    }

    private void ShowFront()
    {
        isFlipped = true;
        _memoryCardAnimator.SetTrigger(_parametreAnimator);
    }

    public void ShowBack()//Public As Game Manager Uses It
    {
        isFlipped = false;
        _memoryCardAnimator.SetTrigger(_parametreAnimator);
    }

    private void ShowBackButDontPlayAnimation()
    {
        isFlipped = false;
        _cardImage.sprite = backImage;
    }

    public void ShowFruitImage()
    {
        if (isFlipped)
        {
            _cardImage.sprite = frontImage;
        }
        else
        {
            _cardImage.sprite = backImage;
        }
    }

}