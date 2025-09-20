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

    private void OnCollisionEnter2D(Collision2D collision) // �浹���� �� �� �ڵ带 �����ϼ���
    {
        // �浹�� ����� Player�ΰ���?
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ �浹�Ͽ� ������ ����˴ϴ�.");

            rigidbody2d.AddForce(jumpDir.normalized * jumpPower, ForceMode2D.Impulse);

            //Enemy�� �����ϵ��� ��������.
            // rigidbody2d��, ���� ���� ������ ���� �����ϵ��� ��������
        }
    }

}
