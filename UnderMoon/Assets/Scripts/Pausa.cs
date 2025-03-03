using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(){
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void returnMenu(){
        SceneManager.LoadScene("Menu");
    }
}
