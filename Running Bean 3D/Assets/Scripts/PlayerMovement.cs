using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float Jumpforce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] float rotationSpeed;

    public Animator anim;

    // Przy 'void Start' wzywamy rb, aby pozniej za kazdym razem nie powtarzac calosci
    private void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    // Poruszanie siê gracza przod/tyl i na boki
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3 (horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        // uruchomienie animacji biegu, gdy jest input

        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        if(Input.GetButton("Vertical"))
        {
            anim.SetFloat("Speed", 1f);
        }

        // skok gracza
        if (Input.GetButton("Jump") && IsGrounded())
        {
            Jump();
        }

        // rotacja gracza, gdy sie rusza

        if (rb.velocity != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rb.velocity, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Tworzymy metode skoku, aby bylo czytelniej/latwiej i szybciej przywolac. Dodajemy rowniez dzwiek przy kazdym skoku
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, Jumpforce, rb.velocity.z);
        jumpSound.Play();
    }
    
    // W przypadku kolizji z glowa 'enemy' chcemy, aby caly obiekt byl zniszczony, nie tylko glowa i przywolujemy skok, aby po uderzeniu w glowe 'enemy' wykonac skok
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }

    }

    /* Czy gracz jest 'grounded', aby gracz mogl skakac tylko w przypadku, gdy dotyka podloza (LayerMask = 'ground'). Tworzymy 'sphere',
    przez ktora bedziemy to sprawdzac. Gdy gracz jest w powietrzu, nie bedzie w stanie skoczyc po raz kolejny*/

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
    
}
