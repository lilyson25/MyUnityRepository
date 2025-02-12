# 오늘의 수업 : Event
> 유니티 인터페이스 interface
 * 공통적인 특징에 대한 관리 구현 시 효과적
 * 함수나 프로퍼티 등의 정의를 구현없이 진행할 수 잇도록 도와주는 기능
 * 인터페이스는 명시만 하기 때문에, 사용하기위해서는 상속을 통한 재구현으로 진행

### ClassDiagram 생성방법
> 마우스우클릭 classDiagram> add 빈공간 클릭> class 생성> 
- class Potion : Item 을 넣어주면 화살표 생성
- 오류 발생시, 선생성 후 다이어그램에 드래그해서 추가가능
- 공백클릭> 우클릭> export관련 메뉴 클릭> Diagram을 이미지로 export할 수 있다


#### 지원되는 이벤트
- IPointerEnterHandler - OnPointerEnter - 포인터가 오브젝트에 들어갈 때 호출됩니다.
- IPointerExitHandler - OnPointerExit - 포인터가 오브젝트에서 나올 때 호출됩니다.
- IPointerDownHandler - OnPointerDown - 포인터가 오브젝트 위에서 눌렸을 때 호출됩니다.
- IPointerUpHandler - OnPointerUp - 포인터를 뗄 때 호출됩니다(눌려 있던 오브젝트에서 호출됩니다).
- IPointerClickHandler - OnPointerClick - 동일 오브젝트에서 포인터를 누르고 뗄 때 호출됩니다.
- IInitializePotentialDragHandler - OnInitializePotentialDrag - 드래그 타겟이 발견되었을 때 호출됩니다. 값을 초기화하는 데 사용할 수 있습니다.
- IBeginDragHandler - OnBeginDrag - 드래그가 시작되는 시점에 드래그 대상 오브젝트에서 호출됩니다.
- IDragHandler - OnDrag - 드래그 오브젝트가 드래그되는 동안 호출됩니다.
- IEndDragHandler - OnEndDrag - 드래그가 종료됐을 때 드래그 오브젝트에서 호출됩니다.
- IDropHandler - OnDrop - 드래그를 멈췄을 때 해당 오브젝트에서 호출됩니다.
- IScrollHandler - OnScroll - 마우스 휠을 스크롤했을 때 호출됩니다.
- IUpdateSelectedHandler - OnUpdateSelected - 선택한 오브젝트에서 매 틱마다 호출됩니다.
- ISelectHandler - OnSelect - 오브젝트를 선택하는 순간 호출됩니다.
- IDeselectHandler - OnDeselect - 선택한 오브젝트를 선택 해제할 때 호출됩니다.
- IMoveHandler - OnMove - 이동 이벤트(왼쪽, 오른쪽, 위쪽, 아래쪽 등)가 발생했을 때 호출됩니다.
- ISubmitHandler - OnSubmit - 전송 버튼이 눌렸을 때 호출됩니다.
- ICancelHandler - OnCancel - 취소 버튼이 눌렸을 때 호출됩니다.
