using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
[InitializeOnLoad]
public class Autoloadscene
{
    static string firstScene = "Load"; // Change to your first scene's name

    static Autoloadscene()
    {
        EditorApplication.playModeStateChanged += LoadFirstScene;
    }

    private static void LoadFirstScene(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            if (!Application.isPlaying)
            {
                if (SceneManager.GetActiveScene().name != firstScene)
                {
                    SceneManager.sceneLoaded += OnSceneLoaded;
                    EditorSceneManager.OpenScene("Assets/Scenes/" + firstScene + ".unity");
                }
            }
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
