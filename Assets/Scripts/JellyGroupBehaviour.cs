using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JellyGroupBehaviour : MonoBehaviour
{
    
    public int jellyLvl = 4;
    public Material[] jellyColorMats;
    public Transform[] jellyQuarterPoses;
    public Transform[] jellyHalfPoses;
    public Vector3 fullScale, verticalScale, horizontalScale, quarterScale;
    public Dictionary<string, Transform> filledJellyDict = new Dictionary<string, Transform>();

    [SerializeField] private GameObject jellyPrefab;
    
    //private Dictionary<string,Transform> jellyPosDict = new Dictionary<string, Transform>();

    private void Awake()
    {
        
    }

    void Start()
    {
        JellyInit();
    }

    void JellyInit()
    {
        
        //var randLvl = Random.Range(2, 3);
        // switch (randLvl)
        // {
        //     case 1:
        //         var randMat = Random.Range(0, jellyColorMats.Length);
        //         var jellyTemp = Instantiate(jellyPrefab, transform).GetComponent<JellyBehaviour>();
        //         jellyTemp.transform.localPosition = Vector3.zero;
        //         jellyTemp.transform.localScale = fullScale;
        //         jellyTemp.ChangeMaterial(jellyColorMats[randMat]);
        //         jellyTemp.jellyId = randMat;
        //         break;
        //     case 2:
        //         var randPos = Random.Range(0, jellyHalfPoses.Length/2);
        //         for (var i = 0; i < 2; i++)
        //         {
        //             var jellyTempHalf = Instantiate(jellyPrefab, transform).GetComponent<JellyBehaviour>();
        //             jellyTempHalf.transform.localPosition = jellyHalfPoses[randPos].localPosition;
        //             if (randPos == 0 || randPos == 2)
        //             {
        //                 jellyTempHalf.transform.localScale = horizontalScale;
        //             }
        //             else
        //             {
        //                 jellyTempHalf.transform.localScale = verticalScale;
        //             }
        //             jellyTempHalf.ChangeMaterial(jellyColorMats[randPos]);
        //             jellyTempHalf.jellyId = randPos;
        //             randPos += 2;
        //         }
        //         break;
        //         
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
