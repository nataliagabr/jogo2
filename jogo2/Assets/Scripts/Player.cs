using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float velocidade = 10f;
  public float focaPulo = 10f;

    public bool parado = false;

    public bool andando = false;

  private Rigidbody2D _rigidbody2D;
  private SpriteRenderer  _spriteRenderer;
  private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }


   void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            parado = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            parado = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        andando = false;
        
      if(Input.GetKey(KeyCode.LeftArrow))
      {
        gameObject.transform.position += new Vector3(-velocidade*Time.deltaTime,0,0);
        //rigidbody2D.AddForce(new Vector2(-velocidade,0));
        _spriteRenderer.flipX = true;
        Debug.Log("LeftArrow");

        if (parado == true)
        {
            andando = true;
        }
      }
        

      if(Input.GetKey(KeyCode.RightArrow))
      {
        gameObject.transform.position += new Vector3(velocidade*Time.deltaTime,0,0);
        //rigidbody2D.AddForce(new Vector2(velocidade,0));
         _spriteRenderer.flipX = false;
         Debug.Log("RightArrow");
         
         if (parado == true)
         {
             andando = true;
         }
      }

        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
            _rigidbody2D.AddForce(new Vector2(0, 1) * focaPulo,ForceMode2D.Impulse);

            Debug.Log("Jump");
        }

        _animator.SetBool("andando",andando);
        
     
    }
}