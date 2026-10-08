using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Movimiento : MonoBehaviour
{
    [Header("Datos personaje")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 6f;
    [SerializeField] float fall = 2f;

    [Header("Importante")]
    private Vector3 movimiento;
    private Rigidbody rb;

    private bool onsuelo = false;
    [SerializeField] LayerMask layersuelo;
    [SerializeField] float distsuelo = 1.05f;

    [Header("Poder")]
    [SerializeField] GameObject barrera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        barrera.SetActive(false);
    }

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector3>();
    }

    public void OnJump(InputValue value)
    {
        float jumpInput = value.Get<float>();

        if (jumpInput > 0.5f && onsuelo)
        {
            //rb.AddForce(Vector3.up * jump, ForceMode.Impulse);

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jump, rb.linearVelocity.z);

            onsuelo = false;
            //Debug.Log("Salto ejecutado");
        }
    }

    public void OnDom(InputValue value)
    {
        float domInput = value.Get<float>(); 

        if (domInput > 0.5f && rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity = new Vector3( rb.linearVelocity.x, rb.linearVelocity.y * fall, rb.linearVelocity.z);
            //Debug.Log("Caída rápida");
        }
    }

    //public void OnPower(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        if (context.interaction is HoldInteraction)
    //        {
    //            barrera.SetActive(true);
    //            Debug.Log("se activa");
    //        }
    //        else
    //        {
    //            barrera.SetActive(false);

    //            Debug.Log("Se desactiva");
    //        }
    //    }
    //    else Debug.Log("NO lo encuentra");
    //}

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movimiento.x, 0 , movimiento.z);
        transform.Translate (move *speed* Time.deltaTime);

        onsuelo = Physics.Raycast( transform.position, Vector3.down, distsuelo, layersuelo );
        
    }

    public void OnTest(InputValue value)
    {
        Debug.LogError("ñooooow");
    }


}
