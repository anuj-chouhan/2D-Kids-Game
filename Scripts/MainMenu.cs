using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button spellingGame;
    [SerializeField] private Button MemoryCardGame;
    
    private void Start()
    {
        spellingGame.onClick.AddListener(() => Loader.LoadScene(Loader.scenes.SpellingGame));
        MemoryCardGame.onClick.AddListener(() => Loader.LoadScene(Loader.scenes.MemoryCardGame));
    }

}
