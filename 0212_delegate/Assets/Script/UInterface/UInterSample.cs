using UnityEngine;
using UnityEngine.EventSystems;

/*
* ����Ƽ���� �������ִ� Event, Ipointer
- Ipointer Interface : �⺻�����Ǵ� �������̽�
- ������ ���� ������ �ʿ���

    - Ŭ��, ����, �巡�� ���� �̺�Ʈ�� �����Ҷ� ��� 
    - 1. UI ������Ʈ���� Graphic Raycaster ������Ʈ�� �߰��Ǿ��־�� �ϰ�, Raycast Target�� üũ�� ���¿��� ��
    - 2. Scene���� Event System ������Ʈ�� �����ؾ� �Ѵ�
    - 3. ������Ʈ�� ���� �۾��ÿ��� Collider ������Ʈ�� �߰��Ǿ�� �Ѵ�
    - 4. Main camera�� Physics Raycaster ������Ʈ�� �߰��Ǿ�� �Ѵ�

*/

public class UInterSample : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ŭ��");
    }
    /*
     * �����
     * 1. ������Ʈ����
     * 2. ���� Event System ������Ʈ�� ��ġ
     *    ���� ���� ĵ���� ������ �����ߴٸ�, �ڵ����� ��ġ�� �Ǹ� �ƴ� ���� ���� ���� ���� 
     * 3. ������Ʈ�� �ݶ��̴� ����
     * 4.ī�޶� Physics Raycaster ������Ʈ�� �߰�
     * 
     * IPointerClickHandler 
     * �ش� I�� �߰��ϸ�. ���콺Ŭ�� �Ǵ� ��ġ�Ҷ� ȣ��
     * ������ ������� ȣ��
     * 
     * IPointerDownHandler
     * ������ ���� ȣ�� Ŭ��/��ġ 
     * 
     * IPointerupHandler
     * �� ��Ȳ���� ȣ��Ǵ� 
     * 
     * IBeginDragHandler
     * �巡�����Խ� ȣ��
     * 
     * IEndDragHandler
     * �巡�� ������
     * 
     * IDragHandler
     * �巡�� ���ൿ��
     */

}
