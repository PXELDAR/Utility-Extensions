using UnityEngine;

namespace PXELDAR
{
    public static class RigidbodyExtensions
    {
        //===================================================================================

        public static void ChangeDirection(this Rigidbody rb, Vector3 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }

        //===================================================================================

        public static void ChangeDirection(this Rigidbody2D rb, Vector2 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }

        //===================================================================================

        public static void NormalizeVelocity(this Rigidbody rb, float magnitude = 1)
        {
            rb.velocity = rb.velocity.normalized * magnitude;
        }

        //===================================================================================

        public static void NormalizeVelocity(this Rigidbody2D rb, float magnitude = 1)
        {
            rb.velocity = rb.velocity.normalized * magnitude;
        }

        //===================================================================================

    }
}