using UnityEngine;
using TMPro;

public class ManagerCanvas : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] GameObject mensaje;
    [SerializeField] GameObject menus;
    [SerializeField] GameObject lore;
    [SerializeField] GameObject comados;

    [Header("Extras")]
    public TextMeshProUGUI mentexto;
    public GameObject salirmen;


    void Start()
    {
        ActivarComandos();
    }

    public void CambiarMensaje()
    {
        
    }



    public void ActivarMenus()
    {
        mensaje.SetActive(false);
        menus.SetActive(true);
        lore.SetActive(false);
        comados.SetActive(false);
    }
    public void ActivarMensaje()
    {
        mensaje.SetActive(true);
        menus.SetActive(false);
        lore.SetActive(false);
        comados.SetActive(false);

        CambiarMensaje();
    }
    public void ActivarLore()
    {
        mensaje.SetActive(false);
        menus.SetActive(false);
        lore.SetActive(true);
        comados.SetActive(false);
    }
    public void ActivarComandos() 
    {
      mensaje.SetActive(false);  
      menus.SetActive(false);  
      lore.SetActive(false);
      comados.SetActive(true);  
    }
    public void ActivarJugador() 
    {
      mensaje.SetActive(false);  
      menus.SetActive(false);  
      lore.SetActive(false);
      comados.SetActive(false);  
    }

}
