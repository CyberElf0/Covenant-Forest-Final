using UnityEngine;

public class ActivarObjetos : MonoBehaviour
{
    public GameObject[] objetosAActivar; // Array de GameObjects que se activar�n al tocar el collider

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica si el objeto que toc� el collider tiene la etiqueta "Player"
            // Puedes ajustar la etiqueta seg�n la configuraci�n de tu jugador

            // Activa los GameObjects especificados
            foreach (GameObject objeto in objetosAActivar)
            {
                objeto.SetActive(true);
            }

            // Desactiva este GameObject si es necesario
            gameObject.SetActive(false);
        }
    }
}
