using UnityEngine;
using TMPro;
using System.Collections;

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
    public int menfinal;
    public bool siono;
    


    void Start()
    {
        ActivarComandos();
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
        }
    }

    IEnumerator AparicionBoton()
    {
        yield return new WaitForSeconds(4f);
        salirmen.SetActive(true);
    }

    public void Salir() { }

    public void ActivarMenus()
    {
        mensaje.SetActive(false);
        menus.SetActive(true);
        lore.SetActive(false);
        comados.SetActive(false);

        siono = false;
    }
    public void ActivarMensaje()
    {
        mensaje.SetActive(true);
        menus.SetActive(false);
        lore.SetActive(false);
        comados.SetActive(false);

        salirmen.SetActive(false);
        CambiarMensaje();
        StartCoroutine(AparicionBoton());
    }
    public void ActivarLore()
    {
        mensaje.SetActive(false);
        menus.SetActive(false);
        lore.SetActive(true);
        comados.SetActive(false);
        siono = true;
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
