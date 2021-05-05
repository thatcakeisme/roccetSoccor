/*
//Script by Child of the beast
//V 1.0
//https://github.com/ChildoftheBeast/VRC-UdonSharp-Scripts
*/
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using System.Collections;

public class Soccor : UdonSharpBehaviour
{
    public GameObject BlueGoal;
    public GameObject RedGoal;
    public GameObject Ball;
    public Text RedTeamScore;
    public Text BlueTeamScore;

    public GameObject[] particlesRed;
    public GameObject[] particlesBlue;


    [UdonSynced]private int Cup;

    public int BlueTeamScoreint = 0;
    public int RedTeamScoreint = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == BlueGoal.transform) 
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "RespawnBall");
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "RedScored");
        }
        if (other.transform.parent == RedGoal.transform)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "RespawnBall");
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "BlueScored");
        }
    }

    public GameObject BallSpawn;
    private Vector3 Ball_Spawn;
    public void RedScored()
    {
        RedTeamScoreint++;
        RedTeamScore.text = RedTeamScoreint.ToString();
    }
    public void BlueScored()
    {
        BlueTeamScoreint++;
        BlueTeamScore.text = RedTeamScoreint.ToString();
    }

    private void Start()
    {
        Ball_Spawn = BallSpawn.transform.position;
    }

    public void RespawnBall()
    {
        Networking.SetOwner(Networking.LocalPlayer, Ball);
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.position = Ball_Spawn;
    }
    public void fireEffectsBlue()
    {
        foreach (GameObject obj in particlesBlue)
        {
            obj.SetActive(false);
            obj.SetActive(true);
        }
    }
    public void fireEffectsRed()
    {
        foreach (GameObject obj in particlesRed)
        {
            obj.SetActive(false);
            obj.SetActive(true);
        }
    }
}