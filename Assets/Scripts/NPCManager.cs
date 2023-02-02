using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private Location[] locationStructs;
    [SerializeField] private NPCstruct[] npcStructs;

    public Transform playerTF;

    public Dictionary<LocationType, Transform> Locations;
    public Dictionary<NPCType, NPC> NPCs;

    public static NPCManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        Locations = new Dictionary<LocationType, Transform>();
        foreach (Location l in locationStructs)
        {
            Locations.Add(l.id, l.transform);
        }

        NPCs = new Dictionary<NPCType, NPC>();
        foreach (NPCstruct n in npcStructs)
        {
            NPCs.Add(n.id, n.npcRef);
        }
    }

    public void NPCtoLocation(NPCType NPC, LocationType Location)
    {
        NPCs[NPC].MoveTo(Locations[Location].position);
    }

    public void NPClook(NPCType NPC, Vector3 pos)
    {
        NPCs[NPC].LookTowards(pos);
    }

    public void NPCdir(NPCType NPC, Vector3 dir)
    {
        NPCs[NPC].LookDirection(dir);
    }

    public void NPCsit(NPCType NPC, bool sit)
    {
        NPCs[NPC].Sit(sit);
    }
}

[System.Serializable]
public struct Location
{
    public LocationType id;
    public Transform transform;
}

[System.Serializable]
public struct NPCstruct
{
    public NPCType id;
    public NPC npcRef;
}

public enum NPCType
{
    Anastasia,
    Koya,
    Sonya
}

public enum LocationType
{
    AnastasiaBed,
    SpisesalExterior1,
    SpisesalExterior2,
    AnastasiaSpisesal,
    KoyaConvo,
    SonyaConvo,
    SonyaBell,
    SonyaDansesal,
    AnastasiaDansesal
}
