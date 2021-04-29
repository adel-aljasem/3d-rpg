using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviourPunCallbacks
{
    public SkinnedMeshRenderer skinnedMesh;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    public void Start()
    {
        skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    public void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                photonView.RPC("Shot", RpcTarget.AllBufferedViaServer);

            }
        }

    }

    [PunRPC]
    public void Shot()
    {
        
        RaycastHit raycastHit;

        
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit))
        {
            if (skinnedMesh != null)
            {
                Destroy(skinnedMesh);
                meshFilter = transform.Find("Character_Soldier_01").gameObject.AddComponent<MeshFilter>();
                meshRenderer = transform.Find("Character_Soldier_01").gameObject.AddComponent<MeshRenderer>();

            }

            meshFilter.sharedMesh = raycastHit.collider.GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = raycastHit.collider.GetComponent<MeshRenderer>().material;
            print(raycastHit.collider.name);

        }
        else
        {
            print("null rayCast");
        }

    }



}
