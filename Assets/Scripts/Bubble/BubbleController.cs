using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BubbleModel))]
public class BubbleController : MonoBehaviour
{
    private BubbleModel _bubbleModel;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _bubbleModel = GetComponent<BubbleModel>();
    }

    private void OnEnable()
    {
        rb.velocity = new Vector2(_bubbleModel.StartXVelocity, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("BottomBorder"))
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = _bubbleModel.BounceForce;
            rb.velocity = newVelocity;
        }

        else if (collision.collider.gameObject.CompareTag("Arrow"))
        {
            DestroyBubble();
        }
    }

    [ContextMenu("DestroyBubble")]
    public void DestroyBubble()
    {
        if (_bubbleModel.HealthRemaining > 0)
        {
            SpawnSmallerBubble(right: true);
            SpawnSmallerBubble(right: false);
        }

        gameObject.SetActive(false);
        GameManager.Instance.DestroyBubble();
    }

    public void SpawnSmallerBubble(bool right)
    {
        BubbleModel newBubbleModel;
        GameObject bubbleGORight = BubblePoolManager.Instance.GetPooledObject();
        newBubbleModel = bubbleGORight.GetComponent<BubbleModel>();
        newBubbleModel.Initialize(_bubbleModel.BounceForce * _bubbleModel.BounceMultiplicand,
            right ? _bubbleModel.StartXVelocity : -_bubbleModel.StartXVelocity,
            _bubbleModel.BubbleSize - 1,
            _bubbleModel.HealthRemaining - 1,
            _bubbleModel.BounceMultiplicand);
        bubbleGORight.transform.position = transform.position;
        bubbleGORight.SetActive(true);

        GameManager.Instance.AddBubble();
    }
}
