using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    //private float power = 200.0f;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision opponent)
    {
        if ( "Ball" == opponent.gameObject.name ) {
            _animator.Play("Bumper1Animation");
            //_animator.SetTrigger("BallHitTrigger");
            Debug.Log("あたった");
            //Rigidbody playerRigid = opponent.gameObject.GetComponent<Rigidbody>();
            //playerRigid.AddForce(-playerRigid.velocity * power);
        }
    }

}
