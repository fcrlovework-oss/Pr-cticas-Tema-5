using UnityEngine;

public class DeteccionBolasCaidas : MonoBehaviour
{
    //ATRIBUTOS: -----------------------------------
    GameObject bolaCaida;
    InstanciarPrefabs eliminarDeListas;

    //MÉTODOS BÁSICOS: -------------------------------------
    private void Awake()
    {
        eliminarDeListas = FindFirstObjectByType<InstanciarPrefabs>();
    }
    private void OnTriggerEnter(Collider other)
    {
        bolaCaida = other.gameObject;
        eliminarDeListas.EliminacionBolasListas(bolaCaida);
        Destroy(bolaCaida);
    }
}
