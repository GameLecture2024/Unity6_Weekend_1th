using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rigidbody2D; // 컴포넌트 부착한 물리 기능을 rigidbody2D 변수를 이용해서 사용하겠다.
    [SerializeField] float jumpPower = 5;
    [SerializeField] Vector2 dir;

    [SerializeField] LayerMask groundLayer; // 누가 땅인지 설정해주는 것 (Ground, default)
    [SerializeField] float groundCheckDistance = 2f; // GrounddistanceCheck 땅과의 거리체크를 위한 거리

    // 플레이어 게임오브젝트 안에 있는 Rigidbody2D 컴포넌트를 rigidbody2D안에 저장하고 싶다.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Vector2. up,down,left,right 변경해보세요.
        // Vector2.up * 5
        // 저장을 한다음에 게임을 실행해보세요

        //rigidbody2D.AddForce(dir.normalized * jumpPower, ForceMode2D.Impulse);
    }

    // AddForce : 힘을 추가하다. 점프 -> 위로 힘을 가한다.

    // Update is called once per frame
    void Update()
    {
        // Spacebar눌렀을 때 점프하고싶다.
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody2D.AddForce(dir.normalized * jumpPower, ForceMode2D.Impulse);
        }
    }
    bool IsGrounded() //땅을밟고있나요?
    {
       return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, 
            transform.position + (Vector3)(Vector2.down * groundCheckDistance));
    }
}
