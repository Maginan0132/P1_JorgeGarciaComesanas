using UnityEngine.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float vel = 2.0f;
    private float salto = 6f;
    [SerializeField] private Animator animator;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            vel = 4.0f;
            animator.SetBool("sprint", true);
        }
        else
        {
            vel = 2.0f;
            animator.SetBool("sprint", false);
        }

        Vector3 direccion = new Vector3(hor, 0, ver).normalized;
        if(direccion.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        rb.linearVelocity = new Vector3(direccion.x * vel, rb.linearVelocity.y, direccion.z * vel);

        if(hor != 0 || ver != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if(rb.linearVelocity.y > 0.1f || rb.linearVelocity.y < -0.1f)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }
}
