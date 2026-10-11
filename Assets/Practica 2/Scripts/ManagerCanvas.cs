using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManagerCanvas : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] GameObject mensaje;
    [SerializeField] GameObject menus;
    [SerializeField] GameObject lore;
    [SerializeField] GameObject comados;

    [Header("Extras")]
    public TextMeshProUGUI mentexto;
    public GameObject okiboton;
    public GameObject continuarboton;
    public GameObject hacerboton;
    public GameObject mensajeboton;
    public int menfinal;
    public bool siono;
    private bool aplicacionEnSegundoPlano;


    void Start()
    {
        ActivarComandos();
    }

    private void SeleccionarBoton(GameObject boton)
    {
        if (boton != null && boton.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(boton);
            Debug.Log("este es el boton que esta siendo obtenido: " + boton);
        }
    }
    private void OnApplicationPause(bool pausada)
    {
        aplicacionEnSegundoPlano = pausada;

        if (pausada)
        {
            Debug.Log("se paso a segundo plano");
            menfinal = 3;
            ActivarMensaje();
        }
        else { return; }
    }

    public void CambiarMensaje()
    {
        if(siono) { menfinal = 2; }

        switch (menfinal)
        {
            case 0:
                mentexto.text = "Happy happy happy (yeppie feliz)";
                break;
            case 1:
                mentexto.text = "Se necesita un mando para funcionar";
                break;
            case 2:
                mentexto.text = "Muy mal no quieras sobrevivir";
                break;
            case 3:
                mentexto.text = "Has dejado el juego en segundo plano";
                break;
        }
        StartCoroutine(AparicionBoton());
    }

    IEnumerator AparicionBoton()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("sale del bucle");
        mensajeboton.SetActive(true);
        SeleccionarBoton(mensajeboton);
    }

    public void Salir() { Application.Quit(); }

    public void ActivarMenus()
    {
        mensaje.SetActive(false);
        menus.SetActive(true);
        lore.SetActive(false);
        comados.SetActive(false);

        siono = false;
        SeleccionarBoton(continuarboton);
    }
    public void ActivarMensaje()
    {
        mensaje.SetActive(true);
        menus.SetActive(false);
        lore.SetActive(false);
        comados.SetActive(false);

        mensajeboton.SetActive(false);
        CambiarMensaje();
    }
    public void ActivarLore()
    {
        mensaje.SetActive(false);
        menus.SetActive(false);
        lore.SetActive(true);
        comados.SetActive(false);
        siono = true;

        SeleccionarBoton(hacerboton);
    }
    public void ActivarComandos() 
    {
        mensaje.SetActive(false);  
        menus.SetActive(false);  
        lore.SetActive(false);
        comados.SetActive(true);

        SeleccionarBoton(okiboton);
    }
    public void ActivarJugador() 
    {
        mensaje.SetActive(false);  
        menus.SetActive(false);  
        lore.SetActive(false);
        comados.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

}
