using Saif.Settings;
using Saif.World.VirtualMap;
using UnityEngine;

namespace Saif.Behaviours
{
    [RequireComponent(typeof(MapDrawer))]
    public class SimulationMaster : MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private bool loopByXAxis = true;
        [SerializeField] private bool loopByYAxis;

        private MapDrawer _drawer;
        private HexFarm _farm;

        private void Start()
        {
            _drawer = GetComponent<MapDrawer>();

            GlobalSettings.Size = new Size(size, loopByXAxis, loopByYAxis);
            _farm = new HexFarm(_drawer, GlobalSettings.Size);
        }
    }
}