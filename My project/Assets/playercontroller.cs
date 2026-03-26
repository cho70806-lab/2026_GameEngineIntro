using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class playercontroller : MonoBehaviour
{
    private Vector2 moveInput;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myAnimator;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("move", false);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed) //점프 버튼을 누르면
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (moveInput.magnitude > 0)
        {
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }
        transform.Translate(Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("playscene_" + collision.name);
        }
    }
}

