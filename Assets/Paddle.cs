using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Paddle : MonoBehaviour
//{
//    public bool isPlayer1;
//    public float speed;
//    public Rigidbody2D rigidbody;

//    public KeyCode Up;
//    public KeyCode Down;

//    private float movement;
//    private Vector3 startPosition;

//    void Start()
//    {
//        startPosition = transform.position;
//        rigidbody = GetComponent<Rigidbody2D>();
//    }


//    void Update()
//    {
//        movement = 0f;
//        if(Input.GetKey(Up)) { movement += 1f; }
//        if(Input.GetKey(Down)) { movement -= 1f; }
//        rigidbody.velocity = new Vector2(0, movement * speed);    
//    }

//    public void Reset()
//    {
//        rigidbody.velocity = Vector3.zero;
//        transform.position = startPosition;
//    }
//}
public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rigidbody;

    // ����Ƽ �ν����Ϳ� Ű ������ �� �ְ� ��Ÿ����.
    public KeyCode Up;
    public KeyCode Down;

    private float movement;
    private Vector3 startPosition;

    // Start���� �������� �Ҵ��� �ش�.
    // ���� �Լ��鿡�� ����� �غ� �Ѵ�
    private void Start()
    {
        // Paddle.cs�� ���ӿ�����Ʈ�� Player1, Player2�� ����ȴ�
        //����� Player1, Player2�� ��ġ���� ������ �ִ´�.
        startPosition = transform.position;

        // ������ Rigidbody2D ������Ʈ�� �ִ´�.
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = 0f;

        // ���� Input�� Ű�� Up�̶��  movement = 1f;
        // public KeyCode Up ---> �Է¹��� Ű�� Ȯ���ؼ� movement �� ����
        if (Input.GetKey(Up)) { movement += 1f; }
        if (Input.GetKey(Down)) {  movement -= 1f; }

        // velocity�� �� �Ʒ��� y���� ���� --> Ű���� ���� �� �Ʒ��� �����̰� �����
        rigidbody.velocity = new Vector2(0, movement * speed);

    }

    // ������ �÷��̾� 1�̳� �÷��̾�2���� �߻��ϸ� GameManager���� ȣ���� --->   private void ResetPosition()
    public void Reset()
    {
        // Vector2 == Vector3
        //rigidbody.velocity = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
        // startPosition�� ����Ƽ ���۽� ��ġ�� �����߱⿡ ������ġ�� �ǵ�����.
        transform.position = startPosition;
    }


}