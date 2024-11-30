using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float walk_speed, sprint_speed;
    public float health, stamina;
    [SerializeField] private bool sprinting;
    [HideInInspector] public bool alive;
    private Vector2 delta;
    private Rigidbody2D rb;

    private Animator anim;
    void Start()
    {
        alive = true;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        sprinting = Input.GetKey(KeyCode.LeftShift) && (stamina > 0);
        if (Input.GetKeyDown(KeyCode.Space)){
            LayerMask mask = ~LayerMask.GetMask("Ignore Raycast");;
            RaycastHit2D hit_bottom = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f + 0.1f, mask);
            RaycastHit2D hit_left = Physics2D.Raycast(transform.position, -Vector2.right, 0.5f + 0.1f, mask);
            RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right, 0.5f + 0.1f, mask);
            if((hit_bottom) || (hit_left) || (hit_right)){
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        if (alive){
            Move();
        }
    }

    float world_scale = 32f;
    void Move(){
        delta = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float speed = walk_speed;
        if(sprinting){
            speed = sprint_speed;
        }
        speed /= world_scale;
        transform.position += new Vector3(delta.x * speed, delta.y * speed, 0);

        anim.SetBool("sprinting", sprinting);
        anim.SetBool("walking", (delta.x>0));
    }

    public float jump_force = 16f;
    void Jump(){
        rb.AddForce((jump_force*10) * Vector3.up);
    }
}
