using UnityEngine;
using UnityEngine.EventSystems;

/*
* 유니티에서 제공해주는 Event, Ipointer
- Ipointer Interface : 기본제공되는 인터페이스
- 다음과 같은 조건이 필요함

    - 클릭, 터피, 드래그 등의 이벤트를 구현할때 사용 
    - 1. UI 오브젝트에는 Graphic Raycaster 컴포넌트가 추가되어있어야 하고, Raycast Target이 체크된 상태여야 함
    - 2. Scene에는 Event System 컴포넌트가 존재해야 한다
    - 3. 오브젝트에 대한 작업시에는 Collider 컴포넌트가 추가되어야 한다
    - 4. Main camera에 Physics Raycaster 컴포넌트가 추가되어야 한다

*/

public class UInterSample : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("클릭");
    }
    /*
     * 사용방법
     * 1. 오브젝트연결
     * 2. 씬에 Event System 오브젝트를 배치
     *    만약 씬에 캔버스 생성을 진행했다면, 자동으로 배치가 되며 아닌 경우는 따로 만들어서 연결 
     * 3. 오브젝트에 콜라이더 연결
     * 4.카메라에 Physics Raycaster 컴포넌트가 추가
     * 
     * IPointerClickHandler 
     * 해당 I를 추가하면. 마우스클릭 또는 터치할때 호출
     * 누르고 뗏을경우 호출
     * 
     * IPointerDownHandler
     * 누르는 순간 호출 클릭/터치 
     * 
     * IPointerupHandler
     * 뗀 상황에서 호출되는 
     * 
     * IBeginDragHandler
     * 드래그진입시 호출
     * 
     * IEndDragHandler
     * 드래그 끝날때
     * 
     * IDragHandler
     * 드래그 진행동안
     */

}
