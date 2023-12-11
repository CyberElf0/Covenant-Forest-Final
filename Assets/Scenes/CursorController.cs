using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Update()
    {
        // Unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
