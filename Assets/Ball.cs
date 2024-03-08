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
        // ������ �� �����鿡 ������Ʈ ���� �����Ͽ� ����ϱ� ����
        //������ ���� rigidbody�� Rigidbody2D �Ҵ��ϱ�
        rigidbody = GetComponent<Rigidbody2D>(); 
        Launch(); // �����ϸ� Launch() ����
    }

    private void Launch()
    {
        // ���� �����ϸ� (x,y)��ǥ�� ����?
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;

        // rigidbody�� �ִ� velocity(�ӵ�)�� speed �������� ������ �� ���ϱ�
        rigidbody.velocity = new Vector2(x * speed, y * speed);

        
    }

    // GameManager���� ����Ѵ�. ���� ��ġ�� �ӵ��� �ʱ�ȭ
    // �ٽ� Launch(); ����
    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
       
        Launch();
    }


}
