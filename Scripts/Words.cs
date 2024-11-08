using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Words : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public Alphabets word;

    [ReadOnly][SerializeField][Required] private RectTransform RectTransform;
    [ReadOnly][SerializeField][Required] private CanvasGroup canvasGroup;

    public enum Alphabets
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
    }

    private Canvas _canvas;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void OnValidate()
    {
        RectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvas = SpellingGameManager.instance.canvas;
        _startPosition = RectTransform.position;  // Save the starting position
        _startRotation = RectTransform.rotation;
    }

    public void ResetWordToItsPosition()
    {
        StartCoroutine(ResetDelayed());
    }

    IEnumerator ResetDelayed()
    {
        yield return new WaitForSeconds(1f);
        RectTransform.position = _startPosition;  // Reset to initial position
        RectTransform.rotation = _startRotation;
        GetComponent<Image>().raycastTarget = true;
    }

    public void MakeWordUninteractable()
    {
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
