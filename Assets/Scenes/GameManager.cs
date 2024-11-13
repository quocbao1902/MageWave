using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PickCanvas;
    public KeyCode startbutton;
    public Transform PickedSpawnPoint1;
    public Transform PickedSpawnPoint2;
    //-------------------------------------------------------------------------------------
    public GameObject slot1_1;
    public GameObject slot1_2;
    public GameObject slot1_3;
    public GameObject slot1_4;
    //-------------------------------------------------------------------------------------
    public GameObject slot2_1;
    public GameObject slot2_2;
    public GameObject slot2_3;
    public GameObject slot2_4;
    //--------------------------------------------------------------------------------------
    private GameObject currentSlot1Object;
    private GameObject currentSlot2Object;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        PickCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        spacetostart();
    }

    //-------------------------------------------------------------------------------------------------------------
    public void PickedSlot1_1()
    {
        if (currentSlot1Object != null)
        {
            Destroy(currentSlot1Object);
        }

        currentSlot1Object = Instantiate(slot1_1, PickedSpawnPoint1.position, PickedSpawnPoint1.rotation);
    }

    public void PickedSlot1_2()
    {

        if (currentSlot1Object != null)
        {
            Destroy(currentSlot1Object);
        }

        currentSlot1Object = Instantiate(slot1_2, PickedSpawnPoint1.position, PickedSpawnPoint1.rotation);
    }

    public void PickedSlot1_3()
    {

        if (currentSlot1Object != null)
        {
            Destroy(currentSlot1Object);
        }

        currentSlot1Object = Instantiate(slot1_3, PickedSpawnPoint1.position, PickedSpawnPoint1.rotation);
    }

    public void PickedSlot1_4()
    {

        if (currentSlot1Object != null)
        {
            Destroy(currentSlot1Object);
        }

        currentSlot1Object = Instantiate(slot1_4, PickedSpawnPoint1.position, PickedSpawnPoint1.rotation);
    }
    //---------------------------------------------------------------------------------------------------------------------------------
    public void PickedSlot2_1()
    {

        if (currentSlot2Object != null)
        {
            Destroy(currentSlot2Object);
        }

        currentSlot2Object = Instantiate(slot2_1, PickedSpawnPoint2.position, PickedSpawnPoint2.rotation);
    }

    public void PickedSlot2_2()
    {

        if (currentSlot2Object != null)
        {
            Destroy(currentSlot2Object);
        }

        currentSlot2Object = Instantiate(slot2_2, PickedSpawnPoint2.position, PickedSpawnPoint2.rotation);
    }

    public void PickedSlot2_3()
    {

        if (currentSlot2Object != null)
        {
            Destroy(currentSlot2Object);
        }

        currentSlot2Object = Instantiate(slot2_3, PickedSpawnPoint2.position, PickedSpawnPoint2.rotation);
    }

    public void PickedSlot2_4()
    {

        if (currentSlot2Object != null)
        {
            Destroy(currentSlot2Object);
        }

        currentSlot2Object = Instantiate(slot2_4, PickedSpawnPoint2.position, PickedSpawnPoint2.rotation);
    }

    //-------------------------------------------------------------------------------------------------------------

    void spacetostart()
    {
        if (Input.GetKey(startbutton))
        {
            Time.timeScale = 1;
            PickCanvas.SetActive(false);

        }
    }

}
