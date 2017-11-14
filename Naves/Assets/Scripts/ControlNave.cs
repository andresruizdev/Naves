using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControlNave : MonoBehaviour
{
    Rigidbody rb;
    Camera cam;
    [SerializeField] float Velocidad;
    public Transform transformJugador;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        MoverNave();
        VerificarPosicion();
    }

    private void VerificarPosicion()
    {
        if(GameManager.gameManager.estado == EstadoJugador.volar)
        {
            var p = rb.position;
            float distanciaCamara = (cam.transform.position - p).y;
            Vector3 limits = cam.ViewportToWorldPoint(new Vector3(0, 0, distanciaCamara));
            limits.x += transformJugador.localScale.x / 2;
            limits.z += transformJugador.localScale.z / 2;

            if(p.x < limits.x)
            {
                p.x = limits.x;
                rb.velocity = Vector3.zero;
            }
            if(p.x > -limits.x)
            {
                p.x = -limits.x;
                rb.velocity = Vector3.zero;
            }
            if(p.z < limits.z)
            {
                p.z = limits.z;
                rb.velocity = Vector3.zero;
            }
            if(p.z > -limits.z)
            {
                p.z = -limits.z;
                rb.velocity = Vector3.zero;
            }
        }
        
        
    }

    private void MoverNave()
    {
        //if(GameManager.gameManager.estado == EstadoJugador.volar)
        //{ }
#if UNITY_EDITOR
            float xMover = Input.GetAxis("Vertical") * Velocidad;
        float zMover = Input.GetAxis("Horizontal") * Velocidad;
        rb.AddForce(new Vector3(zMover, 0, xMover));

#elif UNITY_ANDROID || UNITY_IOS
        rb.AddForce(new Vector3(Input.acceleration.normalized.x, 0, Input.acceleration.normalized.z) * Velocidad);
#endif
    }
}


