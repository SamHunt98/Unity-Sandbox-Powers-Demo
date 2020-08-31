using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInLight : MonoBehaviour
{
    public GameObject sun;
    public bool isInSun = false;
    public float visibility = 0; //will be the value between 0 and 1 showing how visible the player is as a %
    public playerMovement movementScript;
    public List<GameObject> lights;
    public List<float> brightness; //a list of how much visibility each light in the lights array is adding to the player
    public LayerMask wallMask;
    public LayerMask groundMask;
    public LayerMask ceilingMask;
    LayerMask finalMask; //celing, wall and elevated ground can all cause shadows, so a layermask that covers all of these different types of terrain is needed
    public LayerMask powerMask; //stops the wind power from blocking light
    void Start()
    {
        lights = new List<GameObject>();
        movementScript = GetComponent<playerMovement>();
        finalMask = wallMask | groundMask | ceilingMask; //sets the layer mask to be equal to all of the layers
        InvokeRepeating("checkIsInLight", 0f,0.25f); //will check every quarter second instead of every frame to improve performance
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void checkIsInLight()
    {
        checkSunLight();
        if(!isInSun)
        {
            checkPointLights();
        }
        if (movementScript.isCrouching)
        {
            visibility -= 0.3f;
            visibility = Mathf.Clamp(visibility, 0, 1); //if the player is crouching they become 30% less visible - this value is then clamped again to make sure it does not go below 0
        }

    }
    void checkSunLight()
    {
        //checks if the player is in the sunlight directly first - if they are, the value will be maxed regardless of point lights
        Vector3 sunDirection = sun.transform.forward; //get the direction the sunlight is facing
        sunDirection.Normalize(); 
        if (!Physics.Raycast(transform.position, sunDirection * -1, Mathf.Infinity, finalMask))
        { 
            isInSun = true;
            visibility = 1;
        }
        else
        {
            isInSun = false;
            visibility = 0;
        }
    }
    void checkPointLights()
    {
        brightness = new List<float>(); //resets the brightness list so that new values can be added - stops crashes/unintended results
        if (lights.Count > 0) //will only execute if player is touched by at least one light
        {
            for(int i = 0; i < lights.Count; i++)
            {
                RaycastHit hitResult;
                if (Physics.Linecast(lights[i].transform.position, transform.position, out hitResult,~powerMask))
                {
                    if (hitResult.transform.gameObject.tag == "Player") //if the linecast from the light finds nothing is blocking the player
                    {
                        //Debug.Log("in light");
                        float tempDistance = Vector3.Distance(lights[i].transform.position, transform.position); //distance from light to player
                        float lightRadius = lights[i].GetComponent<Light>().range; //radius of the light
                        float brightnessToAdd = lightFalloffFunction(Mathf.Min(tempDistance, lightRadius), lightRadius); //light falloff function uses maths based on the UE4 light falloff calculation - seems to work in Unity too
                        brightness.Add(0); //adds a new entry into the brightness list
                        brightness[i] = brightnessToAdd; //sets the new entry to be equal to the brightness value from the falloff function
                        brightness[i] += visibility; //adds the current visibility to the brightness - gives a cumulative value 
                        visibility = brightness[i]; //sets the visibility to the new cumulative value
                    }
                    else
                    {
                        //Debug.Log("blocked from light");
                        brightness.Add(0);
                        brightness[i] = 0;
                        brightness[i] += visibility;
                        visibility = brightness[i]; //this light is blocked, and as such adds nothing to the brightness
                    }


                }
            }
            visibility = Mathf.Clamp(visibility, 0, 1); //clamps the value to be between 0 and 1 so a proper percentage can be found
       
        }
    }

    float lightFalloffFunction(float distance, float radius)
    {
        float temp = distance / radius;
        temp = Mathf.Pow(temp, 4);
        temp = 1 - temp;
        temp = Mathf.Pow(temp, 2);
        return temp;
    }
}
