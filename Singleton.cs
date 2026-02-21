using UnityEngine;

namespace DesiShadow.Core
{
    /// <summary>
    /// A static instance is similar to a global variable.
    /// It ensures only one copy of this script exists.
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject); // Keeps this object alive between scenes
            }
            else
            {
                Destroy(gameObject); // Destroys duplicate managers
            }
        }
    }
}
