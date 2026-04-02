namespace DbLibrary;

/// <summary>
/// Отслеживаемые состояния сущностей для DbSet операция
/// </summary>
public enum TrackingType
{
    NoTracking,
    NoTrackingWithIdentityResolution,
    Tracking
}