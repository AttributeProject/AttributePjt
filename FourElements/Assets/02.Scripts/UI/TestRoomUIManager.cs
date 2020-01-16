using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestRoomUIManager : MonoBehaviour
{
    public Dropdown objectDropdown;
    public Canvas canvas;
    private Camera camera;


    Vector2 mousePos;   //마우스 포지션
    //-------------------------------------------UI 클릭 판별을 위한 변수들---------------------
    private GraphicRaycaster gr;
    private PointerEventData ped;

    //------------------------------------------오브젝트 생성, 삭제, 이동 기능에 쓰일 변수들---------------------------
    GameObject objPrefab; 
    private bool isTracking=false;
    private bool isDeleteMode = false;
    private bool isMoveMode = false;
    [SerializeField]
    public List<GameObject> ObjPrefabList = new List<GameObject>(); //이거 수동맵핑한거라 직렬화 상태 풀지 마십쇼
    //---------------------------------------------게임 내 오브젝트 클릭 판별을 위한 변수들
    RaycastHit2D hit;
    private void Awake()
    {
        camera = this.gameObject.GetComponent<Camera>();
        gr = canvas.GetComponent<GraphicRaycaster>();
        ped = new PointerEventData(null);

        objectDropdown.onValueChanged.AddListener(delegate {
            dropDownChanged(objectDropdown);
        });
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        //오브젝트가 마우스를 따라다님
        if (isTracking)
        {
            Debug.Log(mousePos);
            objPrefab.transform.position = (Vector2)camera.ScreenToWorldPoint(mousePos);
        }


        //---------------------------------------------------마우스 좌클릭--------------------
        if (Input.GetMouseButtonDown(0))
        {
            //-------------------------------------------트래킹을 끝냄------------------------
            //만약 오브젝트를 생성, 이동중이였다면
            if (isTracking)
            {
                isTracking = false;
                modeOff();
            }
            

            //-------------------------------------------UI 클릭 판별 및 처리------------------------
            List<RaycastResult> res = new List<RaycastResult>();
            ped.position = mousePos;
            gr.Raycast(ped,res);
            //마우스 클릭 위치에 UI오브젝트가 존재함
            if (res.Count != 0)
            {
            }
            //마우스 클릭 위치에 UI오브젝트가 존재하지않음
            else
            {
                dropDownOff();
            }


            //-------------------------------------------오브젝트 클릭 판별 및 처리------------------------
            //충돌한 오브젝트 존재
            if (hit=Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(mousePos),Mathf.Infinity))
            {
                Debug.Log(hit.transform.name);
                //삭제모드 활성화 상태인경우 오브젝트 삭제하고 모드가 종료됨
                if (isDeleteMode)
                {
                    Destroy(hit.transform.gameObject);
                    modeOff();
                }
                //move모드를 선택하고 오브젝트를 클릭했을 경우 충돌한 오브젝트를 선택함
                else if (isMoveMode)
                {
                    objPrefab = hit.transform.gameObject;
                    isTracking = true;
                }
            }
            //충돌한 오브젝트 존재X
            else
            {
                Debug.Log("no obj");
            }
        }
        //---------------------------------------------------마우스 우클릭--------------------
        else if (Input.GetMouseButtonDown(1))
        {

        }
    }
    // 드랍다운 활성화 - 스크립트에서는 참조 안해도 UI Button에 수동으로 달아준 함수라 지우면안댐
    public void dropDownOn()
    {
        Debug.Log("on");
        objectDropdown.gameObject.SetActive(true);
    }
    // 드랍다운 비활성화
    public void dropDownOff()
    {
        Debug.Log("off");
       // objectDropdown.gameObject.SetActive(false);

        //왠진모르겠는데 작동안함; 리펙토링 하던가 나중에 공부좀 해야될덧
    }
    public void dropDownChanged(Dropdown dd)
    {
        Debug.Log(dd.value);
        objPrefab = (GameObject)Instantiate(ObjPrefabList[dd.value]);
        isTracking = true;
    }
    //오브젝트 삭제 기능 활성화
    public void deleteModeOn()
    {
        modeOff();
        isDeleteMode = true;
    }
    public void moveModeOn()
    {
        modeOff();
        isMoveMode = true;
    }
    //모든 오브젝트 관련 기능을 off로 초기화함
    public void modeOff()
    {
        Debug.Log("modeOff");
        isDeleteMode = false;
        isMoveMode = false;
    }
}

