using UnityEngine;

    public class ChangeTimerStates : MonoBehaviour
    {
        GameObject _timer;
    private void Update() => _timer = GameObject.FindGameObjectWithTag("timer");

    public void TimerState(bool _state) => _timer.GetComponent<timer>().PauseTimer(_state);
    }

