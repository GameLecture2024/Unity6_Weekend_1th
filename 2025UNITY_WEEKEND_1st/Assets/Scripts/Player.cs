using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded = false;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
    }

    // AI 어떻게 사용할까?
    // 변수, Update함수
    // Player 이동 구현 - A,D키를 눌러서 좌우로 움직이고 싶다. space키를 누르면 점프도 하고 싶다.
    // Update함수안에서 실행할 수 있게 해줘, speed, jumpForce를 사용해서 기능을 구현해줘.
    // Transform 이동 방식, Rigidbody 방식으로 이동
    // class 이름 Player 만들어달라
    // Rigidbody2d 게임이다.
    // 땅을 밟았을 때만 점프할 수 있게.


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

        // 점프 (Space 키)
        // isGrounded 변수를 사용하여 땅에 있을 때만 점프 가능
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // AddForce를 사용하여 점프 구현
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // 충돌 시작 시 호출
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "Ground" 태그를 가졌는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // 충돌 종료 시 호출
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "Ground" 태그를 가졌는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
