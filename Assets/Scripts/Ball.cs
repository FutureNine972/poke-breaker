using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 13f;
    [SerializeField] float randomFactor = 0.5f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(-0.5f, randomFactor), 
            Random.Range(-0.5f, randomFactor));
        
        if (hasStarted)
        {
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void ResetPosition()
    {
        hasStarted = false;
    }
}
