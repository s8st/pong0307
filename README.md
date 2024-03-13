# pong0307

|스크립트|필드|함수|동작|
|--|--|--|--|
|**Ball.cs**|public float speed;<br> public Rigidbody2D rigidbody;|<kbd>Start()</kbd> <br> <kbd>Launch()</kbd> <br> <kbd>Reset()</kbd>| Start(){rigidbody = GetComponent<Rigidbody2D>();  <br>Launch(); }|
|**Goal.cs**|public bool isPlayer1Goal; <br> private GameManager gameManager;|Start()<br>OnTriggerEnter2D(Collider2D collision)| if (collision.name.Equals("Ball"))<br>{if (isPlayer1Goal) else} |
|**Paddle.cs**| public bool isPlayer1;<br> public float speed;<br> public Rigidbody2D rigidbody; public KeyCode Up;<br> public KeyCode Down;<br> private float movement;<br> private Vector3 startPosition;|Start()<br>Update()<br>Reset()||
|**GameManager.cs**|public Ball ball;<br> public Paddle player1Paddle;<br>**~public Goal player1Goal;~**<br> public Paddle player2Paddle;<br>**~public Goal player2Goal;~**<br> public TextMeshProUGUI player1Text;<br> public TextMeshProUGUI player2Text;<br> private int player1Score;<br> private int player2Score;   |Player1Scored()<br>Player2Scored()<br>ResetPosition()||
||**~public Goal player1Goal;~**<br> **~public Goal player2Goal;~**<br>삭제해도 문제가 없다. 사용하는 메서드가 없음||


--- 

`Ball.cs` :  

  - Rigidbody2D 할당하고 Launch();
    
```c#
  private void Start()
  {
      // 시작할 때 변수들에 컴포넌트 등을 대입하여 사용하기 위해
      //변수로 만든 rigidbody에 Rigidbody2D 할당하기
      rigidbody = GetComponent<Rigidbody2D>(); 
      Launch(); // 시작하면 Launch() 실행
  }

```


- 공이 나가는 방향 랜덤으로  

```c#
  private void Launch()
  {
      // 게임 시작하면 (x,y)좌표에 랜덤?
      // 볼이 나가는 방향을 랜덤으로 하기 위해서
      // (1,1) -->1사분면으로 (-1,-1) ---> 3사분면으로 
      float x = Random.Range(0,2) == 0 ? -1 : 1;
      float y = Random.Range(0,2) == 0 ? -1 : 1;

      // rigidbody에 있는 velocity(속도)에 speed 변수에서 설정한 값 곱하기
      rigidbody.velocity = new Vector2(x * speed, y * speed);

      
  }
  ``` 


- 공의 위치와 속도,방향 초기화하고 Launch();
```c#
  public void Reset()
  {
      rigidbody.velocity = Vector2.zero;
      rigidbody.position = Vector2.zero;
     
      Launch();
  }
```
---


`Goal.cs` :  

- GameManager 할당, --> gameManager.Player2Scored(); 실행하기 위해서

```c#
 private void Start()
 {
     // gameManager = GetComponent<GameManager>();
     // Goal에 GameManager를 직접 달 수 없다
     // GameManager.cs는 GameManager의 컴포넌트에 달려있다

     // Find("GameManager") : GameManager를 찾아서 컴포넌트 GameManager.cs를 대입하라
     gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


 }

```

- Goal.cs는 골대역할을 하는 Player1Goal과 Player2Goal에 연결됨
- 즉 골대에 충돌한 물체가 Ball인지 확인하고,
- isPlayer1Goal이 체크된(유니티에서 Player1Goal에 연결된 Goal.cs의 isPlayer1Goal) 상태라면 ==true
- gameManager.Player2Scored(); --> 게임메니저의 Player2Scored()를 호출하라
```c#  
 // 충돌트리거 
 private void OnTriggerEnter2D(Collider2D collision)
 {
     // 충돌체 이름이 Ball이라면
     // Equals("")
     if (collision.name.Equals("Ball"))
     {
         if (isPlayer1Goal) //플레이어1에 체크해서 true라면
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


---  

`Paddle.cs`  :

- 탁구채 startPosition 초기화
- rigidbody 초기화
```c#
 private void Start()
 {
     // Paddle.cs는 게임오브젝트인 Player1, Player2에 연결된다
     //연결된 Player1, Player2의 위치값을 변수에 넣는다.
     startPosition = transform.position;

     // 변수에 Rigidbody2D 컴포넌트를 넣는다.
     rigidbody = GetComponent<Rigidbody2D>();
 }
