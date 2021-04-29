using Cinemachine;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPunCallbacks, IPunObservable
{
    Rigidbody rigidbodyy;
    Vector3 vector3;
    Camera cameraa;
    Animator animator;

    public void Start()
    {
        cameraa = GetComponentInChildren<Camera>();
        animator = GetComponent<Animator>();
        rigidbodyy = GetComponent<Rigidbody>();

        cameraa.enabled = false;

        if (photonView.IsMine)
        {
            cameraa.enabled = true;
        }
       
    }

    public void Update()
    {
        if (!photonView.IsMine) return;
        Movement();
        Animation();


    }

    private void Movement()
    {
        vector3.x = Input.GetAxis("Horizontal");
        vector3.z = Input.GetAxis("Vertical");
        transform.Translate(vector3 * Time.deltaTime, Space.Self);
       

    }

    private void Animation()
    {
        animator.SetFloat("MoveX", vector3.x);
        animator.SetFloat("MoveY", vector3.z);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.rotation);
        }
        else
        {
            transform.rotation = (Quaternion) stream.ReceiveNext();
        }
    }
}

