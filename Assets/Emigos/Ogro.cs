using UnityEngine;

public class Ogro : MonoBehaviour
{
    public float velocidad = 3f;
    public int vidaMaxima = 100;
    private int vidaActual;
    private Transform objetivo;
    private bool esInvulnerable = false;
    public GameObject enemigoPrefab;
    public Transform[] puntosSpawn;
    public float tiempoEntreInvocaciones = 2f;
    private float tiempoUltimaInvocacion;
    private int enemigosInvocados = 0;
    public GameObject efectoInvulnerable; // Nuevo GameObject para mostrar cuando esInvulnerable es true

    void Start()
    {
        vidaActual = vidaMaxima;
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;

        // Asegúrate de desactivar el efectoInvulnerable al inicio
        if (efectoInvulnerable != null)
        {
            efectoInvulnerable.SetActive(false);
        }
    }

    void Update()
    {
        if (objetivo != null && !esInvulnerable)
        {
            Vector3 direccion = (objetivo.position - transform.position).normalized;
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            transform.rotation = rotacion;
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        }

        if (esInvulnerable && Time.time - tiempoUltimaInvocacion > tiempoEntreInvocaciones)
        {
            InvocarEnemigo();
            tiempoUltimaInvocacion = Time.time;
        }

        // Mostrar u ocultar el efectoInvulnerable según el valor de esInvulnerable
        if (efectoInvulnerable != null)
        {
            efectoInvulnerable.SetActive(esInvulnerable);
        }
    }

    public void RecibirDanio(int cantidad)
    {
        if (esInvulnerable)
        {
            return;
        }

        vidaActual -= cantidad;

        if (vidaActual <= vidaMaxima / 2)
        {
            esInvulnerable = true;
            velocidad = 0f;
            tiempoUltimaInvocacion = Time.time;
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }

    void InvocarEnemigo()
    {
        if (puntosSpawn.Length > 0 && enemigoPrefab != null)
        {
            Transform puntoSpawn = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            Instantiate(enemigoPrefab, puntoSpawn.position, puntoSpawn.rotation);
            enemigosInvocados++;

            if (enemigosInvocados >= 10)
            {
                esInvulnerable = false;
                velocidad = 3f;
            }
        }
    }
}
