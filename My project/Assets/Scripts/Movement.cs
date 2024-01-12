using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private bool faceRight = true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreAll;
    public static int score;
    public static int MaxCount;
    public int Count;
    public static bool trigIce = false;
    public static bool isLight = false;
    public static bool isFinish = false;
    public static bool isEnemy = false;
    public static string lightPrefab;
    public Animator anim;
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MaxCount = Count;
        scoreText.text = string.Format("{0} / {1}", 0, MaxCount);
        isFinish = false;
        isEnemy = false;
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 3f;
        else if (trigIce)
            speed = 2f;
        else speed = 6f;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Horizontal", moveVector.x);
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Vertical", moveVector.y);
        anim.SetFloat("Speed", moveVector.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CollectiveSquare")
        {
            audioManager.PlaySFX(audioManager.presents);
            if (TimeCounter.TimeRemaining > 0)
            {
                score++;
                scoreAll.text = string.Format("{0} / {1}", score, MaxCount);
                Destroy(collision.gameObject);
                if (score != MaxCount + 1)
                {
                    scoreText.text = string.Format("{0} / {1}", score, MaxCount);
                }
            }
        }
        if (collision.gameObject.tag == "Light")
        {
            isLight = true;
            lightPrefab = collision.name;
            Debug.Log("в света");
        }
        //else
        //{
        //    isLight = false;    
        //}
        if (collision.gameObject.tag == "Finish")
        {
            isFinish = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            isEnemy = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            trigIce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            trigIce = false;
        }
        if (collision.gameObject.tag == "Light")
        {
            isLight = false;
            Debug.Log("вышел из света");
        }
    }
}
