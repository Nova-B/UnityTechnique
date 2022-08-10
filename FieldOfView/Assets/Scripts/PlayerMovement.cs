using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        /*Vector3 dir = (input.h * Vector3.right + input.v * Vector3.forward).normalized;
        rigid.MovePosition(rigid.position + dir * Time.fixedDeltaTime * moveSpeed);
        //rigid.angularVelocity = Vector3.zero;
        transform.LookAt(transform.position + dir);*/
        rigid.MovePosition(rigid.position + input.v * transform.forward * Time.fixedDeltaTime * moveSpeed);
        rigid.rotation = rigid.rotation * Quaternion.Euler(input.h * Vector3.up * Time.fixedDeltaTime * rotSpeed);

    }
}
