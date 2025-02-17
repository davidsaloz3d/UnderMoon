using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DetenerTiempo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public float slowDownFactor = 0.5f; // Factor de ralentización (0.5 = 50% de velocidad)
    public float slowDownDuration = 5f; // Duración del efecto en segundos
    public float radius = 10f; // Radio de afectación alrededor del personaje

    private List<TiempoDetendo> affectedObjects = new List<TiempoDetendo>();

    void Update()
    {
        // Activar el efecto de ralentización al presionar una tecla (por ejemplo, la tecla "T")
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(SlowTime());
        }
    }

    IEnumerator SlowTime()
    {
        // Encontrar todos los objetos dentro del radio que tengan un componente "TimeAffectedObject"
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != gameObject) // Excluir al personaje
            {
                Debug.Log("Funciona ese consianfiro?");
                var affectedObject = hitCollider.GetComponent<TiempoDetendo>();
                if (affectedObject != null)
                {
                    affectedObjects.Add(affectedObject);
                    affectedObject.SetTimeScale(slowDownFactor); // Ralentizar el objeto
                }
            }
        }

        // Esperar la duración del efecto
        yield return new WaitForSeconds(slowDownDuration);

        // Restaurar el tiempo normal para los objetos afectados
        foreach (var affectedObject in affectedObjects)
        {
            affectedObject.SetTimeScale(1f); // Restaurar el tiempo normal
        }

        // Limpiar la lista de objetos afectados
        affectedObjects.Clear();
    }
}

