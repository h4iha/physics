using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public partial class GameScarpManager : MonoBehaviour
{
    public static GameScarpManager instance;

    public Camera camera;
    public GoldKoi goldKoi;
    public PinkKoi[] pinkKois;
    public GameObject prefabPink;
    public Transform parentPinks;
    public Transform[] poses;
    public int lengthFish = 20;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        int indexGoldKoiRandom = UnityEngine.Random.Range(0, pinkKois.Length);
        for (int i = 0; i < pinkKois.Length; i++)
        {
            int p = i % 4;
            poses[p].Rotate(new Vector3(0, UnityEngine.Random.Range(-30, 31), 0));
            GameObject newPink = Instantiate(prefabPink, poses[p].position, poses[p].rotation, parentPinks);
            pinkKois[i].pinkKoiGO = prefabPink;
            pinkKois[i].swimSpeed = (float)UnityEngine.Random.Range(5,16) * 0.1f;
            pinkKois[i].rotSpeed = UnityEngine.Random.Range(20, 40);
        }
    }
    private void Update()
    {
        ClickFish();
    }
    private void ClickFish()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, float.MaxValue))
            {
                PinkSwim pinkSwim = hit.transform.GetComponent<PinkSwim>();
                if(pinkSwim != null)
                    StartCoroutine(pinkSwim.BoostSpeed());
            }

        }
    }
}
