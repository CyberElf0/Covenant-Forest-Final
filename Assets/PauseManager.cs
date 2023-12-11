using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject inventoryMenu; // Asigna el objeto del menú de inventario desde el Inspector
    public GameObject otherCanvas1; // Agrega referencia al otro Canvas 1 desde el Inspector
    public GameObject otherCanvas2; // Agrega referencia al otro Canvas 2 desde el Inspector

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; // Pausa el tiempo
            inventoryMenu.SetActive(true); // Activa el menú de inventario al pausar el juego

            // Desactiva otros Canvas
            if (otherCanvas1 != null)
                otherCanvas1.SetActive(false);

            if (otherCanvas2 != null)
                otherCanvas2.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f; // Reanuda el tiempo
            inventoryMenu.SetActive(false); // Desactiva el menú de inventario al reanudar el juego

            // Activa otros Canvas si es necesario
            if (otherCanvas1 != null)
                otherCanvas1.SetActive(true);

            if (otherCanvas2 != null)
                otherCanvas2.SetActive(true);
        }
    }
}
