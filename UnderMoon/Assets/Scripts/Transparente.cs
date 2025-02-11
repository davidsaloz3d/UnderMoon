using UnityEngine;

public class Transparente : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject personaje;
    public bool Transparent = false;

    // Use this for initialization
    void Start()
    {

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && !Transparent){
            // personaje.material.color = new Color(1, 1, 1, 0.3f);
        }else if(Input.GetKeyDown(KeyCode.Alpha1) && Transparent){
            // personaje.GetComponent<>().material.color = new Color(1, 1, 1, 1f);
        }
    }

}
