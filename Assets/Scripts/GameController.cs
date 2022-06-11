using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class GameController : MonoBehaviour
{
    
    [System.Serializable]
    public struct test
    {
        public string fact; 
        public int length; 
    }
    public int oro; 
    public Text textoOro; 
    public Text jsonText; 

    private Building buildingToPlace; 
    public GameObject grid; 

    public CustomCursor cursor; 

    public SpawnPoint[] tiles; 
    

    // Update is called once per frame
    void Update()
    {
        textoOro.text = oro.ToString();

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
        }
    }

    public void jsonRequest(){
        StartCoroutine(SendRequest("http://127.0.0.1:5000/api"));
    }
    
    IEnumerator SendRequest(string url){
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();

        if(req.isNetworkError || req.isHttpError){
            jsonText.text = string.Format("Error: {0}", req.error);
        }
        else {
            test texto = JsonUtility.FromJson<test>(req.downloadHandler.text);
            jsonText.text = texto.fact;
        }
    }

}
