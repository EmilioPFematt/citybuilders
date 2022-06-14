using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class GameController : MonoBehaviour
{
    [System.Serializable] // Test
    public struct test
    {
        public string fact; 
        public int length; 
    }
    [System.Serializable]
    public struct factList {
        public test[] data;
    }

    [System.Serializable]
    public struct buildingInfo {
        public int id;
        public int ciudad_id;
        public int sprite_id; 
        public int pos_id; 
        public string created_at;
        public string updated_at;
        public string url;
    }

    [System.Serializable]
    public struct buidlingList {
        public buildingInfo[] data; 
    }

    public int oro; 
    public Text textoOro; 
    public Text jsonText; 

    private Building buildingToPlace; 
    public GameObject grid; 
    public UIController uicontroller; 

    public CustomCursor cursor; 

    public SpawnPoint[] tiles; 


    public Building[] buildings; 
    
    public MusicController sfxManager;
    
    void Start()
    {
        uicontroller.startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        textoOro.text = oro.ToString();
        uicontroller.updateText();
        if(Input.GetMouseButtonDown(0) && buildingToPlace != null){
            SpawnPoint closestTile  = null; 
            float shortestDistance = float.MaxValue; 
            foreach (SpawnPoint tile in tiles){
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(dist < shortestDistance){
                    shortestDistance = dist; 
                    closestTile = tile; 
                }
            }   
            if(closestTile.isOccupied == false && shortestDistance <= 2){
                buildingToPlace.GetComponent<SpriteRenderer>().sortingOrder = closestTile.gameObject.GetComponent<SpriteRenderer>().sortingOrder; 
                Instantiate(buildingToPlace, closestTile.transform.position, Quaternion.identity);
                oro -= buildingToPlace.costo; 
                buildingToPlace = null; 
                closestTile.isOccupied = true; 
                grid.SetActive(false);
                cursor.gameObject.SetActive(false);
                Cursor.visible = true; 
                sfxManager.PlayBuilding();
            }
            else {
                grid.SetActive(false);
                cursor.gameObject.SetActive(false);
                Cursor.visible = true; 
            }
        }
    }

    public void compraEdificio(Building build){
        if(oro >= build.costo && Cursor.visible == true){
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = build.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;
            buildingToPlace = build; 
            grid.SetActive(true);
            sfxManager.PlayGainMoney();
        }
    }

    public void jsonRequest(string url){
        StartCoroutine(SendRequest(url));
    }
    
    IEnumerator SendRequest(string url){
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();
        if(req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError){
            jsonText.text = string.Format("Error: {0}", req.error);
        }
        else {
            factList texto = JsonUtility.FromJson<factList>(req.downloadHandler.text);
            jsonText.text = texto.data[1].fact;
        }
    }

    public void placeBuildings(){
        StartCoroutine(GetBuildings());
    }

    IEnumerator GetBuildings(){
        UnityWebRequest req = UnityWebRequest.Get("LocalHost:3000/buildings.json");
        yield return req.SendWebRequest();
        string newjson = "{\"data\":" + req.downloadHandler.text + "}";
        if(req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError){
            jsonText.text = string.Format("Error: {0}", req.error);
        }
        else {
            buidlingList datos = JsonUtility.FromJson<buidlingList>(newjson);
            jsonText.text = datos.data.Length.ToString();
            for(int i = 0; i<datos.data.Length; i++) {  
                tiles[datos.data[i].pos_id].isOccupied = true; 
                buildingToPlace = buildings[datos.data[i].sprite_id];
                buildingToPlace.GetComponent<SpriteRenderer>().sortingOrder = tiles[datos.data[i].pos_id].gameObject.GetComponent<SpriteRenderer>().sortingOrder; 
                Instantiate(buildingToPlace, tiles[datos.data[i].pos_id].transform.position, Quaternion.identity); 
                buildingToPlace = null; 
            }
        }
    }

}
