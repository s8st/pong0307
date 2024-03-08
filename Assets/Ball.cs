using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Ball : MonoBehaviour
//{
//    public float speed;
//    public Rigidbody2D rigidbody;

    
//    void Start()
//    {
//        rigidbody = GetComponent<Rigidbody2D>();
//        Launch();
//    }

//    private void Launch()
//    {
//        float x = Random.Range(0, 2) == 0 ? -1 : 1;
//        float y = Random.Range(0, 2) == 0 ? -1 : 1;

//        rigidbody.velocity = new Vector2(x* speed, y* speed);
//    }

//    public void Reset()
//    {
//        rigidbody.velocity = Vector2.zero;
//        transform.position = Vector2.zero;
//        Launch();
//    }
//}


public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;

    private void Start()
    {
        // 시작할 때 변수들에 컴포넌트 등을 대입하여 사용하기 위해
        //변수로 만든 rigidbody에 Rigidbody2D 할당하기
        rigidbody = GetComponent<Rigidbody2D>(); 
        Launch(); // 시작하면 Launch() 실행
    }

    private void Launch()
    {
        // 게임 시작하면 (x,y)좌표에 랜덤?
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;

        // rigidbody에 있는 velocity(속도)에 speed 변수에서 설정한 값 곱하기
        rigidbody.velocity = new Vector2(x * speed, y * speed);

        
    }

    // GameManager에서 사용한다. 공의 위치와 속도를 초기화
    // 다시 Launch(); 실행
    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
       
        Launch();
    }


}
