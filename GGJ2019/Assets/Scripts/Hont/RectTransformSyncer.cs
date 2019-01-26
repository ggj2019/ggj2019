using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hont
{
    [ExecuteInEditMode]
    public class RectTransformSyncer : MonoBehaviour
    {
        public enum LerpModeEnum { X, Y, XY }

        public RectTransform referenceTransform;
        public Vector3 positionOffset;
        public Vector2 sizeOffset;
        public bool enableLerp;
        public float lerpSpeed = 27f;
        public LerpModeEnum lerpMode;

        Vector3 mNewPosition;
        Vector2 mSizeDelta;
        RectTransform mSelfRectTransform;


        void Update()
        {
            if (referenceTransform == null) return;

            if (mSelfRectTransform == null)
                mSelfRectTransform = GetComponent<RectTransform>();

            mNewPosition = referenceTransform.position + positionOffset;
            mSizeDelta = referenceTransform.sizeDelta + sizeOffset;

            if (enableLerp)
            {
                mSelfRectTransform.position = Vector3.Lerp(mSelfRectTransform.position, mNewPosition, lerpSpeed * Time.deltaTime);

                var sizeDelta = mSelfRectTransform.sizeDelta;

                switch (lerpMode)
                {
                    case LerpModeEnum.X:
                        sizeDelta.x = Mathf.Lerp(sizeDelta.x, mSizeDelta.x, lerpSpeed * Time.deltaTime);
                        sizeDelta.y = mSizeDelta.y;
                        break;
                    case LerpModeEnum.Y:
                        sizeDelta.x = mSizeDelta.x;
                        sizeDelta.y = Mathf.Lerp(sizeDelta.y, mSizeDelta.y, lerpSpeed * Time.deltaTime);
                        break;
                    case LerpModeEnum.XY:
                        sizeDelta.x = Mathf.Lerp(sizeDelta.x, mSizeDelta.x, lerpSpeed * Time.deltaTime);
                        sizeDelta.y = Mathf.Lerp(sizeDelta.y, mSizeDelta.y, lerpSpeed * Time.deltaTime);
                        break;
                }

                mSelfRectTransform.sizeDelta = sizeDelta;
            }
            else
            {
                mSelfRectTransform.position = mNewPosition;
                mSelfRectTransform.sizeDelta = mSizeDelta;
            }
        }
    }
}
