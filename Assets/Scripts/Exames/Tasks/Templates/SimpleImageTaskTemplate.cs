using UnityEngine;
using UnityEngine.UI;

namespace Exames.Tasks.Templates
{
    [CreateAssetMenu(fileName = "ImageTask", menuName = "Task/ImageTask", order = 0)]
    public class SimpleImageTaskTemplate : SimpleTaskTemplate
    {

        [SerializeField] private Image image;
        public Image Image => image;
    }
        
}