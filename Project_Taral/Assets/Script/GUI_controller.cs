using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GUI_controller : MonoBehaviour
{
    Text statusText;
    Text masterText;
	void Start ()
    {
        statusText = GameObject.Find("StatusText").GetComponent<Text>();
        masterText = GameObject.Find("MasterText").GetComponent<Text>();
    }
	

	void Update ()
    {
        statusText.text = "Status :" + PhotonNetwork.connectionStateDetailed.ToString();
        masterText.text = "isMaster : " + PhotonNetwork.isMasterClient;
    }
}
