using UnityEngine;
using System.Collections;

public class PlayerNetworkSync : MonoBehaviour
{

    private Vector3 _correctPlayerPos; // position
    private Quaternion _correctPlayerRot;// rotation
    private PhotonView _view;

    // Use this for initialization
    void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_view.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this._correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this._correctPlayerRot, Time.deltaTime * 5);
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player : senf to the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            //Network player, receive data
            this._correctPlayerPos = (Vector3)stream.ReceiveNext();
            this._correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
    }
}


