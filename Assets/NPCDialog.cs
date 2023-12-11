using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class NPCDialog : MonoBehaviour
{
    public string dialogText = "�Hola! Soy un NPC."; // Texto que se mostrar�
    public GameObject textUI;
    public TextMeshProUGUI dialogUI; // Referencia al objeto de TextMeshPro en la UI
    public float letterDelay = 0.05f; // Retardo entre cada letra
    public float displayDuration = 3f; // Duraci�n que se muestra el texto antes de desactivarse
    public string nextSceneName = "NombreDeLaSiguienteEscena"; // Nombre editable de la pr�xima escena

    private bool isPlayerInRange = false;

    void Update()
    {
        // Verifica si el jugador est� cerca
        if (isPlayerInRange)
        {
            // Verifica si el jugador presiona la tecla "E"
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(ShowDialogLetterByLetter());
            }
        }
    }

    // M�todo para mostrar el cuadro de texto en la UI letra por letra
    IEnumerator ShowDialogLetterByLetter()
    {
        textUI.SetActive(true);
        dialogUI.text = "";

        // Recorre cada letra en el texto
        for (int i = 0; i < dialogText.Length; i++)
        {
            // Agrega la letra actual al texto
            dialogUI.text += dialogText[i];

            // Espera un breve tiempo antes de mostrar la siguiente letra
            yield return new WaitForSeconds(letterDelay);
        }

        // Espera durante la duraci�n especificada antes de desactivar el texto
        yield return new WaitForSeconds(displayDuration);

        // Desactiva el cuadro de texto despu�s de la espera
        textUI.SetActive(false);

        // Cambia a la siguiente escena
        ChangeScene();
    }

    // M�todo para cambiar a la siguiente escena
    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Cuando el jugador entra en el �rea del NPC
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // Cuando el jugador sale del �rea del NPC
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Limpia el texto cuando el jugador se aleja
            dialogUI.text = "";
        }
    }
}
