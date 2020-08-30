using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat.Radar;

namespace VSX.UniversalVehicleCombat
{
    public class HUDCursor : MonoBehaviour, IHUDCameraUser
    {
        [SerializeField]
        protected Camera m_Camera;
        public Camera HUDCamera
        {
            set
            {
                m_Camera = value;
            }
        }

        [SerializeField]
        protected Canvas canvas;
        protected RectTransform canvasRectTransform;

        [SerializeField]
        protected RectTransform cursorRectTransform;

        [SerializeField]
        protected RectTransform lineRectTransform;

        [SerializeField]
        protected float worldSpaceDistanceFromCamera = 0.5f;
        

        private void Awake()
        {
            if (canvas != null)
            {
                canvasRectTransform = canvas.GetComponent<RectTransform>();
            }
        }


        private void LateUpdate()
        {

            if (Mathf.Approximately(Time.timeScale, 0)) return;

            bool worldSpace = (canvas == null) || (canvas.renderMode == RenderMode.WorldSpace);
            Vector3 mouseScreenPos = Input.mousePosition;

            if (worldSpace)
            {
                mouseScreenPos.z = 1;
            }

            if (worldSpace)
            {
                if (cursorRectTransform != null)
                {
                    cursorRectTransform.position = m_Camera.ScreenToWorldPoint(mouseScreenPos);
                    cursorRectTransform.position = m_Camera.transform.position + (cursorRectTransform.position - m_Camera.transform.position).normalized * worldSpaceDistanceFromCamera;
                    cursorRectTransform.LookAt(m_Camera.transform);
                }

                if (lineRectTransform != null)
                {
                    Vector3 centerPos = m_Camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, worldSpaceDistanceFromCamera));
                    centerPos = m_Camera.transform.position + (centerPos - m_Camera.transform.position).normalized * worldSpaceDistanceFromCamera;


                    lineRectTransform.position = 0.5f * centerPos + 0.5f * cursorRectTransform.position;
                    lineRectTransform.LookAt(m_Camera.transform,
                                                Vector3.Cross(m_Camera.transform.forward, (cursorRectTransform.position - lineRectTransform.position).normalized));

                    lineRectTransform.sizeDelta = new Vector2((cursorRectTransform.localPosition - lineRectTransform.localPosition).magnitude * 2 * (1 / lineRectTransform.localScale.x),
                                                                lineRectTransform.sizeDelta.y);
                }
            }
            else
            {
                if (cursorRectTransform != null)
                {
                    Vector3 mouseViewportPos = new Vector3(mouseScreenPos.x / Screen.width, mouseScreenPos.y / Screen.height, 0);
                    cursorRectTransform.anchoredPosition = Vector3.Scale(mouseViewportPos - new Vector3(0.5f, 0.5f, 0f), canvasRectTransform.sizeDelta);
                }
                if (lineRectTransform != null)
                {
                    lineRectTransform.anchoredPosition = 0.5f * cursorRectTransform.anchoredPosition;
                    lineRectTransform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Atan(lineRectTransform.anchoredPosition.y / lineRectTransform.anchoredPosition.x) * Mathf.Rad2Deg);
                    lineRectTransform.sizeDelta = new Vector2((cursorRectTransform.position - lineRectTransform.position).magnitude * 2 * (1 / lineRectTransform.localScale.x),
                                                                lineRectTransform.sizeDelta.y);
                }
            }
        }
    }
}