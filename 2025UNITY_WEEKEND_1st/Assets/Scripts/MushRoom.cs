using UnityEngine;

public class MushRoom : MonoBehaviour
{
    // transform이동으로 좌우로 움직이는 코드를 만들어줘.
    // 옆에 충돌할 수 있는 물체가 있으면 어떤 "이벤트"가 발생해야한다.

    public float speed = 5f;

    public int direction = 1; // 1: 오른쪽, -1 : 왼쪽 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = UnityEngine.Random.Range(0, 2); // 0 또는 1이 출력이된다.

        if(rand == 0)
        {
            direction = -1;
        }
        else if(rand == 1)
        {
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(direction, 0, 0) * speed * Time.deltaTime;
    }
}
