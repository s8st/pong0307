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
    // public ������ Ball , Paddle , Goal , TextMeshProUGUI 
    // ��ũ��Ʈ�� �������� ����� �ǰ�?

    [Header("Ball")]
    public Ball ball; // ����Ƽ���� ���̾��Ű�� Ball ���ӿ�����Ʈ�� �ν����Ϳ� �����Ű��
    
    [Header("Player 1")]
    public Paddle player1Paddle; // Paddle�� �����ֱ�
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
        // player1Score++  ---> 1�� �ø���
        player1Score++;

        //  private int player1Score;  �� ���ڿ��� ��ȯ 
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
        // ���ӿ�����Ʈ Ball�����Ų Ball.cs ������Ʈ�� �ִ� Reset()�޼��� ����
        ball.Reset();
        player1Paddle.Reset();
        player2Paddle.Reset();
    }
}
