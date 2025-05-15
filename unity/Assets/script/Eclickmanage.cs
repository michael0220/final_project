using UnityEngine;
using UnityEngine.EventSystems;

public class Eclickmanage : MonoBehaviour
{
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("點在 UI 上，跳過 Raycast");
                return;
            }
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("World Pos: " + worldPos);
            RaycastHit2D hit = Physics2D.Raycast(worldPos,Vector2.zero);
            if(hit.collider != null){
                Debug.Log("點到了"+ hit.collider.name);
                Energy energy = hit.collider.GetComponent<Energy>();
                if(energy != null){
                    energy.OnClicked();
                }
            }else
            {
                Debug.Log("沒打中任何 collider");
            }
        }
    }
}
