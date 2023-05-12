using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 1f;
    public LayerMask ground;
    public LayerMask wall;

    private Rigidbody2D rigidbody;
    public Collider2D triggerCollider;

    public GameObject DeathEffectEnemy;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
    }

    void FixedUpdate()
    {
        if (triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Destroy(Instantiate(DeathEffectEnemy, gameObject.transform.position, gameObject.transform.rotation), 1.0f);
            Destroy(gameObject);
        }
    }


}
