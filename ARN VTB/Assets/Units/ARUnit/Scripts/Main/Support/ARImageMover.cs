using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARUnit
{
    public class ARImageMover : MonoBehaviour
    {
        public string imageName;
        public float deactivateTime = -1;

        public GameObject child;
        // Use this for initialization
        void Start()
        {
            ARInterface.onImageUpdate += ARImageUpdate;
            ARInterface.onImageAdd += ARImageAdd;
            ARInterface.onImageRemoved += ARImageRemove;
        }

        public ARImage ARImage = new ARImage();

        float oldTimeTrack = -1;
        void ARImageAdd(ARImage ARImage)
        {
            if (string.IsNullOrEmpty(imageName) || imageName == ARImage.name)
            {
                oldTimeTrack = Time.time;
                this.ARImage = ARImage;
                child.SetActive(true);
            }
        }

        void ARImageUpdate(ARImage ARImage)
        {
            if (string.IsNullOrEmpty(imageName) || imageName == ARImage.name)
            {
                oldTimeTrack = Time.time;
                this.ARImage = ARImage;
                child.SetActive(true);
            }
        }

        void ARImageRemove(ARImage ARImage)
        {
            if (string.IsNullOrEmpty(imageName) || imageName == ARImage.name)
            {
                this.ARImage = ARImage;
                child.SetActive(false);
            }
        }

        protected void CheckTime()
        {
            if (deactivateTime > 0)
            {
                if (Time.time - oldTimeTrack > deactivateTime && child.activeSelf)
                {
                    child.SetActive(false);
                }
            }
        }

        void Update()
        {
            CheckTime();
            transform.localPosition = ARImage.position;
            transform.localRotation = ARImage.rotation;
        }
    }
}
