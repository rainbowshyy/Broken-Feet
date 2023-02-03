using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2: MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.OnProgress += Progress;
    }

    private void Progress(int step)
    {
        switch (step)
        {
            case 0:
                StartCoroutine(WakeUp());
                break;
            case 1:
                StartCoroutine(KoyaConvoScene());
                break;
            case 2:
                StartCoroutine(SonyaTrash());
                break;
            case 3:
                StartCoroutine(KoyaHitScene());
                break;
        }
    }

    IEnumerator WakeUp()
    {
        DialogueManager.Instance.Fade(true);                //Fade screen from black,          .Fade(true); = Black -> Game        .Fade(false); = Game -> Black
        InputManager.Instance.EnableInputs(false);          //Turn off player inputs
        yield return new WaitForSeconds(1f);                //Delay...
        DialogueManager.Instance.PlayDialogue("D2wake1");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2wake2");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2wake3");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2wake4");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2wake5");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2wake6");
        NPCManager.Instance.NPCtoLocation(NPCType.Koya, LocationType.KoyaDansesal);
        
        

    }

    IEnumerator KoyaConvoScene()
    {
        InputManager.Instance.EnableInputs(false);
        NPCManager.Instance.NPClook(NPCType.Anastasia, NPCManager.Instance.playerTF.position);  //Turn the NPC (Anastasia) to look towards a point (player's position).
        DialogueManager.Instance.PlayDialogue("D2convo1");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2convo2");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2convo3");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D2convo4");





        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.AnastasiaSpisesal);
        yield return new WaitForSeconds(0.5f);                              //Venter et halvt sekund før man sier at anastasia skal sitte hvis hun ikke går, fordi hun bruker litt tid på å begynne å gå. Da unngår vi at hun sitter i før hun går.
        NPCManager.Instance.NPCsit(NPCType.Anastasia, true);                //Sier at når NPC (Anastasia) stopper å gå, så skal hun sitte i stedet for å stå.
        NPCManager.Instance.NPCs[NPCType.Anastasia].sitDir = Vector3.back;  //Sier hvilken retning NPC (Anastasia) skal sitte. (Alltid "sørover"/bakover på Z-aksen).
    }

    IEnumerator SonyaTrash()
    {
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaTrash);                  //Sonya walks to where she will throw the paper with symbol
        yield return new WaitForSeconds(1);
    }

    IEnumerator KoyaHitScene()
    {
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaConvo);
        NPCManager.Instance.NPCtoLocation(NPCType.Koya, LocationType.KoyaHit);
        yield return new WaitForSeconds(1f);
    }
}
