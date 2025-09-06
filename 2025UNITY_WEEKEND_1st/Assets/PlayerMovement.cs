using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // �̵� �ӵ��� �����ϴ� ����
    [SerializeField]
    private float moveSpeed = 5f;

    // Rigidbody 2D ������Ʈ ����
    private Rigidbody2D rb;

    // �Է� ������ �����ϴ� ����
    private Vector2 movement;

    // Awake�� Start���� ���� ȣ��˴ϴ�. �ַ� ������Ʈ �ʱ�ȭ�� ���˴ϴ�.
    void Awake()
    {
        // ������Ʈ�� �ִ� Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update�� �� �����Ӹ��� ȣ��˴ϴ�. �Է� ó���� �����մϴ�.
    void Update()
    {
        // ����(Horizontal) �� ����(Vertical) Ű �Է��� �޽��ϴ�.
        // GetAxisRaw�� ���� ���� �ﰢ���� ���� ��ȯ�մϴ�.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // �밢�� �̵� �� �ӵ��� �������� ���� �����ϱ� ���� ���͸� ����ȭ(Normalize)�մϴ�.
        // movement.Normalize();
    }

    // FixedUpdate�� ���� ����� �̷������ ������ �ð� �������� ȣ��˴ϴ�.
    // Rigidbody�� ����ϴ� ������ ��� ���˴ϴ�.
    void FixedUpdate()
    {
        // Rigidbody�� �ӵ�(velocity)�� ���� �����Ͽ� ������Ʈ�� �̵���ŵ�ϴ�.
        // movement * moveSpeed�� ���� ���Ϳ� �ӵ��� ���� ���Դϴ�.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}