using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ArrowModel))]
public class ArrowController : MonoBehaviour
{
    private Rigidbody2D rb;
    private ArrowModel _arrowModel;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _arrowModel = GetComponent<ArrowModel>();
        rb.velocity = new Vector3(0f, _arrowModel.StartYVelocity, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
