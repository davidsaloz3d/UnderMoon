using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            Application.Quit();
        }
    }

    public void Inciar(){

        SceneManager.LoadScene("Escenario");
    }

    public void Credit(){

        SceneManager.LoadScene("Credits");
    }

    public void Salir(){

        Application.Quit();
    }

    public void Tuto(){

        SceneManager.LoadScene("Tuto");
    }
}
