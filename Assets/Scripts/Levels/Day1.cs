using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : MonoBehaviour
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
                StartCoroutine(BullyCutscene());
                break;
            case 2:
                StartCoroutine(EatingCutscene());
                break;
        }
    }

    IEnumerator WakeUp()
    {
        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.SpisesalExterior1);
        NPCManager.Instance.NPCtoLocation(NPCType.Koya, LocationType.KoyaConvo);
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaConvo);
        InputManager.Instance.EnableInputs(false);
        yield return new WaitForSeconds(1f);
        DialogueManager.Instance.PlayDialogue("D1wake2");
        yield return new WaitForSeconds(1f);
        CameraManager.Instance.ToggleCamera(2);
        CameraManager.Instance.ToggleCamera(3);
        yield return new WaitForSeconds(2f);
        CameraManager.Instance.SetBlendTime(0.9f);
        CameraManager.Instance.ToggleCamera(3);
        DialogueManager.Instance.PlayDialogue("D1wake1");
        CameraManager.Instance.SetBlendTime(2f);
        yield return new WaitForSeconds(2f);
        InputManager.Instance.EnableInputs(true);
    }

    IEnumerator BullyCutscene()
    {
        InputManager.Instance.EnableInputs(false);
        NPCManager.Instance.NPClook(NPCType.Anastasia, NPCManager.Instance.playerTF.position);
        DialogueManager.Instance.PlayDialogue("D1bully");
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.SetBlendTime(0.8f);
        CameraManager.Instance.ToggleCamera(1);
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat1");
        yield return new WaitForSeconds(3.5f);
        DialogueManager.Instance.PlayDialogue("D1eat2");
        yield return new WaitForSeconds(1f);
        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.SpisesalExterior2);
        yield return new WaitForSeconds(1.5f);
        DialogueManager.Instance.PlayDialogue("D1eat3");
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D1eat4");
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.SetBlendTime(2f);
        CameraManager.Instance.ToggleCamera(1);
        yield return new WaitForSeconds(1.5f);
        InputManager.Instance.EnableInputs(true);

        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.AnastasiaSpisesal);
        yield return new WaitForSeconds(0.5f); // venter et halvt sekund før man sier at anastasia skal sitte hvis hun ikke går, fordi hun bruker litt tid på å begynne å gå. Da unngår vi at hun sitter i før hun går.
        NPCManager.Instance.NPCsit(NPCType.Anastasia, true);
        NPCManager.Instance.NPCs[NPCType.Anastasia].sitDir = Vector3.back;
    }

    IEnumerator EatingCutscene()
    {
        InputManager.Instance.EnableInputs(false);
        CameraManager.Instance.ToggleCamera(0);
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat5");
        yield return new WaitForSeconds(5f);
        DialogueManager.Instance.PlayDialogue("D1eat6");
        yield return new WaitForSeconds(5f);
        DialogueManager.Instance.PlayDialogue("D1eat7");
        yield return new WaitForSeconds(6f);
        DialogueManager.Instance.PlayDialogue("D1eat8");
        yield return new WaitForSeconds(1.5f);
        DialogueManager.Instance.PlayDialogue("D1eat9");
        yield return new WaitForSeconds(2.5f);
        DialogueManager.Instance.PlayDialogue("D1eat10");
        yield return new WaitForSeconds(6f);
        DialogueManager.Instance.PlayDialogue("D1eat11");
        yield return new WaitForSeconds(3f);
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaBell);
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat12");
        yield return new WaitForSeconds(4f);
        DialogueManager.Instance.PlayDialogue("D1eat13");
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat14");
        yield return new WaitForSeconds(1f);
        CameraManager.Instance.ToggleCamera(4);
        CameraManager.Instance.ToggleCamera(0);
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D1eat15");
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat16");
        yield return new WaitForSeconds(1f);
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaDansesal);
        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.SpisesalExterior2);
        NPCManager.Instance.NPCsit(NPCType.Anastasia, false);
        yield return new WaitForSeconds(3f);
        CameraManager.Instance.ToggleCamera(4);
        InputManager.Instance.EnableInputs(true);
    }

    IEnumerator DanceCutscene()
    {
        yield return new WaitForSeconds(1f);
    }
}
