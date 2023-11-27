using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZones : MonoBehaviour
{
    public Array2DEditor.Array2DInt matZones;
    public float gridSize;
    public GameObject prefabZone;
    public GameObject prefabTrigger;

    private List<int> instantiatedZones = new List<int>();
    public List<Vector3> zonesPositions = new List<Vector3>();

    private void Start()
    {
        var cells = matZones.GetCells();
        for(var y  = 0; y < matZones.GridSize.y; y++)
        {
            for (var x = 0; x < matZones.GridSize.x; x++)
            {
                if (!instantiatedZones.Contains(cells[y, x])) 
                {
                    GameObject newZone = Instantiate(prefabZone, new Vector3(0f, 0f, 0f), Quaternion.identity);
                    newZone.GetComponent<ZoneDetection>().zoneId = cells[y, x];
                    Color colorZone = GetRandomColor();
                    for (var yZone = 0; yZone < matZones.GridSize.y; yZone++)
                    {
                        for (var xZone = 0; xZone < matZones.GridSize.x; xZone++)
                        {
                            if (cells[yZone,xZone] == cells[y, x])
                            {
                                GameObject newTrigger = Instantiate(prefabTrigger, new Vector3(xZone * gridSize, 0f, -yZone * gridSize), Quaternion.identity);
                                newTrigger.transform.parent = newZone.transform;
                                zonesPositions.Add(newTrigger.transform.position);
                                newTrigger.GetComponent<Renderer>().material.color = colorZone;
                            }
                        }
                    }
                    instantiatedZones.Add(cells[y, x]);
                }
            }
        }
    }
    public Color GetRandomColor()
    {
        // Generate random values for RGB components
        float randomRed = Random.value;
        float randomGreen = Random.value;
        float randomBlue = Random.value;

        // Create and return a new random color
        return new Color(randomRed, randomGreen, randomBlue);
    }
}
