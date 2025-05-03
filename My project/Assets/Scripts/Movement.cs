using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public static UnityEvent OnEnterLight = new();
    public static UnityEvent<Enemy> OnEnterEnemy = new();
    public static UnityEvent OnFinish = new();

    public float speed = 6f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    public bool isOnIce = false;
    public bool isCrouching = false;
    public Animator anim;

    public static Movement Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Horizontal", moveVector.x);
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Vertical", moveVector.y);
        anim.SetFloat("Speed", moveVector.sqrMagnitude);

        speed = 6f;

        if (moveVector.sqrMagnitude > 0)
        {
            AudioManager.Footsteps = true;
        }
        else
        {
            AudioManager.Footsteps = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {   
            speed = 3f;
            isCrouching = true;
            AudioManager.Footsteps = false;
        } else
        {
            isCrouching = false;
        }

        if (isOnIce)
        {
            speed = 2f;
            AudioManager.Footsteps = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CollectiveSquare")
        {
            Destroy(collision.gameObject);
            ScoreManager.Instance.Score += 1;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.presentPickUpClip);
        }

        if (collision.gameObject.tag == "Light")
        {
            OnEnterLight.Invoke();
        }

        if (collision.gameObject.tag == "Finish")
        {
            OnFinish.Invoke();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.TryGetComponent<Enemy>(out var enemy);
            if (enemy != null)
                OnEnterEnemy.Invoke(enemy);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            isOnIce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            isOnIce = false;
        }
    }
}
