using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealthAndMana : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxMana = 100;
    private int currentHealth;
    private float currentMana;
    private bool isInvulnerable = false;
    private bool isInvulnerabilityActive = false;

    public int manaCostPerSecond = 10;
    public int manaRegenPerSecond = 2;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;

    public GameObject[] playerMeshes; // Array que contiene los mesh del jugador
    public GameObject invulnerabilityEffect; // GameObject que se activará durante la invulnerabilidad

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentMana >= manaCostPerSecond)
        {
            isInvulnerabilityActive = true;
            isInvulnerable = true;

            // Activar el efecto de invulnerabilidad
            if (invulnerabilityEffect != null)
            {
                invulnerabilityEffect.SetActive(true);
            }

            // Desactivar los mesh del jugador
            foreach (GameObject mesh in playerMeshes)
            {
                mesh.SetActive(false);
            }

            // Programar la reactivación de los mesh después de 0.5 segundos
            Invoke("ReactivateMeshes", 0.5f);
        }

        if (Input.GetKeyUp(KeyCode.Space) || currentMana < manaCostPerSecond)
        {
            isInvulnerabilityActive = false;
            isInvulnerable = false;

            // Desactivar el efecto de invulnerabilidad
            if (invulnerabilityEffect != null)
            {
                invulnerabilityEffect.SetActive(false);
            }
        }

        if (isInvulnerabilityActive)
        {
            currentMana -= (manaCostPerSecond * Time.deltaTime);
        }
        else
        {
            RegenerateManaOverTime();
        }

        UpdateUI();
    }

    void ReactivateMeshes()
    {
        // Reactivar los mesh del jugador después de 0.5 segundos
        foreach (GameObject mesh in playerMeshes)
        {
            mesh.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public float GetMana()
    {
        return currentMana;
    }

    public void UseMana(int manaCost)
    {
        if (currentMana >= manaCost)
        {
            currentMana -= manaCost;
        }
    }

    private void RegenerateManaOverTime()
    {
        currentMana += manaRegenPerSecond * Time.deltaTime;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    private void UpdateUI()
    {
        healthText.text = "Vida: " + currentHealth + " / " + maxHealth;
        manaText.text = "Maná: " + (int)currentMana + " / " + maxMana;
    }

    private void Die()
    {
        // Agregar la lógica para la muerte del jugador aquí.
        // Por ejemplo, mostrar una pantalla de game over, reiniciar el nivel, etc.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Cambiar "NombreDeTuEscena" con el nombre de la escena a la que deseas saltar.
        SceneManager.LoadScene("gameOver");
    }
}