```
- 입력받은 키값으로 위 아래로 움직임
- velocity에 상하 움직임 * speed
```c#  
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

```  
- 속도,방향 초기화
- 시작점 초기화
```c#   
 public void Reset()
 {
     rigidbody.velocity = Vector3.zero;
     // startPosition은 유니티 시작시 위치를 대입했기에 시작위치로 되돌린다.
     transform.position = startPosition;
 }
```



---  



`GameManager.cs`  :

- player1Score 숫자를 올리고
- 점수판에 문자열로 대입
- 공과 탁구채 초기화
```c#  
 public void Player1Scored()
 {
     // player1Score++  ---> 1점 올린다
     player1Score++;

     //  private int player1Score;  를 문자열로 변환 
     player1Text.text = player1Score.ToString();

     ResetPosition();

 }
```

- player2Score 숫자를 올리고
- 점수판에 문자열로 대입
- 공과 탁구채 초기화
```c#  
 public void Player2Scored()
 {
     player2Score++;
     player2Text.text = player2Score.ToString();
     ResetPosition();

 }
```
- player1Score 숫자를 올리고
- 점수판에 문자열로 대입
- 공과 탁구채 초기화
```c#  
 private void ResetPosition()
 {
     // 게임오브젝트 Ball연결시킨 Ball.cs 컴포넌트에 있는 Reset()메서드 실행
     ball.Reset();
     player1Paddle.Reset();
     player2Paddle.Reset();
 }

```


---   







---

![Unity_IboNXQ0UZH](https://github.com/s8st/pong0307/assets/153998744/85c190a8-a87f-4dae-b051-771d530210e5)


 ---
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
        // 볼이 나가는 방향을 랜덤으로 하기 위해서
        // (1,1) -->1사분면으로 (-1,-1) ---> 3사분면으로 
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
    public bool isPlayer1Goal;
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
            if (isPlayer1Goal)
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



}
```

> Paddle.cs

```c#
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

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        // startPosition은 유니티 시작시 위치를 대입했기에 시작위치로 되돌린다.
        transform.position = startPosition;
    }


}
```


> Gamemanager.cs

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    [Header("Ball")]
//    public Ball ball;

//    [Header("Player 1")]
//    public Paddle player1Paddle;
//    public Goal player1Goal;

//    [Header("Player 2")]
//    public Paddle player2Paddle;
//    public Goal player2Goal;

//    [Header("UI")]
//    public TextMeshProUGUI player1Text;
//    public TextMeshProUGUI player2Text;

//    private int player1Score;
//    private int player2Score;

//    public void Player1Scored()
//    {
//        player1Score++;
//        player1Text.text = player1Score.ToString();
//        ResetPosition();
//    }

//    public void Player2Scored()
//    {
//        player2Score++;
//        player2Text.text = player2Score.ToString();
//        ResetPosition();
//    }

//    private void ResetPosition()
//    {
//        ball.Reset();
//        player1Paddle.Reset();
//        player2Paddle.Reset();        
//    }
//}




public class GameManager : MonoBehaviour
{
    // public 다음에 Ball , Paddle , Goal , TextMeshProUGUI 
    // 스크립트를 기준으로 만드는 건가?

    [Header("Ball")]
    public Ball ball; // 유니티에서 하이어라키의 Ball 게임오브젝트를 인스펙터에 연결시키기
    
    [Header("Player 1")]
    public Paddle player1Paddle; // Paddle을 끼워넣기
    public Goal player1Goal;

    [Header("Player 2")]
    public Paddle player2Paddle;
    public Goal player2Goal;

    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    private int player1Score;
    private int player2Score;   

    
    public void Player1Scored()
    {
        // player1Score++  ---> 1점 올린다
        player1Score++;

        //  private int player1Score;  를 문자열로 변환 
        player1Text.text = player1Score.ToString();

        ResetPosition();

    }

    public void Player2Scored()
    {
        player2Score++;
        player2Text.text = player2Score.ToString();
        ResetPosition();

    }

    private void ResetPosition()
    {
        // 게임오브젝트 Ball연결시킨 Ball.cs 컴포넌트에 있는 Reset()메서드 실행
        ball.Reset();
        player1Paddle.Reset();
        player2Paddle.Reset();
    }
}

```




