using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class menuExp : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("menu principal");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        // En el editor, simplemente deten el juego.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // En una ejecución independiente, cierra la aplicación.
        Application.Quit();
#endif
    }
}
