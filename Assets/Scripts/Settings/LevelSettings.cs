using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private WayDrawer _wayDrawer;

    [SerializeField] private int _wayLength;
    
    void Start()
    {
        _wayDrawer.SetWayLength(_wayLength);
    }
}
