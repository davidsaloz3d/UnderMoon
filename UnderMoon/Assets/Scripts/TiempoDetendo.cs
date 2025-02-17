using UnityEngine;

public class TiempoDetendo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private float originalTimeScale = 1f;

    public void SetTimeScale(float timeScale)
    {
        if (timeScale != originalTimeScale)
        {
            originalTimeScale = timeScale;
            // Aplicar el factor de tiempo a las animaciones y físicas
            if (TryGetComponent<Animator>(out var animator))
            {
                Debug.Log("velocidad de animacion" + timeScale + " funciona?");
                animator.speed = timeScale;
            }
            if (TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.linearVelocity *= timeScale;
                rigidbody.angularVelocity *= timeScale;
            }
        }
    }
}
