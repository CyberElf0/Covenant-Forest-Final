using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameOver : MonoBehaviour
{
    public static string lastLevel = "";
    public void VolverAlMenuDeInicio()
    {
        SceneManager.LoadScene("menu principal"); // Carga la escena del menú de inicio
    }

    public void Retry()
    {
        SceneManager.LoadScene(lastLevel); // Carga la escena del menú de inicio
    }


    public void SalirDelJuego()
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
