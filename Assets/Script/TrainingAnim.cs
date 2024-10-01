using System.Collections.Generic;
using UnityEngine;

public class TrainingAnim : MonoBehaviour
{
    [SerializeField] private List<GameObject> _state;

    private Animator _animator;
    private int _actualState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void NextState()
    {
        _animator.SetTrigger("Next");
        _actualState++;
        ChangeState();
    }

    private void ChangeState()
    {
        for(int i =0; i<_state.Count; i++)
        {
            if (i == _actualState)
                _state[_actualState].SetActive(true);

            else
                _state[i].SetActive(false);
        }
    }

}
