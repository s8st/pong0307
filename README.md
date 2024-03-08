# pong0307
 
![image](https://github.com/s8st/pong0307/assets/153998744/c9fce42c-c756-4866-a9e3-e171f24dbd99)

- 강의 내용 코딩연습
- vs 창 분할 가능하다

```c#
rigidbody.velocity = new Vector2(x * speed, y * speed);
```
![image](https://github.com/s8st/pong0307/assets/153998744/0c01cf3d-4c74-49de-818f-f88a72dc88c1)



---
---
> Ball.cs

```c#
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

```

> Goal.cs
```c#
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//public class Goal : MonoBehaviour
//{
//    public bool isPlayer1Goal;
//    private GameManager gameManager;

//    private void Start()
//    {
//        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.name.Equals("Ball"))
//        {
//            if(isPlayer1Goal)
//            {
//                Debug.Log("Player 2 Scored");
//                gameManager.Player2Scored();
//            }
//            else
//            {
//                Debug.Log("Player 1 Scored");
//                gameManager.Player1Scored();
//            }
//        }
//    }
//}


public class Goal : MonoBehaviour
{
    public bool IsPlayerGoal;
    private GameManager gameManager;

    private void Start()
    {
        // gameManager = GetComponent<GameManager>();
        // Goal에 GameManager를 직접 달 수 없다
        // GameManager.cs는 GameManager의 컴포넌트에 달려있다

        // Find("GameManager") : GameManager를 찾아서 컴포넌트 GameManager.cs를 대입하라
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    // 충돌트리거 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌체 이름이 Ball이라면
        // Equals("")
        if (collision.name.Equals("Ball"))
        {
            Debug.Log("Player 2 Scored");
            // Player2Scored 실행하라
            gameManager.Player2Scored();
        }
        else
        {
            Debug.Log("Player 1 Scored");
            gameManager.Player1Scored();
        }

    }



}
```



