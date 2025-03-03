using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour

{
    [SerializeField] GameObject Press;
    [SerializeField] bool SaltarCred = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Salir",4);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)&& SaltarCred){

            SceneManager.LoadScene("Menu");
            Debug.Log("Se esta volviendo al menu");

        }
    }

    public void Salir(){

        Press.SetActive(true);
        SaltarCred = true;
    }
}
