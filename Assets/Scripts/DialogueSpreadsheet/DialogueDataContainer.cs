using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NorskaLib.GoogleSheetsDatabase;
[CreateAssetMenu(fileName = "DataContainer", menuName = "Custom/DataContainer")]
public class DialogueDataContainer : DataContainerBase
{
    [PageName("DialoguePage")]
    public List<DialogueData> dialogueData;
}
