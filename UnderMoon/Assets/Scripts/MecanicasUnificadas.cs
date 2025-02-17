using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class MecanicasUnificadas : MonoBehaviour
{
    private float tiempoRestante = 0f;

    bool pasandoTunel = false;

    [Header("HUD")]
    [SerializeField] Slider tiempoSalto;

    [SerializeField] Slider tiempoEnano;

    [SerializeField] Slider tiempoInvisible;

    [SerializeField] Slider tiempoAtraviesa;

    [SerializeField] GameObject Atraviesa;
    [SerializeField] GameObject Enano;
    [SerializeField] GameObject Vuelo;
    [SerializeField] GameObject Trans;

    //Varoables para hacerse pequeño
    [Header("Enano")]
    public bool enano = false;
    private Vector3 originalScale;
    private Vector3 finalScale;
    public float scaleSpeed = 2f;
    public bool pulsado = false;

    //Variables para volar
    [Header("Vuelo")]
    public static bool vuelo = false;

    //Variables para hacerse invisible
    [Header("Invisible")]
    [SerializeField] GameObject sinBody;
    [SerializeField] GameObject conBody;
    [SerializeField] GameObject Dientes;
    [SerializeField] GameObject Lengua;
    [SerializeField] GameObject Ojos;
    [SerializeField] GameObject conCamisa;
    [SerializeField] GameObject sinCamisa;
    [SerializeField] GameObject conPelo;
    [SerializeField] GameObject sinPelo;
    [SerializeField] GameObject conPant;
    [SerializeField] GameObject sinPant;
    public bool trans = false;

    //Variables para atravesar
    [Header("Atravesar")]
    public bool atraviesa = false;
    public bool atravesando = false;
    int nObjetos = 0;
    [SerializeField] Collider[] obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        finalScale = originalScale * 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

        //Vuelo
        if (Input.GetKeyDown(KeyCode.Alpha1) && !vuelo && tiempoRestante == 0)
        {
            vuelo = true;
            ThirdPersonController.JumpHeight = 4f;
            ThirdPersonController.Gravity = -0.5f;
            tiempoRestante = 20f;
        }

        //Transparente
        if (Input.GetKeyDown(KeyCode.Alpha2) && !trans && tiempoRestante == 0)
        {
            trans = true;
            sinBody.SetActive(true);
            conBody.SetActive(false);
            sinPelo.SetActive(true);
            conPelo.SetActive(false);
            sinCamisa.SetActive(true);
            conCamisa.SetActive(false);
            sinPant.SetActive(true);
            conPant.SetActive(false);
            Dientes.SetActive(false);
            Ojos.SetActive(false);
            Lengua.SetActive(false);
            tiempoRestante = 20f;
        }

        //Enano
        if (Input.GetKeyDown(KeyCode.Alpha3) && !enano && tiempoRestante == 0)
        {
            pulsado = true;
        }

        if (pulsado && !enano)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, finalScale, scaleSpeed * Time.deltaTime);
            ThirdPersonController.JumpHeight = 0.7f;
            tiempoRestante = 20f;
            if (transform.localScale == finalScale)
            {
                enano = true;
                pulsado = false;
            }
        }


        //Atravesar
        if (Input.GetKeyDown(KeyCode.Alpha4) && !atraviesa && tiempoRestante == 0)
        {
            for (nObjetos = 0; nObjetos < obj.Length; nObjetos++)
            {
                obj[nObjetos].isTrigger = true;
            }
            atraviesa = true;
            tiempoRestante = 20f;
        }

        //Volver despues de vuelo
        if (vuelo)
        {
            Vuelo.SetActive(true);
            tiempoSalto.value = tiempoRestante;
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                ThirdPersonController.JumpHeight = 1.3f;
                ThirdPersonController.Gravity = -15f;
                vuelo = false;
                Vuelo.SetActive(false);
                tiempoRestante = 0;
            }
        }

        //Volver despues de invisible
        if (trans)
        {
            Trans.SetActive(true);
            tiempoInvisible.value = tiempoRestante;
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                sinBody.SetActive(false);
                conBody.SetActive(true);
                sinPelo.SetActive(false);
                conPelo.SetActive(true);
                sinCamisa.SetActive(false);
                conCamisa.SetActive(true);
                sinPant.SetActive(false);
                conPant.SetActive(true);
                Dientes.SetActive(true);
                Ojos.SetActive(true);
                Lengua.SetActive(true);
                trans = false;
                Trans.SetActive(false);
                tiempoRestante = 0;
            }
        }

        //Volver a ser grande
        if (enano)
        {
            Enano.SetActive(true);
            tiempoEnano.value = tiempoRestante;
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0 && !pasandoTunel)
            {
                ThirdPersonController.JumpHeight = 1.3f;
                transform.localScale = Vector3.MoveTowards(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);
                if (transform.localScale == originalScale)
                {
                    enano = false;
                    pulsado = false;
                    Enano.SetActive(false);
                    tiempoRestante = 0;
                }


            }
        }

        //Volver a chocar contra los muros
        if (atraviesa)
        {
            Atraviesa.SetActive(true);
            tiempoAtraviesa.value = tiempoRestante;
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0 && !atravesando)
            {
                for (nObjetos = 0; nObjetos < obj.Length; nObjetos++)
                {
                    obj[nObjetos].isTrigger = false;
                }
                atraviesa = false;
                Atraviesa.SetActive(false);
                tiempoRestante = 0;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tunel"))
        {
            pasandoTunel = true;
        }

        if (other.CompareTag("obstaculo"))
        {
            atravesando = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tunel"))
        {
            pasandoTunel = false;
        }

        if (other.CompareTag("obstaculo"))
        {
            other.isTrigger = false;
            atravesando = false;
        }
    }
}
