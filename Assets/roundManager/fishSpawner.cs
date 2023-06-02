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
    public int coroutineCounter;
    public GameObject basicFish;
    public GameObject behemothFish;
    public GameObject blitzFish;
    public List<RoundInfo> roundInfoList = new List<RoundInfo>();
    public Dictionary<string, GameObject> fishTypeToPrefab = new Dictionary<string, GameObject>();
    public Dictionary<string, float> fishTypeToSpawnDelays = new Dictionary<string, float>();
    public bool doneSpawning;
    void Awake()
    {
        fishTypeToPrefab.Add("basicFish", basicFish);
        fishTypeToPrefab.Add("behemothFish", behemothFish);
        fishTypeToPrefab.Add("blitzFish", blitzFish);
        fishTypeToSpawnDelays.Add("basicFish", 0.65f);
        fishTypeToSpawnDelays.Add("behemothFish", 1.0f);
        fishTypeToSpawnDelays.Add("blitzFish", 0.6f);
    }

    void Start()
    {
        RoundInfo round1 = new RoundInfo();
        round1.fishList = new List<FishInfo>();
        round1.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 18 });
        roundInfoList.Add(round1);

        RoundInfo round2 = new RoundInfo();
        round2.fishList = new List<FishInfo>();
        round2.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 30 });
        roundInfoList.Add(round2);

        RoundInfo round3 = new RoundInfo();
        round3.fishList = new List<FishInfo>();
        round3.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 15 });
        round3.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 3 });
        round3.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 5 });
        round3.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 3 });
        round3.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        roundInfoList.Add(round3);

        RoundInfo round4 = new RoundInfo();
        round4.fishList = new List<FishInfo>();
        round4.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 30 });
        round4.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 3 });
        round4.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round4.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 6 });
        round4.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 5 });
        roundInfoList.Add(round4);

        RoundInfo round5 = new RoundInfo();
        round5.fishList = new List<FishInfo>();
        round5.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round5.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 5 });
        round5.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round5.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 5 });
        round5.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 12 });
        roundInfoList.Add(round5);

        RoundInfo round6 = new RoundInfo();
        round6.fishList = new List<FishInfo>();
        round6.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 30});
        round6.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 5 });
        round6.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round6.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 5 });
        round6.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 12 });
        roundInfoList.Add(round6);

        RoundInfo round7 = new RoundInfo();
        round7.fishList = new List<FishInfo>();
        round7.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 15});
        round7.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round7.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 15});
        round7.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        round7.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 15});
        round7.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 10 });
        round7.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        roundInfoList.Add(round7);

        RoundInfo round8 = new RoundInfo();
        round8.fishList = new List<FishInfo>();
        round8.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round8.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round8.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        round8.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 5});
        round8.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        round8.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 10});
        round8.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 20 });
        round8.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        roundInfoList.Add(round8);

        RoundInfo round9 = new RoundInfo();
        round9.fishList = new List<FishInfo>();
        round9.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 15});
        round9.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 10});
        round9.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        round9.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round9.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        round9.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 15});
        round9.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 30 });
        round9.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 15});
        roundInfoList.Add(round9);

        RoundInfo round10 = new RoundInfo();
        round10.fishList = new List<FishInfo>();
        round10.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round10.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round10.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round10.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round10.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round10.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round10.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round10.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 20 });
        round10.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 15});
        round10.fishList.Add(new FishInfo { fishType = "blitzFish", quantity = 10 });
        round10.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 30 });
        round10.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 15});
        roundInfoList.Add(round10);

        RoundInfo round11 = new RoundInfo();
        round11.fishList = new List<FishInfo>();
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10});
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        round11.fishList.Add(new FishInfo { fishType = "basicFish", quantity = 10 });
        round11.fishList.Add(new FishInfo { fishType = "behemothFish", quantity = 5});
        roundInfoList.Add(round11);

        
    }

   public void startRound(int currentRound)
{
    doneSpawning = false;
    RoundInfo round = roundInfoList[currentRound - 1]; // subtract 1 from currentRound to account for 0-based indexing
    StartCoroutine(SpawnFishTypes(round.fishList));
}

public IEnumerator SpawnFishTypes(List<FishInfo> fishList)
{
    foreach (FishInfo fishInfo in fishList)
    {
        GameObject fishPrefab = fishTypeToPrefab[fishInfo.fishType];
        float delay = fishTypeToSpawnDelays[fishInfo.fishType];
        yield return StartCoroutine(SpawnFish(fishInfo, fishPrefab, delay));
    }
    Debug.Log("Done Spawning");
    doneSpawning = true;
}

public IEnumerator SpawnFish(FishInfo fishInfo, GameObject fishPrefab, float delay)
{
    for (int i = 0; i < fishInfo.quantity; i++)
    {
        Instantiate(fishPrefab, GameObject.Find("Path").GetComponent<Path>().points[0].position, Quaternion.identity); // instantiate prefab
        yield return new WaitForSeconds(delay);
    }
}

}
