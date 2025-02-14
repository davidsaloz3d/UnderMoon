using StarterAssets;
using UnityEngine;

public class Minimizar : MonoBehaviour
{
    public bool chico = false;
    private Vector3 originalScale;
    private Vector3 finalScale;
    public float scaleSpeed = 2f;
    public bool pulsado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        finalScale = originalScale * 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pulsado = true;
        }

        if (pulsado && !chico)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, scaleSpeed * Time.deltaTime);
            ThirdPersonController.JumpHeight = 0.7f;
            
             if (transform.localScale == finalScale)
            {
                chico = true;
                pulsado = false;
            }

        }
        else if (pulsado && chico)
        {
            ThirdPersonController.JumpHeight = 1.3f;
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);
            if (transform.localScale == originalScale)
            {
                chico = false;
                pulsado = false;
            }
        }
    }
}