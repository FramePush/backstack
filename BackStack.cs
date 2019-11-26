using System.Collections.Generic;
using UnityEngine;

namespace FramePush.BackStack
{
	public class BackStack : MonoBehaviour
    {
        private static BackStack _Primary;

        private List<IBackStackable> _Items = new List<IBackStackable>();

        public static BackStack Primary
        {
            get
            {
                if (_Primary) {
                    return _Primary;
                }

                _Primary = new GameObject().AddComponent<BackStack>();
                return _Primary;
            }
        }

        public int Count { get { return _Items.Count; } }

        #region Unity Messages
        private void Awake()
        {
            if (!_Primary) {
                _Primary = this;
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
			{
				GoBack();
			}
        }
        #endregion

        public bool Contains(IBackStackable item)
        {
            return _Items.Contains(item);
        }

        public void Push(IBackStackable item)
        {
            _Items.Add(item);
        }

        public bool Remove(IBackStackable item)
        {
            return _Items.Remove(item);
        }

        public void Clear()
        {
            _Items.Clear();
        }

        public bool GoBack()
        {
            for (var i = _Items.Count - 1; 0 <= i; --i) {
                IBackStackable item = _Items[i];
                _Items.RemoveAt(i);
                
                if (item != null) {
                    item.Dismiss();
                    break;
                }
            }

            for (var i = _Items.Count - 1; 0 <= i; --i) {
                IBackStackable item = _Items[i];
                
                if (item != null) {
                    item.GoBackTo();
                    return true;
                }
                
                _Items.RemoveAt(i);
            }

			return false;
        }
    }
}