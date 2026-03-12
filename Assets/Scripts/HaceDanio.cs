using UnityEngine;
using System.Collections;

public class HaceDanio : MonoBehaviour
{
    GameManager gm;
    private float timer = 0;
    void Start()
    {
        gm = GameManager.INSTANCIA;
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jugador"))
        {
            if(gm != null && Time.time > timer)
            {
                gm.PerderVida();
                timer = Time.time + 2.0f;
            }
        }
    }
}
