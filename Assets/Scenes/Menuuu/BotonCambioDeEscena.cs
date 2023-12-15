using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCambioDeEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeEscena;

    // Este método se llama cuando se presiona el botón
    public void OnBotonPresionado()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(nombreDeEscena);
    }
}
