using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCIA;
    private int monedas = 0;

    public int Monedas
    {
        get { return monedas; }
        set { monedas = value; }
    }

    public void AnadirMoneda()
    {
        monedas++;
        CambioMonedas?.Invoke(monedas);
    }

    public Action<int> CambioMonedas;

    private int vidas = 3;

    public int Vidas
    {
        get { return vidas; }
        set { vidas = value; }
    }

    public void PerderVida()
    {
        if(vidas > 0)
        {
            vidas--;

            CambioVidas?.Invoke(vidas);

            if (vidas == 0)
            {
                ResetearJuego();
                Respawn?.Invoke();
            }
        }
    }
    
    public Action<int> CambioVidas;
    public Action Respawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (INSTANCIA == null)
        {
            INSTANCIA = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void ResetearJuego()
    {
        monedas = 0;
        vidas = 3;
        CambioMonedas?.Invoke(monedas);
        CambioVidas?.Invoke(vidas);
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene("EscenaNivel");
    }

    public void Victoria()
    {
        SceneManager.LoadScene("Victoria");
    }

    public void VueltaMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
