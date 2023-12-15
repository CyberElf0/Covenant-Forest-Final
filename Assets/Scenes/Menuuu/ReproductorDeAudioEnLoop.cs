using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReproductorDeAudioEnLoop : MonoBehaviour
{
    public AudioClip clip; // El archivo de audio que se reproducirá
    public float inicioLoop = 0f; // El tiempo de inicio del bucle en segundos
    public float finLoop = 10f; // El tiempo de fin del bucle en segundos

    private AudioSource audioSource;

    void Start()
    {
        // Asegúrate de que hay un AudioSource en el GameObject actual
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Se requiere un componente AudioSource en el GameObject.");
            return;
        }

        // Configura el clip de audio y habilita el bucle
        audioSource.clip = clip;
        audioSource.loop = false;

        // Inicia la reproducción
        audioSource.Play();

        // Establece la posición inicial del bucle
        audioSource.time = inicioLoop;
    }

    void Update()
    {
        // Si el tiempo actual supera el fin del bucle, retrocede al inicio del bucle
        if (audioSource.time >= finLoop)
        {
            audioSource.time = inicioLoop;
        }
    }
}
