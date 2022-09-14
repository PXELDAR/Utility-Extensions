using UnityEngine;

namespace PXELDAR
{
    public static class GameObjectExtensions
    {
        //===================================================================================

        public static void DestroyChildren(this GameObject gameObject)
        {
            gameObject.transform.DestroyChildren();
        }

        //===================================================================================

        public static void ResetTransformation(this GameObject gameObject)
        {
            gameObject.transform.ResetTransformation();
        }

        //===================================================================================

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) gameObject.AddComponent<T>();
            return component;
        }

        //===================================================================================

        public static bool HasComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            return gameObject.GetComponent<T>() != null;
        }

        //===================================================================================

        private static void InternalMoveToLayer(Transform root, int layer)
        {
            root.gameObject.layer = layer;
            foreach (Transform child in root)
                InternalMoveToLayer(child, layer);
        }

        //===================================================================================

        public static void MoveToLayer(this GameObject root, int layer)
        {
            InternalMoveToLayer(root.transform, layer);
        }

        //===================================================================================

        public static bool IsInLayerMask(this GameObject gameObject, LayerMask mask)
        {
            return ((mask.value & (1 << gameObject.layer)) > 0);
        }

        //===================================================================================

        public static T[] GetClasses<T>(this GameObject gObj) where T : class
        {
            var ts = gObj.GetComponents(typeof(T));

            var ret = new T[ts.Length];
            for (int i = 0; i < ts.Length; i++)
            {
                ret[i] = ts[i] as T;
            }
            return ret;
        }

        //===================================================================================

        public static T[] GetClasses<T>(this Transform gObj) where T : class
        {
            return gObj.gameObject.GetClasses<T>();
        }

        /// <summary>
        /// Returns the first monobehaviour that is of the class Type, as T
        /// works with interfaces
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T GetClass<T>(this GameObject gObj) where T : class
        {
            return gObj.GetComponent(typeof(T)) as T;
        }

        /// <summary>
        /// Gets all monobehaviours in children that implement the class of type T (casted to T)
        /// works with interfaces
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T[] GetClassesInChildren<T>(this GameObject gObj) where T : class
        {
            var ts = gObj.GetComponentsInChildren(typeof(T));

            var ret = new T[ts.Length];
            for (int i = 0; i < ts.Length; i++)
            {
                ret[i] = ts[i] as T;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// Returns the first instance of the monobehaviour that is of the class type T (casted to T)
        /// works with interfaces
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T GetClassInChildren<T>(this GameObject gObj) where T : class
        {
            return gObj.GetComponentInChildren(typeof(T)) as T;
        }
    }
}