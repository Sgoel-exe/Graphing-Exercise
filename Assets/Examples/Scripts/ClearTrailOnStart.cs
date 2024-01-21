using UnityEngine;

namespace Examples {

public class ClearTrailOnStart : MonoBehaviour {
    private void Start() => GetComponent<TrailRenderer>().Clear();
}

}