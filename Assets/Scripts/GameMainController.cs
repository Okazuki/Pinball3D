using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainController : MonoBehaviour
{
    public GameObject _objBall;
    public GameObject _objShooter;
    public GameObject _objFlipperL;
    public GameObject _objFlipperR;
    private HingeJoint _hingeJointL; // AxisL
    private HingeJoint _hingeJointR; // AxisR
    private JointSpring _jointSpringL; // AxisL
    private JointSpring _jointSpringR; // AxisR
    public float spring = 40000;
    public float openAngle = 30; // 開く角度
    public float closeAngle = -30; // 閉じる角度
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start() - GameMainContloller");
        _hingeJointL = _objFlipperL.GetComponent<HingeJoint>();
        _jointSpringL = _hingeJointL.spring;
        _hingeJointR = _objFlipperR.GetComponent<HingeJoint>();
        _jointSpringR = _hingeJointR.spring;
        // ボールを初期位置に移動
        InitBall();
    }

    // Update is called once per frame
    void Update()
    {
        // 左キーを押す
         if ( Input.GetKey (KeyCode.LeftArrow) ) {
            _jointSpringL.spring = spring;
            _jointSpringL.targetPosition = closeAngle;
            _hingeJointL.spring = _jointSpringL;
        } else {
            _jointSpringL.spring = spring;
            _jointSpringL.targetPosition = openAngle;
            _hingeJointL.spring = _jointSpringL;
        }

        if ( Input.GetKey (KeyCode.RightArrow) ) {
            _jointSpringR.spring = spring;
            _jointSpringR.targetPosition = openAngle;
            _hingeJointR.spring = _jointSpringR;
        } else {
            _jointSpringR.spring = spring;
            _jointSpringR.targetPosition = closeAngle;
            _hingeJointR.spring = _jointSpringR;
        }

    }

    // ボールを初期位置に移動
    public void InitBall()
    {
        Vector3 pos = _objBall.transform.position;
        pos.x = 3.21f;
        pos.y = 0.26f;
        pos.z = 0.0f;
        _objBall.transform.position = pos;
    }

    // ボールを発射　※あとで発射台に押してもらう方式に切り替える
    public void ShotBall()
    {
        Debug.Log("タッチされたにゃー");
        Rigidbody rb = _objBall.GetComponent<Rigidbody> ();
        Vector3 force = new Vector3 (0.0f, 700.0f, 700.0f);
        // ForceMode Force Acceleration Impulse VelocityChange
        rb.AddForce (force, ForceMode.Acceleration);
    }
}
