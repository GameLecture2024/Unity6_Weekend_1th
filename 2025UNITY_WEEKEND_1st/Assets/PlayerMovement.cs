using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // 이동 속도를 조절하는 변수
    [SerializeField]
    private float moveSpeed = 5f;

    // Rigidbody 2D 컴포넌트 변수
    private Rigidbody2D rb;

    // 입력 방향을 저장하는 변수
    private Vector2 movement;

    // Awake는 Start보다 먼저 호출됩니다. 주로 컴포넌트 초기화에 사용됩니다.
    void Awake()
    {
        // 오브젝트에 있는 Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update는 매 프레임마다 호출됩니다. 입력 처리에 적합합니다.
    void Update()
    {
        // 수평(Horizontal) 및 수직(Vertical) 키 입력을 받습니다.
        // GetAxisRaw는 보간 없이 즉각적인 값을 반환합니다.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 대각선 이동 시 속도가 빨라지는 것을 방지하기 위해 벡터를 정규화(Normalize)합니다.
        // movement.Normalize();
    }

    // FixedUpdate는 물리 계산이 이루어지는 고정된 시간 간격으로 호출됩니다.
    // Rigidbody를 사용하는 움직임 제어에 사용됩니다.
    void FixedUpdate()
    {
        // Rigidbody의 속도(velocity)를 직접 설정하여 오브젝트를 이동시킵니다.
        // movement * moveSpeed는 방향 벡터에 속도를 곱한 값입니다.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}