using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBullet : MonoBehaviour
{    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        //// Busca un TrailRenderer en los hijos del objeto
        //TrailRenderer trailRenderer = GetComponentInChildren<TrailRenderer>();

        //if (trailRenderer != null)
        //{
        //    // Resetea el TrailRenderer
        //    trailRenderer.Clear();
        //    trailRenderer.emitting = true; // Si el trail renderer tiene auto emisión, reactiva la emisión
        //}
    }
}