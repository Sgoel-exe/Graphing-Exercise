using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples {

    public class Hide : MonoBehaviour {
        private void OnValidate() => this.gameObject.hideFlags = HideFlags.HideInHierarchy;
    }

}