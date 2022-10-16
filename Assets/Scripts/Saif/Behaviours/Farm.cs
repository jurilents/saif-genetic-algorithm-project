using UnityEngine;

namespace Saif.Behaviours
{
    [RequireComponent(typeof(MapDrawer))]
    public class Farm : MonoBehaviour
    {
        private MapDrawer _drawer;

        private void Start()
        {
            _drawer = GetComponent<MapDrawer>();
        }
    }
}