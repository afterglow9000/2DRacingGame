using UnityEngine;

public class CarController : MonoBehaviour
{
    public AudioManager AM;
    bool currentPlatformAndroid = false;
    Vector3 position;
    Rigidbody2D RB;
    public float speed;
    public UIManager UI;

    void AccelerometerMove()
    {
        float x = Input.acceleration.x;

        if (x < -0.1f)
        {
            MoveLeft();
        }
        else if (x > 0.1f)
        {
            MoveRight();
        }
        else
        {
            SetVelocityZero();
        }
    }

    void Awake()
    {

#if UNITY_ANDROID
        currentPlatformAndroid = true;
#endif

        AM.carSound.Play();
        RB = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        RB.velocity = new Vector2(-speed, 0);
    }

    public void MoveRight()
    {
        RB.velocity = new Vector2(speed, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyCar")
        {
            gameObject.SetActive(false);
            UI.GameOver();
            AM.carSound.Stop();
        }
    }

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (currentPlatformAndroid)
        {
            Debug.Log("Android");
        }
        else
        {
            Debug.Log("Not Android");
        }

        position = transform.position;
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;

            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }
            else
            {
                SetVelocityZero();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatformAndroid)
        {
            //TouchMove();
            AccelerometerMove();
        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -2f, 2f);
        transform.position = position;
    }
}
