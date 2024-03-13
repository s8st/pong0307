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

    // 유니티 인스펙터에 키 선택할 수 있게 나타난다.
    public KeyCode Up;
    public KeyCode Down;

    private float movement;
    private Vector3 startPosition;

    // Start에서 변수들을 할당해 준다.
    // 이후 함수들에서 사용할 준비를 한다
    private void Start()
    {
        // Paddle.cs는 게임오브젝트인 Player1, Player2에 연결된다
        //연결된 Player1, Player2의 위치값을 변수에 넣는다.
        startPosition = transform.position;

        // 변수에 Rigidbody2D 컴포넌트를 넣는다.
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = 0f;

        // 만약 Input에 키가 Up이라면  movement = 1f;
        // public KeyCode Up ---> 입력받은 키를 확인해서 movement 값 변경
        if (Input.GetKey(Up)) { movement += 1f; }
        if (Input.GetKey(Down)) {  movement -= 1f; }

        // velocity에 위 아래의 y값을 변경 --> 키값에 따라 위 아래로 움직이게 만든다
        rigidbody.velocity = new Vector2(0, movement * speed);

    }

    // 득점이 플레이어 1이나 플레이어2에서 발생하면 GameManager에서 호출함 --->   private void ResetPosition()
    public void Reset()
    {
        // Vector2 == Vector3
        //rigidbody.velocity = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
        // startPosition은 유니티 시작시 위치를 대입했기에 시작위치로 되돌린다.
        transform.position = startPosition;
    }


}