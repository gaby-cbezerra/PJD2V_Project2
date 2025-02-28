using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private Animator animator;
    
    public float velocidade = 10f;
    public float forcaPulo = 10f;

    private bool noChao = false;
    
    void Start()
    {
        _transform = gameObject.transform;
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("chao")) //if (other.tag == "chao")
        {
            noChao = true;
        }
    }

    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("chao")) //if (other.tag == "chao")
        {
            noChao = false;
        }
    }
    
    void Update()
    {
        
        Debug.Log("No Chao: " + noChao);
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _transform.position -= new Vector3(velocidade*Time.deltaTime,0,0);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("Transition", 1);
           Debug.Log("LeftArrow");
        }
        
   
        else if(Input.GetKey(KeyCode.RightArrow))
        {
           _transform.position += new Vector3(velocidade*Time.deltaTime,0,0);
           _transform.rotation = Quaternion.Euler(0, 180, 0);
           animator.SetInteger("Transition", 1);
           Debug.Log("RightArrow");
        }
        
        else
        {
            animator.SetInteger("Transition", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
           // forcaPulo
           _rigidbody2D.AddForce(new Vector2(0,forcaPulo),ForceMode2D.Impulse);
        }
    }
}
