using System.Collections.Generic;
using UnityEngine;

namespace Eionith.ChartFormat
{
   public class ChartSpawner : MonoBehaviour
    {
        public string chartFilePath;
        public GameObject notePrefab;
        public GameObject laneRotationPrefab;
        public GameObject holdPrefab;
        public GameObject slidePrefab;
        public GameObject flickPrefab;
        public GameObject directionalFlickPrefab;

        private List<IChartElement> chartElements;
        private ChartReader chartReader;

        void Start()
        {
            chartReader = GetComponent<ChartReader>();
            if (chartReader == null)
            {
                Debug.LogError("ChartReader component not found!");
                return;
            }

            chartElements = chartReader.ParseChartFile(chartFilePath);

            // foreach (IChartElement element in chartElements)
            // {
            //     if (element is Note note)
            //     {
            //         SpawnNote(note);
            //     }
            //     else if (element is LaneRotation laneRotation)
            //     {
            //         SpawnLaneRotation(laneRotation);
            //     }
            //     else if (element is Hold hold)
            //     {
            //         SpawnHold(hold);
            //     }
            //     else if (element is Slide slide)
            //     {
            //         SpawnSlide(slide);
            //     }
            //     else if (element is Flick flick)
            //     {
            //         SpawnFlick(flick);
            //     }
            //     else if (element is DirectionalFlick directionalFlick)
            //     {
            //         SpawnDirectionalFlick(directionalFlick);
            //     }
            // }
        }

        // void SpawnNote(Note note)
        // {
        //     GameObject newNote = Instantiate(notePrefab, new Vector3(note.LanePosition, 0, 0), Quaternion.identity);
        //     // Set the note's properties here if needed
        //     newNote.GetComponent<NoteBehavior>().StartTiming = note.StartTiming;
        // }

        // void SpawnLaneRotation(LaneRotation laneRotation)
        // {
        //     GameObject newLaneRotation = Instantiate(laneRotationPrefab);
        //     // Set the laneRotation's properties here if needed
        //     newLaneRotation.GetComponent<LaneRotationBehavior>().StartTiming = laneRotation.StartTiming;
        // }

        // void SpawnHold(Hold hold)
        // {
        //     GameObject newHold = Instantiate(holdPrefab, new Vector3(hold.StartLanePosition, 0, 0), Quaternion.identity);
        //     // Set the hold's properties here if needed
        //     newHold.GetComponent<HoldBehavior>().StartTiming = hold.StartTiming;
        // }

        // void SpawnSlide(Slide slide)
        // {
        //     GameObject newSlide = Instantiate(slidePrefab, new Vector3(slide.Position, 0, 0), Quaternion.identity);
        //     // Set the slide's properties here if needed
        //     newSlide.GetComponent<SlideBehavior>().StartTiming = slide.StartTiming;
        // }

        // void SpawnFlick(Flick flick)
        // {
        //     GameObject newFlick = Instantiate(flickPrefab, new Vector3(flick.LanePosition, 0, 0), Quaternion.identity);
        //     // Set the flick's properties here if needed
        //     newFlick.GetComponent<FlickBehavior>().StartTiming = flick.StartTiming;
        // }

        // void SpawnDirectionalFlick(DirectionalFlick directionalFlick)
        // {
        //     GameObject newDirectionalFlick = Instantiate(directionalFlickPrefab, new Vector3(directionalFlick.LanePosition, 0, 0), Quaternion.identity);
        //     // Set the directionalFlick's properties here if needed
        //     newDirectionalFlick.GetComponent<DirectionalFlickBehavior>().StartTiming = directionalFlick.StartTiming;
        // }
    } 
}

