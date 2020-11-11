using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RaycastUIController : MonoBehaviour
{
    public GameObject targetObject;
    public string ignoreTag;
    public UnityEvent OnIgnoreTag;
    public UnityEvent OnOthers;

    private PointerEventData pointerEventData;
    private GraphicRaycaster raycaster;
    private EventSystem currentEventSystem;

    private void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        currentEventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
     
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pointerEventData = new PointerEventData(currentEventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                //Debug.Log("Hit " + result.gameObject.name);
                if (result.gameObject.tag == ignoreTag)
                {
                    //targetObject.SetActive(true);
                    //Debug.Log("Yes");
                    OnIgnoreTag.Invoke();
                    return;
                }
            }
            //Debug.Log("No");
            OnOthers.Invoke();


            //targetObject.SetActive(false);






        }

    }
}
