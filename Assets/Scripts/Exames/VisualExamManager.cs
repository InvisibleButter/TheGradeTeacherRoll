using System.Collections.Generic;
using System.Linq;
using Exames;
using UnityEngine;

public class VisualExamManager : MonoBehaviour
{
    public GameObject ExamVisualPrefab;
    public Transform ExamsHolder;

    public int Spacing = 2;

    private List<Exam> _exames;
    private List<GameObject> _examVisuals;

    public void Setup(List<Exam> exames)
    {
        _exames = exames;
        
        ClearExams();
        CreateVisuals();
    }

    private void ClearExams()
    {
        if (_examVisuals != null)
        {
            foreach (var visual in _examVisuals)
            {
                Destroy(visual);
            }
            _examVisuals.Clear();
        }
        else
        {
            _examVisuals = new List<GameObject>();
        }
    }
    

    private void CreateVisuals()
    {
        for (int i = 0; i < _exames.Count - 1; i++)
        {
            GameObject go = Instantiate(ExamVisualPrefab, ExamsHolder);
            go.GetComponent<VisualExamEntry>().Setup(_exames[i]);
            _examVisuals.Add(go);

            if (i > 0 && i <= _exames.Count - 2)
            {
                go.transform.position += new Vector3(0, i * Spacing, 0);
            }
            

            go.transform.eulerAngles += new Vector3(0, Random.Range(-15, 15), 0);
        }
    }

    public void HideLastExam()
    {
        GameObject go = _examVisuals.Last(each => each.activeInHierarchy);
        go.SetActive(false);
    }
}
