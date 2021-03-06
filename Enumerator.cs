    
[Flags]
enum Days
{
    None = 0x0, //--> 0000          == 0
    Sunday = 0x1,   //--> 0001      == 1 << 0   == 1
    Monday = 0x2,   //--> 0010      == 1 << 1   == 2
    Tuesday = 0x4,  //--> 0100      == 1 << 2   == 4
    Wednesday = 0x8,//--> 1000      == 1 << 3   == 8
    Thursday = 0x10,    //--> 0001 0000
    Friday = 0x20,      //--> 0010 0000
    Saturday = 0x40     //--> 0100 0000
}
class MyClass
{
    Days meetingDays = Days.Tuesday | Days.Thursday;
}



/// <summary>
    /// Flags representing trackable types in XR.
    /// A "trackable" is feature in the physical environment that a device is able to track, such as a surface.
    /// Often used in conjunction with <see cref="XRRaycastHit"/>.
    /// </summary>
    [Flags]
    public enum TrackableType
    {
        /// <summary>
        /// No trackable.
        /// </summary>
        None = 0,

        /// <summary>
        /// Refers to 2D convex shape associated with a plane's boundary points.
        /// </summary>
        /// <remarks>
        /// When used as the <c>trackableTypeMask</c> in a
        /// <see cref="XRRaycastSubsystem.Raycast(Ray, TrackableType, Unity.Collections.Allocator)"/>,
        /// the ray is considered to have hit if the ray intersects with the polygon described by the exact
        /// boundary of the plane.
        /// </remarks>
        PlaneWithinPolygon = 1 << 0,

        /// <summary>
        /// Refers to the 2D rectangular bounding box that tightly encloses the plane's polygon.
        /// </summary>
        /// <remarks>
        /// When used as the <c>trackableTypeMask</c> in a
        /// <see cref="XRRaycastSubsystem.Raycast(Ray, TrackableType, Unity.Collections.Allocator)"/>,
        /// the ray is considered to have hit if the ray intersects with the 2D box described by the
        /// size of the plane.
        /// </remarks>
        PlaneWithinBounds = 1 << 1,

        /// <summary>
        /// Refers to the infinite plane described by its <c>Pose</c> (a position and orientation).
        /// </summary>
        /// <remarks>
        /// When used as the <c>trackableTypeMask</c> in a
        /// <see cref="XRRaycastSubsystem.Raycast(Ray, TrackableType, Unity.Collections.Allocator)"/>,
        /// the ray is considered to have hit if the ray intersects with the infinite plane.
        /// </remarks>
        PlaneWithinInfinity = 1 << 2,

        /// <summary>
        /// Refers to an estimated plane.
        /// </summary>
        /// <remarks>
        /// When used as the <c>trackableTypeMask</c> in a
        /// <see cref="XRRaycastSubsystem.Raycast(Ray, TrackableType, Unity.Collections.Allocator)"/>,
        /// the ray is considered to have hit if the ray intersects with an estimated plane. An estimated
        /// plane is implementation defined, but may not have an exact boundary. It is a guess that suggests
        /// the ray is near a surface.
        /// </remarks>
        PlaneEstimated = 1 << 3,

        /// <summary>
        /// Refers to any of the plane type trackables.
        /// </summary>
        /// <remarks>
        /// Often used with the <c>trackableTypeMask</c> in a
        /// <see cref="XRRaycastSubsystem.Raycast(Ray, TrackableType, Unity.Collections.Allocator)"/>,
        /// the ray is considered to have hit if the ray intersects with any of the plane types.
        /// </remarks>
        Planes =
            PlaneWithinPolygon |
            PlaneWithinBounds |
            PlaneWithinInfinity |
            PlaneEstimated,

        /// <summary>
        /// Refers to a feature point (i.e., point in a point cloud).
        /// </summary>
        /// <remarks>
        /// When used as the <c>trackableTypeMask</c> in a
        /// <see cref="XRRaycastSubsystem.Raycast(Ray, TrackableType, Unity.Collections.Allocator)"/>,
        /// the ray is considered to have hit if a cone around the ray intersects with a point in a point cloud.
        /// </remarks>
        FeaturePoint = 1 << 4,

        /// <summary>
        /// Refers to a tracked image.
        /// </summary>
        Image = 1 << 5,

        /// <summary>
        /// Refers to a tracked face.
        /// </summary>
        Face = 1 << 6,

        /// <summary>
        /// Refers to all trackable types.
        /// </summary>
        All = Planes | FeaturePoint | Image | Face
    }
