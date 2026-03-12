using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private Canvas barraVidas;

    
    void Start()
    {
        textoMonedas.text = "0";
        GameManager.INSTANCIA.CambioMonedas += actualizaTexto;
        GameManager.INSTANCIA.CambioVidas += QuitaVida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void QuitaVida(int vidas)
    {
        if(vidas >= 0 && vidas != 3)
            barraVidas.transform.GetChild(vidas).gameObject.GetComponent<Image>().enabled = false ;

        if(vidas == 3)
        {
            for(int i = 0; i < barraVidas.transform.childCount; i++)
            {
                barraVidas.transform.GetChild(i).gameObject.GetComponent<Image>().enabled = true ;
            }   
        }
           
    }

    private void actualizaTexto(int monedas)
    {
        this.textoMonedas.text = monedas.ToString();
    }
}
