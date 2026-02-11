using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CaidaPlataforma : MonoBehaviour
{
    private float vel = 1.0f;
    private Vector3 posInicial;
    private Vector3 posFinal;
    private bool colision = false; 
    private float tiempo = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicial = transform.position;
        posFinal = new Vector3(transform.position.x, 0, transform.position.z);   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        if(collision.gameObject.CompareTag("Jugador") && !colision && normal == collision.gameObject.transform.up)
        {
            colision = true;
            StartCoroutine(Timer(tiempo));
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jugador"))
        {
            //collision.gameObject.transform.SetParent(null);
        }
    }

    private IEnumerator Timer(float duracion = 1)
    {
        yield return new WaitForSeconds(duracion);
        
        while (transform.position.y > posFinal.y + 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posFinal, vel * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(duracion);

        while (transform.position.y < posInicial.y - 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posInicial, vel * Time.deltaTime);
            yield return null;
        }

        colision = false;
    }
}
