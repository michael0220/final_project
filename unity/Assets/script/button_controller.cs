using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_controller : MonoBehaviour
{
    public GameObject positionButtonGroup;
    public GameObject hero_prefab;
    public GameObject hero2_prefab;
    public GameObject enemy_prefab;
    public GameObject potato_prefab;
    public string current_create_type = "";

    public Transform[] spawnPoints;
    public GameObject buttonprefab;
    public Transform buttonParent;
    public List<Button> positionButtons = new List<Button>(); 

    void Start()
    {
        positionButtonGroup.SetActive(false);
        for(int i=0;i<spawnPoints.Length;i++){
            int index = i;
            GameObject button = Instantiate(buttonprefab, buttonParent);
            Button btn = button.GetComponent<Button>();

            positionButtons.Add(btn);
            btn.transform.position = Camera.main.WorldToScreenPoint(spawnPoints[index].position);
            btn.onClick.AddListener(() => spawn_at_position(spawnPoints[index].position));
        }
    }
    

    public void prepare_spawn_potato()
    {
        positionButtonGroup.SetActive(true);
        current_create_type = "potato";
    }
    public void prepare_spawn_hero()
    {
        positionButtonGroup.SetActive(true);
        current_create_type = "hero";
    }
    public void prepare_spawn_hero2(){
        positionButtonGroup.SetActive(true);
        current_create_type = "hero2";
    }
    public void prepare_spawn_enemy(){
        positionButtonGroup.SetActive(true);
        current_create_type = "enemy";
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
