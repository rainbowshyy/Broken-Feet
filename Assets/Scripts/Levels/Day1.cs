using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    [SerializeField] private GameObject bullyBlock;
    [SerializeField] private GameObject danceBlock;
    [SerializeField] private GameObject diary;
    [SerializeField] private GameObject diaryInt;

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
            case 3:
                StartCoroutine(DanceCutscene());
                break;
            case 4:
                StartCoroutine(Diary());
                break;
        }
    }

    IEnumerator WakeUp()
    {
        DialogueManager.Instance.Fade(true);                //Fade screen from black,          .Fade(true); = Black -> Game        .Fade(false); = Game -> Black
        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.SpisesalExterior1);       //Anastasia walks to where she will converse with the others, and later start BullyCutscene()
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaConvo);                  //Sonya walks to where she will stand with Koya
        InputManager.Instance.EnableInputs(false);          //Turn off player inputs
        yield return new WaitForSeconds(1f);                //Delay...
        DialogueManager.Instance.PlayDialogue("D1wake2");   //Play dialogue with the ID "D1wake2" (look at the spreadsheet)
        yield return new WaitForSeconds(1f);
        CameraManager.Instance.ToggleCamera(2);             //Toggle camera 2 (see the list in CameraManager). (This disables the camera, as it starts enabled). (When no camera is enabled, the 1st person view is used as main camera).
        CameraManager.Instance.ToggleCamera(3);             //Toggle camera 3 (This enables the camera).
        yield return new WaitForSeconds(2f);
        NPCManager.Instance.NPCtoLocation(NPCType.Koya, LocationType.KoyaConvo);
        CameraManager.Instance.SetBlendTime(0.9f);          //Change the transition time between camera switches. (Default is 2 seconds, here we change to 0.9 seconds to make the transition faster).
        CameraManager.Instance.ToggleCamera(3);             //Toggle camera 3 (This now disables the camera).
        DialogueManager.Instance.PlayDialogue("D1wake1");
        CameraManager.Instance.SetBlendTime(2f);            //Set the blend time back to 2 seconds.
        yield return new WaitForSeconds(2f);
        InputManager.Instance.EnableInputs(true);           //Turn on player inputs again.
    }

    IEnumerator BullyCutscene()
    {
        InputManager.Instance.EnableInputs(false);
        bullyBlock.SetActive(false);
        NPCManager.Instance.NPClook(NPCType.Anastasia, NPCManager.Instance.playerTF.position);  //Turn the NPC (Anastasia) to look towards a point (player's position).
        DialogueManager.Instance.PlayDialogue("D1bully");
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.SetBlendTime(0.8f);
        CameraManager.Instance.ToggleCamera(1);
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat1");
        yield return new WaitForSeconds(3.5f);
        DialogueManager.Instance.PlayDialogue("D1eat2");
        yield return new WaitForSeconds(1f);
        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.SpisesalExterior2); //Make the NPC (Anastasia) walk to a location (SpisesalExterior2). (Look at the list "Locations" in NPCManager).
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
        yield return new WaitForSeconds(0.5f);                              //Venter et halvt sekund før man sier at anastasia skal sitte hvis hun ikke går, fordi hun bruker litt tid på å begynne å gå. Da unngår vi at hun sitter i før hun går.
        NPCManager.Instance.NPCsit(NPCType.Anastasia, true);                //Sier at når NPC (Anastasia) stopper å gå, så skal hun sitte i stedet for å stå.
        NPCManager.Instance.NPCs[NPCType.Anastasia].sitDir = Vector3.back;  //Sier hvilken retning NPC (Anastasia) skal sitte. (Alltid "sørover"/bakover på Z-aksen).
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
        yield return new WaitForSeconds(5f);
        DialogueManager.Instance.PlayDialogue("D1eat8");
        yield return new WaitForSeconds(1.5f);
        DialogueManager.Instance.PlayDialogue("D1eat9");
        yield return new WaitForSeconds(2.5f);
        DialogueManager.Instance.PlayDialogue("D1eat10");
        yield return new WaitForSeconds(6f);
        DialogueManager.Instance.PlayDialogue("D1eat11");
        yield return new WaitForSeconds(3f);
        NPCManager.Instance.NPCtoLocation(NPCType.Sonya, LocationType.SonyaBell);   //Sonya begynner å gå her, slik at hun kommer inn døren på riktig timing.
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
        NPCManager.Instance.NPCtoLocation(NPCType.Anastasia, LocationType.AnastasiaDansesal);
        NPCManager.Instance.NPCtoLocation(NPCType.Koya, LocationType.KoyaDansesal);
        NPCManager.Instance.NPCsit(NPCType.Anastasia, false);
        yield return new WaitForSeconds(3f);
        CameraManager.Instance.ToggleCamera(4);
        InputManager.Instance.EnableInputs(true);
        danceBlock.SetActive(true);
    }

    IEnumerator DanceCutscene()
    {
        InputManager.Instance.EnableInputs(false);
        yield return new WaitForSeconds(1f);
        DialogueManager.Instance.Fade(false);
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayCutscene("D1dance1");
        yield return new WaitForSeconds(8f);
        DialogueManager.Instance.PlayCutscene("D1dance2");
        yield return new WaitForSeconds(4f);
        DialogueManager.Instance.PlayCutscene("D1dance3");
        yield return new WaitForSeconds(6f);
        DialogueManager.Instance.PlayCutscene("D1dance4");
        CameraManager.Instance.ToggleCamera(5);
        yield return new WaitForSeconds(5f);
        NPCManager.Instance.playerTF.position = NPCManager.Instance.Locations[LocationType.PlayerWakeup].position;
        DialogueManager.Instance.Fade(true);
        NPCManager.Instance.NPClook(NPCType.Sonya, NPCManager.Instance.playerTF.position);
        NPCManager.Instance.NPClook(NPCType.Koya, NPCManager.Instance.playerTF.position);
        yield return new WaitForSeconds(1f);
        DialogueManager.Instance.PlayDialogue("D1dance5");
        yield return new WaitForSeconds(7f);
        CameraManager.Instance.ToggleCamera(5);
        InputManager.Instance.EnableInputs(true);
        yield return new WaitForSeconds(1f);
        DialogueManager.Instance.PlayDialogue("D1dance6");
        diaryInt.SetActive(true);
    }

    IEnumerator Diary()
    {
        InputManager.Instance.EnableInputs(false);
        yield return new WaitForSeconds(0.5f);
        DialogueManager.Instance.Fade(false);
        diary.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DiaryManager.Instance.TurnPage(false);
    }
}
