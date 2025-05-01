using UnityEngine;
using UnityEngine.UI;

public class button_controller : MonoBehaviour
{
    public GameObject positionButtonGroup;
    public Button[] positionbuttons;
    public GameObject hero_prefab;
    public GameObject hero2_prefab;
    public GameObject enemy_prefab;
    public GameObject potato_prefab;
    public string current_create_type = "";

    Vector3[] spawnWorldPositions = new Vector3[16];
    void Start()
    {
        //x軸:-6, -4, -2, 0
        //y軸:2, 0.2, -1.6, -3.4
        int index = 0;
        for(float y=2f;y>=-3.5f;y-=1.8f){
            for(int x=-6;x<=0;x+=2){
                spawnWorldPositions[index++] = new Vector3(x, y, 0f);
            }
        }

        for(int i=0;i<positionbuttons.Length;i++){
            int captureIndex = i;
            positionbuttons[i].onClick.AddListener(() => spawn_at_position(spawnWorldPositions[captureIndex]));
        }
    }
    

    public void prepare_spawn_potato()
    {
        positionButtonGroup.SetActive(true);
        current_create_type = "potato";
        update_button_positions();
    }
    public void prepare_spawn_hero()
    {
        positionButtonGroup.SetActive(true);
        current_create_type = "hero";
        update_button_positions();
    }
    public void prepare_spawn_hero2(){
        positionButtonGroup.SetActive(true);
        current_create_type = "hero2";
        update_button_positions();
    }
    public void prepare_spawn_enemy(){
        positionButtonGroup.SetActive(true);
        current_create_type = "enemy";
        update_button_positions();
    }
    void update_button_positions(){
        for(int i=0;i<positionbuttons.Length;i++){
            positionbuttons[i].transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[i]);
        }
    }
    public void spawn_at_position(Vector3 position){
        GameObject prefabtospawn = null;

        switch(current_create_type){
            case "hero":
                prefabtospawn = hero_prefab;
                break;
            case "hero2":
                prefabtospawn = hero2_prefab;
                break;
            case "enemy":
                prefabtospawn = enemy_prefab;
                break;
            case "potato":
                prefabtospawn = potato_prefab;
                break;
        }

        if(prefabtospawn!=null){
            Instantiate(prefabtospawn, position, Quaternion.identity);
        }

        positionButtonGroup.SetActive(false);
        current_create_type = "";
    }
}
