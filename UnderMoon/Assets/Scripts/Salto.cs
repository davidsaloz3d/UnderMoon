using StarterAssets;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public static bool salto = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !salto){
            ThirdPersonController.JumpHeight = 4;
            ThirdPersonController.Gravity = -0.5f;
            salto = true;
        }else if(Input.GetKeyDown(KeyCode.E) && salto){
            ThirdPersonController.JumpHeight = 1.3f;
            ThirdPersonController.Gravity = -15f;
            salto = false;
        }

    }
}
