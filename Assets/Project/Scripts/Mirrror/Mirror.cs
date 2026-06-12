using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class PlanarMirror : MonoBehaviour
{
    public Camera viewerCamera;
    public Transform mirrorSurface;

    Camera cam;

    void OnEnable()
    {
        cam = GetComponent<Camera>();
        RenderPipelineManager.beginCameraRendering += Begin;
        RenderPipelineManager.endCameraRendering += End;
    }
    void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= Begin;
        RenderPipelineManager.endCameraRendering -= End;
    }

    void Begin(ScriptableRenderContext context, Camera c) { if (c == cam) GL.invertCulling = true; }
    void End(ScriptableRenderContext context, Camera c) { if (c == cam) GL.invertCulling = false; }

    void LateUpdate()
    {
        if (!viewerCamera || !mirrorSurface || !cam) return;

        Vector3 normal = mirrorSurface.up;
        float offset = -Vector3.Dot(normal, mirrorSurface.position);

        cam.worldToCameraMatrix = viewerCamera.worldToCameraMatrix * Reflection(normal, offset);
        cam.projectionMatrix = viewerCamera.projectionMatrix;
    }

    // Flips any point to the other side of the mirror.
    // Rule for one point:  reflected = point - 2 * (distance from plane) * normal
    static Matrix4x4 Reflection(Vector3 normal, float offset)
    {
        // Pack the plane into 4 numbers. Dotting this with a point gives its distance from the mirror.
        Vector4 plane = new Vector4(normal.x, normal.y, normal.z, offset);

        // Start with "change nothing" (identity), then bend each axis so points flip across the plane.
        Matrix4x4 m = Matrix4x4.identity;
        m.SetRow(0, m.GetRow(0) - 2f * normal.x * plane); // new x of a reflected point
        m.SetRow(1, m.GetRow(1) - 2f * normal.y * plane); // new y
        m.SetRow(2, m.GetRow(2) - 2f * normal.z * plane); // new z
        // (row 4 is left alone — it just carries the point along)

        return m;
    }
}