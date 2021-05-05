
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using UnityEngine.UI;

public class ResetButton : UdonSharpBehaviour
{
    public Soccor soccorthing;
    public Text RedTeamScore;
    public Text BlueTeamScore;
    private void Interact()
    {
        SendCustomNetworkEvent(NetworkEventTarget.All, nameof(resestGame));

    }
    public void resestGame() {
        soccorthing.BlueTeamScoreint = 0;
        soccorthing.RedTeamScoreint = 0;
        RedTeamScore.text = "0";
        BlueTeamScore.text = "0";
    }
}
