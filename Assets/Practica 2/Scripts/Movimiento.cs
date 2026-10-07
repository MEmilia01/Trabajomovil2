using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Vector3 movimiento;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector3>();
    }

    public void OnJump(InputValue value)
    {
        movimiento = value.Get<Vector3>();
        Debug.LogError("Salto funcional");
    }

    public void OnDom(InputValue value)
    {
        movimiento = value.Get<Vector3>();
        Debug.LogError("Bjada funcional");
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movimiento.x, 0 , movimiento.z);
        transform.Translate (move *speed* Time.deltaTime);
        //rb.linearVelocity = new Vector3(movimiento.x + speed, rb.linearVelocity.y, rb.linearVelocity.z); 
    }

    public void OnTest(InputValue value)
    {
        Debug.LogError("ñooooow");
    }


}
