using UnityEngine;
using UnityEngine.UIElements;

public class button_controller : MonoBehaviour
{
    public GameObject positionButtonGroup;
    public Button button_pos1, button_pos2, button_pos3, button_pos4;
    Vector3[] spawnWorldPositions = new Vector3[4];
    void Start()
    {
        spawnWorldPositions[0] = new Vector3(-4f, -1.3f, 0f);
        spawnWorldPositions[1] = new Vector3(-2f, -1.3f, 0f);
        spawnWorldPositions[2] = new Vector3(0f, -1.3f, 0f);
        spawnWorldPositions[3] = new Vector3(2f, -1.3f, 0f);
    }
    public GameObject hero_prefab;
    public GameObject hero2_prefab;
    public GameObject enemy_prefab;

    private string current_create_type = "";

    public void prepare_spawn_hero()
    {
        positionButtonGroup.SetActive(true);
        current_create_type = "hero";
        button_position();
    }
    public void prepare_spawn_hero2(){
        positionButtonGroup.SetActive(true);
        current_create_type = "hero2";
        button_position();
    }
    public void prepare_spawn_enemy(){
        positionButtonGroup.SetActive(true);
        current_create_type = "enemy";

        button_position();
    }
    void button_position(){
        button_pos1.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[0]);
        button_pos2.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[1]);
        button_pos3.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[2]);
        button_pos4.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[3]);
    }
    public void spawn_at_position(Vector2 position){
        if(current_create_type=="hero"){
            Instantiate(hero_prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        }
        else if(current_create_type=="hero2"){
             Instantiate(hero2_prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        }
        else if(current_create_type=="enemy"){
            Instantiate(enemy_prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        }

        positionButtonGroup.SetActive(false);
        current_create_type = "";
    }

    public void spawn_at_position_1(){
        spawn_at_position(spawnWorldPositions[0]);
    }
    public void spawn_at_position_2(){
        spawn_at_position(spawnWorldPositions[1]);
    }
    public void spawn_at_position_3(){
        spawn_at_position(spawnWorldPositions[2]);
    }
    public void spawn_at_position_4(){
        spawn_at_position(spawnWorldPositions[3]);
    }
}
