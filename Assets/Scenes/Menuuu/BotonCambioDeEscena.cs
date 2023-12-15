using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCambioDeEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeEscena;

    // Este m�todo se llama cuando se presiona el bot�n
    public void OnBotonPresionado()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(nombreDeEscena);
    }
}
