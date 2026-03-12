using NUnit.Framework;
using UnityEditor.Build.Content;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameManager.INSTANCIA;
        GameManager.INSTANCIA.Respawn += RegenraMoneda;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Jugador"))
        {
            this.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    // void OnDestroy()
    // {
    //     if(gm != null)
    //         gm.AnadirMoneda();
    // }

    void OnDisable()
    {
        if(gm != null)
            gm.AnadirMoneda();
    }

    private void RegenraMoneda()
    {
        if(this.gameObject.activeSelf == false)    
            this.gameObject.SetActive(true);
    }
}
