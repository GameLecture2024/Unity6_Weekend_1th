using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] Vector2 moveDir;
    [SerializeField] Vector2 jumpDir;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.linearVelocity = moveDir.normalized * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) // 충돌했을 때 이 코드를 실행하세요
    {
        // 충돌한 대상이 Player인가요?
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어가 충돌하여 게임이 종료됩니다.");

            rigidbody2d.AddForce(jumpDir.normalized * jumpPower, ForceMode2D.Impulse);

            //Enemy가 점프하도록 만들어보세요.
            // rigidbody2d와, 점프 관련 변수를 만들어서 점프하도록 만들어보세요
        }
    }

}
