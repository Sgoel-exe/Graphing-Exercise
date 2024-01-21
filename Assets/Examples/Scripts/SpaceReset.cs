using UnityEngine;
using UnityEngine.SceneManagement;

namespace Examples {

public class SpaceReset : MonoBehaviour {
    
    private void Update() {
        if( !Input.GetKeyDown( KeyCode.Space ) ) return;
        
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}

}