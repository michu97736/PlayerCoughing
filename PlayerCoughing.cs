using MSCLoader;
using UnityEngine;
using HutongGames.PlayMaker;
using MSCLoader.Helper;

namespace PlayerCoughing
{
    public class PlayerCoughing : Mod
    {
        public override string ID => "PlayerCoughing";
        public override string Name => "PlayerCoughing";
        public override string Author => "michu97736";
        public override string Version => "1.0";
        public override string Description => "Adds player coughing after smoking";
        public FsmFloat cig;
        public float cigfloat = 0.2f;
        public Transform Player;
        public FsmBool cigboolactive;
        public override void OnLoad()
        {
            GameObject ciggameobject = GameObject.Find("PLAYER").transform.Find("Pivot/AnimPivot/Camera/FPSCamera/FPSCamera/Smoking").gameObject;
            cig = ciggameobject.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmFloat("CigaretteScale");
            Player = GameObject.Find("PLAYER").transform;
            cigboolactive = ciggameobject.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("CigaretteBurn");

        }

        public override void Update()
        {
            if(cig.Value >= 0 && cigboolactive.Value == true)
            {
                if(cInput.GetKeyUp("Smoking"))
                {
                    ModHelper.PlaySound3D(Player, "Theatre", "cough1");
                }
            }
        }
    }
}
