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