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
        private List<RawTap> Taps;
        private List<RawHold> Holds;
        private List<RawFlick> Flicks;
        private List<RawSideFlick> SideFlicks;
        private List<RawSlide> Slides;
        private List<RawLaneRotation> LaneRotations;

        void Start()
        {
            Taps = chartReader.Taps;
            Holds = chartReader.Holds;
            Flicks = chartReader.Flicks;
            SideFlicks = chartReader.SideFlicks;
            Slides = chartReader.Slides;
            LaneRotations = chartReader.LaneRotations;

            StartCoroutine(SpawnNotes());
            // StartCoroutine(SpawnHolds());
        }

        private IEnumerator SpawnNotes()
        {
            foreach (RawTap tap in Taps)
            {
                yield return new WaitForSeconds(tap.StartTiming / 1000f); // Konversi ms ke detik
                SpawnNoteObject(tap);
            }
        }

        // private IEnumerator SpawnHolds()
        // {
        //     foreach (RawHold hold in holds)
        //     {
        //         yield return new WaitForSeconds(hold.StartTiming / 1000f); // Konversi ms ke detik
        //         SpawnHoldObject(hold);
        //     }
        // }

        void SpawnNoteObject(RawTap tap)
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
            return new Vector3(lane, 0, 0);
        }
    }

}

