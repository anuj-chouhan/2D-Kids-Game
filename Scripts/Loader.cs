using UnityEngine.SceneManagement;

public static class Loader
{
    public static scenes scene;
    public enum scenes
    {
        MenuScene,
        MemoryCardGame,
        SpellingGame
    }

    public static void LoadScene(scenes sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}
