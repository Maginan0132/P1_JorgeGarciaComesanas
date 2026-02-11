using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + new Vector3(0, 2.4f, -3);
        transform.position = targetPosition;
    }
}