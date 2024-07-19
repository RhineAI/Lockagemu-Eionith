using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eionith.ChartFormat
{
    public class NoteSpawner : MonoBehaviour
    {
        public GameObject ChartElements;
        public GameObject NotePrefab;
        public GameObject HoldPrefab;
        public GameObject FlickPrefab;
        public GameObject DirectionalFlickPrefab;
        public GameObject SlidePrefab;

        public ChartReader chartReader;
        // private List<RawTap> Taps;
        // private List<RawHold> Holds;
        // private List<RawFlick> Flicks;
        // private List<RawSideFlick> SideFlicks;
        // private List<RawSlide> Slides;
        // private List<RawLaneRotation> LaneRotations;

        void Start()
        {
            // Taps = ChartReader.instance.Taps;
            // Holds = ChartReader.instance.Holds;
            // Flicks = ChartReader.instance.Flicks;
            // SideFlicks = ChartReader.instance.SideFlicks;
            // Slides = ChartReader.instance.Slides;
            // LaneRotations = ChartReader.instance.LaneRotations;

            // StartCoroutine(SpawnTaps());
            // StartCoroutine(SpawnHolds());
        }

        // private IEnumerator SpawnTaps()
        // {
            // foreach (RawTap tap in Taps)
            // {
                // yield return new WaitForSeconds(tap.StartTiming / 1000f); 
                // yield return null;
                // SpawnTapObject(tap);
            // }
        // }

        // private IEnumerator SpawnHolds()
        // {
        //     foreach (RawHold hold in holds)
        //     {
        //         yield return new WaitForSeconds(hold.StartTiming / 1000f); 
        //         SpawnHoldObject(hold);
        //     }
        // }

        void SpawbTapObject(RawTap tap)
        {
            // Spawn note di lane yang ditentukan
            GameObject noteObj = Instantiate(NotePrefab, GetLanePosition(tap.LanePosition), Quaternion.identity, ChartElements.transform);
        }

        // void SpawnHoldObject(RawHold hold)
        // {
        //     // Spawn hold di lane yang ditentukan
        //     GameObject holdObj = Instantiate(HoldPrefab, GetLanePosition(hold.StartLane), Quaternion.identity, ChartElement);
        // }

        Vector3 GetLanePosition(int lane)
        {
            switch(lane) {
                case 1:
                    return new Vector3(15, 0, 0);
                case 2:
                    return new Vector3(45, 0, 0);
                case 3:
                    return new Vector3(75, 0, 0);
                case 4:
                    return new Vector3(105, 0, 0);
                case 5:
                    return new Vector3(135, 0, 0);
                case 6:
                    return new Vector3(165, 0, 0);
                case 7:
                    return new Vector3(195, 0, 0);
                case 8:
                    return new Vector3(225, 0, 0);
                case 9:
                    return new Vector3(255, 0, 0);
                case 10:
                    return new Vector3(285, 0, 0);
                case 11:
                    return new Vector3(315, 0, 0);
                case 12:
                    return new Vector3(330, 0, 0);
                default:
                    return new Vector3(15, 0, 0);
      
            }
        }
    }

}

