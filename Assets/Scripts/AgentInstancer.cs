using UnityEngine;

public class AgentInstancer : MonoBehaviour
{
    public GameObject objetoPrefab; // El prefab que deseas instanciar
    public Vector3[] posiciones;    // Las posiciones donde deseas instanciar los objetos

    private void Start()
    {
        InstanciarObjetosEnPosiciones();
    }

    void InstanciarObjetosEnPosiciones()
    {
        if (objetoPrefab == null || posiciones.Length == 0)
        {
            Debug.LogWarning("Falta asignar el prefab o las posiciones en el Inspector.");
            return;
        }

        foreach (Vector3 posicion in posiciones)
        {
            Instantiate(objetoPrefab, posicion, Quaternion.identity);
        }
    }
}