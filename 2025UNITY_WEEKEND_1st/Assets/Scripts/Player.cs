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
        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
    }

    // AI ��� ����ұ�?
    // ����, Update�Լ�
    // Player �̵� ���� - A,DŰ�� ������ �¿�� �����̰� �ʹ�. spaceŰ�� ������ ������ �ϰ� �ʹ�.
    // Update�Լ��ȿ��� ������ �� �ְ� ����, speed, jumpForce�� ����ؼ� ����� ��������.
    // Transform �̵� ���, Rigidbody ������� �̵�
    // class �̸� Player �����޶�
    // Rigidbody2d �����̴�.
    // ���� ����� ���� ������ �� �ְ�.


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

        // ���� (Space Ű)
        // isGrounded ������ ����Ͽ� ���� ���� ���� ���� ����
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // AddForce�� ����Ͽ� ���� ����
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // �浹 ���� �� ȣ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� "Ground" �±׸� �������� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // �浹 ���� �� ȣ��
    private void OnCollisionExit2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� "Ground" �±׸� �������� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
