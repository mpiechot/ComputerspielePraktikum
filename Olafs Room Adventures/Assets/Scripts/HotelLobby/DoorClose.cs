using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorClose : MonoBehaviour
{
    public GameObject door;
    [SerializeField]
    public Vector3 closePosition;
    [SerializeField]
    public GameObject roomToDispose;
    public GameObject newRoom;

    private bool closeTheDoor;
    private bool doorClosed;

    // Start is called before the first frame update
    void Start()
    {
        closeTheDoor = false;
        doorClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeTheDoor && !doorClosed)
        {
            door.transform.position = Vector3.Lerp(door.transform.position,closePosition,0.02f);
        }
        if(Mathf.Abs(door.transform.position.y - closePosition.y) <= 0.001 && !doorClosed)
        {
            doorClosed = true;
            //SceneManager.LoadScene("SecondRoom", LoadSceneMode.Single);
            StartCoroutine("DisposeRoom");
        }
    }

    private IEnumerator DisposeRoom()
    {
        MeshCollider[] mcs = roomToDispose.GetComponentsInChildren<MeshCollider>();
        foreach(MeshCollider mc in mcs)
        {
            mc.convex = true;
        }

        roomToDispose.AddComponent(typeof(Rigidbody));
        door.GetComponent<MeshCollider>().convex = true;
        door.AddComponent(typeof(Rigidbody));

        while (roomInSight())
        {
            yield return 0;
        }
        Destroy(roomToDispose);
        yield return new WaitForSeconds(1);

        Instantiate(newRoom);
        Destroy(gameObject, 2);
        yield return null;
    }

    private bool roomInSight()
    {
        if(Mathf.Abs(roomToDispose.transform.position.x) >= 100)
        {
            return false;
        }
        if (Mathf.Abs(roomToDispose.transform.position.y) >= 100)
        {
            return false;
        }
        if (Mathf.Abs(roomToDispose.transform.position.z) >= 100)
        {
            return false;
        }
        return true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            closeTheDoor = true;
        }
    }
}
