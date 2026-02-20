
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float _tickInSecs = 2f;
    float _timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        WorldEvents.OnTick.Raise(_timer);
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _tickInSecs)
        {
            Tick();
            _timer = 0f;
        } 
    }



    private void Tick()
    {
        //Raise TickEvent
        WorldEvents.OnTick.Raise(_timer);
        //Debug.Log($"Tick Event raised at timer = {_timer}");
    }
}
