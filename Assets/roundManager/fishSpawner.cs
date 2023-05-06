using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundInfo
{
    public List<FishInfo> fishList;
}

[System.Serializable]
public class FishInfo
{
    public string fishType;
    public int quantity;
}

public class fishSpawner : MonoBehaviour
{
    public GameObject basicFish;
    public GameObject behemothFish;
    public List<RoundInfo> roundInfoList = new List<RoundInfo>();
    public Dictionary<string, GameObject> fishTypeToPrefab = new Dictionary<string, GameObject>();
    public Dictionary<string, float> fishTypeToSpawnDelays = new Dictionary<string, float>();
    public bool doneSpawning;
    void Awake()
    {
        fishTypeToPrefab.Add("basicFish", basicFish);
        fishTypeToPrefab.Add("behemothFish", behemothFish);
        fishTypeToSpawnDelays.Add("basicFish", 0.5f);
        fishTypeToSpawnDelays.Add("behemothFish", 1.0f);
    }

    void Start()
    {
        RoundInfo round1 = new RoundInfo();
        round1.fishList = new List<FishInfo>();
        round1.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 25 });
        roundInfoList.Add(round1);

        RoundInfo round2 = new RoundInfo();
        round2.fishList = new List<FishInfo>();
        round2.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 45 });
        round2.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 10 });
        roundInfoList.Add(round2);

        RoundInfo round3 = new RoundInfo();
        round3.fishList = new List<FishInfo>();
        round3.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 50 });
        round3.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 20 });
        roundInfoList.Add(round3);

        RoundInfo round4 = new RoundInfo();
        round4.fishList = new List<FishInfo>();
        round4.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 75 });
        round4.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 30 });
        roundInfoList.Add(round4);
    }

    public void startRound(int currentRound)
    {
        doneSpawning = false;
        RoundInfo round = roundInfoList[currentRound - 1]; // subtract 1 from currentRound to account for 0-based indexing
        foreach (FishInfo fishInfo in round.fishList)
        {
            GameObject fishPrefab = fishTypeToPrefab[fishInfo.fishType];
            StartCoroutine(SpawnFish(fishInfo, fishPrefab, fishTypeToSpawnDelays[fishInfo.fishType]));
        }
    }

    public IEnumerator SpawnFish(FishInfo fishInfo, GameObject fishPrefab, float delay)
    {
        for (int i = 0; i < fishInfo.quantity; i++)
        {
            Instantiate(fishPrefab, GameObject.Find("Path").GetComponent<Path>().points[0].position, Quaternion.identity); // instantiate prefab
            yield return new WaitForSeconds(delay);
        }
        Debug.Log("Done Spawning");
        doneSpawning = true;
    }

}
