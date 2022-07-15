using UnityEngine;
using UnityEngine.UI;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "MultipleAnswer", menuName = "Task", order = 0)]
    public class SimpleImageTaskTemplate : SimpleTaskTemplate
    {

        [SerializeField] private Image image;
        public Image Image => image;
    }
        
}