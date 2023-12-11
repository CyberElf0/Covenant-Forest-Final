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
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isInvulnerabilityActive = false;
            isInvulnerable = false;
        }
        if (currentMana < manaCostPerSecond)
        {
            isInvulnerabilityActive = false;
            isInvulnerable = false;
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
