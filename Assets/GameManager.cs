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
