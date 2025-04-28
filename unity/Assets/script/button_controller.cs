using UnityEngine;
using UnityEngine.UI;

public class button_controller : MonoBehaviour
{
    public GameObject positionButtonGroup;
    public Button button_pos1, button_pos2, button_pos3,
    button_pos4, button_pos5, button_pos6, button_pos7, button_pos8,
    button_pos9, button_pos10, button_pos11,button_pos12, button_pos13, 
    button_pos14, button_pos15, button_pos16;
    Vector3[] spawnWorldPositions = new Vector3[16];
    void Start()
    {
        //x軸:-5, -3, -1, 1
        //y軸:2, 0, -2, -4
        spawnWorldPositions[0] = new Vector3(-5f, 2f, 0f);
        spawnWorldPositions[1] = new Vector3(-3f, 2f, 0f);
        spawnWorldPositions[2] = new Vector3(-1.0f, 2.0f, 0f);
        spawnWorldPositions[3] = new Vector3(1f, 2.0f, 0f);
        spawnWorldPositions[4] = new Vector3(-5f, 0f, 0f);
        spawnWorldPositions[5] = new Vector3(-3f, 0f, 0f);
        spawnWorldPositions[6] = new Vector3(-1f, 0f, 0f);
        spawnWorldPositions[7] = new Vector3(1f, 0f, 0f);
        spawnWorldPositions[8] = new Vector3(-5f, -2.0f, 0f);
        spawnWorldPositions[9] = new Vector3(-3f, -2.0f, 0f);
        spawnWorldPositions[10] = new Vector3(-1f, -2.0f, 0f);
        spawnWorldPositions[11] = new Vector3(1f, -2.0f, 0f);
        spawnWorldPositions[12] = new Vector3(-5f, -4f, 0f);
        spawnWorldPositions[13] = new Vector3(-3f, -4f, 0f);
        spawnWorldPositions[14] = new Vector3(-1f, -4f, 0f);
        spawnWorldPositions[15] = new Vector3(1f, -4f, 0f);
    }
    public GameObject hero_prefab;
    public GameObject hero2_prefab;
    public GameObject enemy_prefab;

    public string current_create_type = "";

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
        button_pos5.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[4]);
        button_pos6.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[5]);
        button_pos7.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[6]);
        button_pos8.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[7]);
        button_pos9.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[8]);
        button_pos10.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[9]);
        button_pos11.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[10]);
        button_pos12.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[11]);
        button_pos13.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[12]);
        button_pos14.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[13]);
        button_pos15.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[14]);
        button_pos16.transform.position = Camera.main.WorldToScreenPoint(spawnWorldPositions[15]);
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
    public void spawn_at_position_5(){
        spawn_at_position(spawnWorldPositions[4]);
    }
    public void spawn_at_position_6(){
        spawn_at_position(spawnWorldPositions[5]);
    }
    public void spawn_at_position_7(){
        spawn_at_position(spawnWorldPositions[6]);
    }
    public void spawn_at_position_8(){
        spawn_at_position(spawnWorldPositions[7]);
    }
    public void spawn_at_position_9(){
        spawn_at_position(spawnWorldPositions[8]);
    }
    public void spawn_at_position_10(){
        spawn_at_position(spawnWorldPositions[9]);
    }
    public void spawn_at_position_11(){
        spawn_at_position(spawnWorldPositions[10]);
    }
    public void spawn_at_position_12(){
        spawn_at_position(spawnWorldPositions[11]);
    }
    public void spawn_at_position_13(){
        spawn_at_position(spawnWorldPositions[12]);
    }
    public void spawn_at_position_14(){
        spawn_at_position(spawnWorldPositions[13]);
    }
    public void spawn_at_position_15(){
        spawn_at_position(spawnWorldPositions[14]);
    }
    public void spawn_at_position_16(){
        spawn_at_position(spawnWorldPositions[15]);
    }
}
