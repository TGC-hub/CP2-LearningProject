using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : MonoBehaviour
{
    public float jumpForce;
    [SerializeField] private AudioSource soundPlayerDie;
    private Rigidbody2D rigidbody;  
    void Start()
    {
        soundPlayerDie.Play();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

}
