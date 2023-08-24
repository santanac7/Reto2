using UnityEngine;

public class NewAgent : MonoBehaviour
{
    public GameObject prefabAgent;
    public Transform spawnPosition;

    void Start()
    {
        // Verificamos si se asignó el prefab y la posición de aparición
        if (prefabAgent != null && spawnPosition != null)
        {
            // Creamos una instancia del prefab en la posición deseada
            GameObject newPrefabInstance = Instantiate(prefabAgent, spawnPosition.position, spawnPosition.rotation);

            // Opcionalmente, puedes realizar acciones adicionales en la nueva instancia
            // Por ejemplo, modificar propiedades o agregar componentes
        }
        else
        {
            Debug.LogWarning("Prefab o posición de aparición no asignados en el script.");
        }
    }
}