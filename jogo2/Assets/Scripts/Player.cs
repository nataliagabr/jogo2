using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 10f;
    public float focaPulo = 10f;

    public bool noChao = false;

    private bool isRun = false; // Variável para controlar a animação de movimento

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    // Start é chamado antes do primeiro frame update
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
            noChao = true; // O personagem está no chão
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            noChao = false; // O personagem saiu do chão
        }
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        isRun = false; // Inicialmente, o personagem não está se movendo

        // Movimento para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-velocidade * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = true; // Vira o sprite para a esquerda

            if (noChao)
            {
                isRun = true; // O personagem está se movendo
            }
        }

        // Movimento para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false; // Vira o sprite para a direita

            if (noChao)
            {
                isRun = true; // O personagem está se movendo
            }
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            _rigidbody2D.AddForce(new Vector2(0, 1) * focaPulo, ForceMode2D.Impulse);
        }

        // Atualiza o parâmetro "IsRun" no Animator
        _animator.SetBool("IsRun", isRun); // Atualiza o parâmetro no Animator
    }
}
