using Unity.VisualScripting;
using UnityEngine;

public class Atravesar : MonoBehaviour
{
    public bool atraviesa = false;
    public bool atravando = false;
    int nObjetos = 0;

    [SerializeField] Collider[] obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2) && !atraviesa){
            for(nObjetos = 0; nObjetos < obj.Length; nObjetos++){
                obj[nObjetos].isTrigger = true;
            }
            
            atraviesa = true;
        }else if(Input.GetKeyDown(KeyCode.Alpha2) && atraviesa && !atravando){
            for(nObjetos = 0; nObjetos < obj.Length; nObjetos++){
                obj[nObjetos].isTrigger = false;
            }
            atraviesa = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstaculo")){
            atravando = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("obstaculo")){
            other.isTrigger = false;
            atravando = false;
        }
    }
}
