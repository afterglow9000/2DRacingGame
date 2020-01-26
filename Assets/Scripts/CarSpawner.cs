using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] cars;
    public float delayTime = 1.75f;

    float timer;
    int carNo;

    // Start is called before the first frame update
    void Start()
    {
        timer = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 3);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTime;
        }
    }
}
