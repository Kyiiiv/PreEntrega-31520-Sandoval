using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 1000f;
    public Animator movAnim;
    public Vector3 turn;

    [SerializeField]
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MovimientoPlayer();
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
       
    }

    void MovimientoPlayer()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        
        Vector3 inputPlayer = new Vector3(hor, 0, ver);

        rb.AddForce(inputPlayer * speed * Time.deltaTime);

        if(inputPlayer == Vector3.zero)
        {
            movAnim.SetBool("Mov", false);
        }
        else
        {
            movAnim.SetBool("Mov", true);
        }

    }


}
