using UnityEngine;

namespace CharacterEditor
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Head;
        [SerializeField] private MeshRenderer m_Body;
        [SerializeField] private MeshRenderer m_ArmR;
        [SerializeField] private MeshRenderer m_ArmL;
        [SerializeField] private MeshRenderer m_LegR;
        [SerializeField] private MeshRenderer m_LegL;

        private void Start()
        {
            Load();
        }

        public void Load()
        {
            //Load materials from the MaterialManager and pass in the id pulled from each PlayerPref 
            m_Head.material = MaterialManager2.Get(PlayerPrefs.GetInt("Head", 0));
            m_Body.material = MaterialManager2.Get(PlayerPrefs.GetInt("Body", 0));
            m_ArmL.material = MaterialManager2.Get(PlayerPrefs.GetInt("Arm", 0));
            m_ArmR.material = MaterialManager2.Get(PlayerPrefs.GetInt("Arm", 0));
            m_LegL.material = MaterialManager2.Get(PlayerPrefs.GetInt("Leg", 0));
            m_LegR.material = MaterialManager2.Get(PlayerPrefs.GetInt("Leg", 0));
        }
    }
}