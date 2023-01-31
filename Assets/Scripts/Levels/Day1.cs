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
                StartCoroutine(EatingCutscene());
                break;
        }
    }

    IEnumerator WakeUp()
    {
        DialogueManager.Instance.PlayDialogue("D1wake");
        InputManager.Instance.EnableInputs(false);
        yield return new WaitForSeconds(1f);
        CameraManager.Instance.ToggleCamera(2);
        CameraManager.Instance.ToggleCamera(3);
        yield return new WaitForSeconds(2f);
        CameraManager.Instance.SetBlendTime(0.9f);
        CameraManager.Instance.ToggleCamera(3);
        yield return new WaitForSeconds(3f);
        CameraManager.Instance.SetBlendTime(2f);
        InputManager.Instance.EnableInputs(true);
    }

    IEnumerator EatingCutscene()
    {
        InputManager.Instance.EnableInputs(false);
        CameraManager.Instance.ToggleCamera(0);
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D1eat1");
        yield return new WaitForSeconds(4f);
        DialogueManager.Instance.PlayDialogue("D1eat2");
        yield return new WaitForSeconds(6f);
        DialogueManager.Instance.PlayDialogue("D1eat3");
        yield return new WaitForSeconds(6f);
        DialogueManager.Instance.PlayDialogue("D1eat4");
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.SetBlendTime(0.5f);
        CameraManager.Instance.ToggleCamera(0);
        CameraManager.Instance.ToggleCamera(1);
        yield return new WaitForSeconds(1f);
        DialogueManager.Instance.PlayDialogue("D1eat5");
        yield return new WaitForSeconds(3f);
        CameraManager.Instance.SetBlendTime(2f);
        CameraManager.Instance.ToggleCamera(1);
        CameraManager.Instance.ToggleCamera(0);
        yield return new WaitForSeconds(3f);
        DialogueManager.Instance.PlayDialogue("D1eat6");
        yield return new WaitForSeconds(2f);
        DialogueManager.Instance.PlayDialogue("D1eat7");
        yield return new WaitForSeconds(3f);
        CameraManager.Instance.ToggleCamera(0);
        InputManager.Instance.EnableInputs(true);
    }
}
